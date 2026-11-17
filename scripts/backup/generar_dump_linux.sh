#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
Uso:
  ./scripts/backup/generar_dump_linux.sh <base_origen> [archivo_salida]

Ejemplo:
  ./scripts/backup/generar_dump_linux.sh bd_granet12_restauracion_20261020 scripts/backup/torneo.sql

Variables de entorno opcionales:
  MYSQL_HOST (default: localhost)
  MYSQL_PORT (default: 3306)
  MYSQL_USER (default: root)
  MYSQL_PWD  (si no se define, mysqldump pedira password cuando corresponda)
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
OUTPUT_PATH="${2:-scripts/backup/torneo.sql}"

if [[ ! "$DB_NAME" =~ ^[A-Za-z0-9_]+$ ]]; then
  echo "Error: nombre de base invalido. Usa solo letras, numeros y guion bajo." >&2
  exit 1
fi

MYSQL_HOST="${MYSQL_HOST:-localhost}"
MYSQL_PORT="${MYSQL_PORT:-3306}"
MYSQL_USER="${MYSQL_USER:-root}"

if ! command -v mysqldump >/dev/null 2>&1; then
  echo "Error: no se encontro el comando 'mysqldump' en PATH." >&2
  exit 1
fi

mkdir -p "$(dirname "$OUTPUT_PATH")"

echo "Generando dump en $OUTPUT_PATH ..."
mysqldump \
  -h "$MYSQL_HOST" -P "$MYSQL_PORT" -u "$MYSQL_USER" \
  --default-character-set=utf8mb4 \
  --single-transaction \
  --skip-lock-tables \
  --routines \
  --triggers \
  "$DB_NAME" > "$OUTPUT_PATH"

echo "Dump generado correctamente."
