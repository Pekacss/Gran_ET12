#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
Uso:
  ./scripts/backup/linux/restaurar_dump_linux.sh <base_destino> [ruta_dump]

Ejemplo:
  ./scripts/backup/linux/restaurar_dump_linux.sh bd_granet12_restauracion_final_20261020

Variables de entorno opcionales:
  MYSQL_HOST (default: localhost)
  MYSQL_PORT (default: 3306)
  MYSQL_USER (default: root)
  MYSQL_PWD  (si no se define, mysql pedira password cuando corresponda)
EOF
}

if [[ "${1:-}" == "-h" || "${1:-}" == "--help" ]]; then
  usage
  exit 0
fi

if [[ $# -lt 1 || $# -gt 2 ]]; then
  usage
  exit 1
fi

DB_NAME="$1"
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/../../.." && pwd)"
DUMP_PATH="${2:-$REPO_ROOT/scripts/backup/torneo.sql}"

if [[ ! "$DB_NAME" =~ ^[A-Za-z0-9_]+$ ]]; then
  echo "Error: nombre de base invalido. Usa solo letras, numeros y guion bajo." >&2
  exit 1
fi

if [[ ! -f "$DUMP_PATH" ]]; then
  echo "Error: no existe el dump en: $DUMP_PATH" >&2
  exit 1
fi

MYSQL_HOST="${MYSQL_HOST:-localhost}"
MYSQL_PORT="${MYSQL_PORT:-3306}"
MYSQL_USER="${MYSQL_USER:-root}"

if ! command -v mysql >/dev/null 2>&1; then
  echo "Error: no se encontro el comando 'mysql' en PATH." >&2
  exit 1
fi

TMP_DUMP="$(mktemp /tmp/torneo_clean_XXXXXX.sql)"
trap 'rm -f "$TMP_DUMP"' EXIT

# Limpia ruido accidental en el dump para que pueda importarse correctamente.
awk '
BEGIN {
  skip_noisy_block = 0;
  skipping_broken_obtener_todos = 0;
}

# Elimina lineas inyectadas que rompen rutinas.
/GRANT SELECT ON bd_GranET12\.PlantillaTitular TO '\''usuario'\''@'\''localhost'\'';/ { next }
/ENDGRANT SELECT ON bd_GranET12\.PlantillaTitular TO '\''usuario'\''@'\''localhost'\'';/ { next }
/BEGINet_client \*\// { next }

# Reemplaza el bloque corrupto previo a sp_PlantillaSuplente_ObtenerTodos.
/\/\*!50003 DROP PROCEDURE IF EXISTS `sp_PlantillaSuplente_ObtenerTodos` \*\// {
  print "/*!50003 DROP PROCEDURE IF EXISTS `sp_PlantillaSuplente_ObtenerTodos` */;"
  print "/*!50003 SET @saved_cs_client      = @@character_set_client */ ;"
  print "/*!50003 SET @saved_cs_results     = @@character_set_results */ ;"
  print "/*!50003 SET @saved_col_connection = @@collation_connection */ ;"
  print "/*!50003 SET character_set_client  = cp850 */ ;"
  print "/*!50003 SET character_set_results = cp850 */ ;"
  print "/*!50003 SET collation_connection  = cp850_general_ci */ ;"
  print "DELIMITER ;;"
  skipping_broken_obtener_todos = 1
  next
}

skipping_broken_obtener_todos == 1 {
  if ($0 ~ /^CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_PlantillaSuplente_ObtenerTodos`\(\)$/) {
    print $0
    skipping_broken_obtener_todos = 2
  }
  next
}

{ print }
' "$DUMP_PATH" > "$TMP_DUMP"

echo "[1/3] Creando base de datos '$DB_NAME' (si no existe)..."
mysql -h "$MYSQL_HOST" -P "$MYSQL_PORT" -u "$MYSQL_USER" \
  -e "CREATE DATABASE IF NOT EXISTS \\`$DB_NAME\\` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;"

echo "[2/3] Importando dump limpio en '$DB_NAME'..."
mysql -h "$MYSQL_HOST" -P "$MYSQL_PORT" -u "$MYSQL_USER" "$DB_NAME" < "$TMP_DUMP"

echo "[3/3] Conteo rapido de tablas principales..."
mysql -h "$MYSQL_HOST" -P "$MYSQL_PORT" -u "$MYSQL_USER" -N -e "
SELECT 'equipo', COUNT(*) FROM \\`$DB_NAME\\`.equipo
UNION ALL SELECT 'usuario', COUNT(*) FROM \\`$DB_NAME\\`.usuario
UNION ALL SELECT 'jugador', COUNT(*) FROM \\`$DB_NAME\\`.jugador
UNION ALL SELECT 'plantillatitular', COUNT(*) FROM \\`$DB_NAME\\`.plantillatitular
UNION ALL SELECT 'plantillasuplente', COUNT(*) FROM \\`$DB_NAME\\`.plantillasuplente
UNION ALL SELECT 'puntuacion', COUNT(*) FROM \\`$DB_NAME\\`.puntuacion;
"

echo "Restauracion completada."
