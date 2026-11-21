#!/usr/bin/env bash
set -euo pipefail

usage() {
  cat <<'EOF'
Uso:
  ./scripts/backup/linux/generar_dump_linux.sh <base_origen> [archivo_salida]

Nota:
  Si archivo_salida es relativo, se guarda respecto a la raiz del repo.

Ejemplo:
  ./scripts/backup/linux/generar_dump_linux.sh bd_granet12_restauracion_20261020 scripts/backup/torneo.sql

Variables de entorno opcionales:
  MYSQL_HOST (default: localhost)
  MYSQL_PORT (default: 3306)
  MYSQL_USER (default: root)
  MYSQL_PWD  (si no se define y hay terminal interactiva, se pedira)
EOF
}

if [[ "${1:-}" == "-h" || "${1:-}" == "--help" ]]; then
  usage
  exit 0
fi

if [[ $# -gt 2 ]]; then
  usage
  exit 1
fi

if [[ $# -eq 0 ]]; then
  if [[ -t 0 ]]; then
    read -r -p "Base origen: " DB_NAME
    if [[ -z "$DB_NAME" ]]; then
      echo "Error: debes indicar una base origen." >&2
      exit 1
    fi

    read -r -p "Archivo salida [scripts/backup/torneo.sql]: " INPUT_OUTPUT_PATH
    OUTPUT_PATH="${INPUT_OUTPUT_PATH:-scripts/backup/torneo.sql}"
  else
    usage
    exit 1
  fi
else
  DB_NAME="$1"
  OUTPUT_PATH="${2:-scripts/backup/torneo.sql}"
fi

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
REPO_ROOT="$(cd "$SCRIPT_DIR/../../.." && pwd)"

if [[ ! "$DB_NAME" =~ ^[A-Za-z0-9_]+$ ]]; then
  echo "Error: nombre de base invalido. Usa solo letras, numeros y guion bajo." >&2
  exit 1
fi

MYSQL_HOST="${MYSQL_HOST:-localhost}"
MYSQL_PORT="${MYSQL_PORT:-3306}"
MYSQL_USER="${MYSQL_USER:-root}"

if [[ -t 0 ]]; then
  read -r -p "Host MySQL [${MYSQL_HOST}]: " INPUT_HOST
  MYSQL_HOST="${INPUT_HOST:-$MYSQL_HOST}"

  read -r -p "Puerto MySQL [${MYSQL_PORT}]: " INPUT_PORT
  MYSQL_PORT="${INPUT_PORT:-$MYSQL_PORT}"

  read -r -p "Usuario MySQL [${MYSQL_USER}]: " INPUT_USER
  MYSQL_USER="${INPUT_USER:-$MYSQL_USER}"

  if [[ -z "${MYSQL_PWD+x}" ]]; then
    read -r -s -p "Password para ${MYSQL_USER} (Enter si no usa): " INPUT_PWD
    echo
    MYSQL_PWD="$INPUT_PWD"
  fi
fi

if [[ "$OUTPUT_PATH" = /* ]]; then
  OUTPUT_ABS_PATH="$OUTPUT_PATH"
else
  OUTPUT_ABS_PATH="$REPO_ROOT/$OUTPUT_PATH"
fi

if ! command -v mysqldump >/dev/null 2>&1; then
  echo "Error: no se encontro el comando 'mysqldump' en PATH." >&2
  exit 1
fi

mkdir -p "$(dirname "$OUTPUT_ABS_PATH")"

echo "Generando dump en $OUTPUT_ABS_PATH ..."
TMP_OUTPUT="$(mktemp "${OUTPUT_ABS_PATH}.tmp.XXXXXX")"
TMP_ERR="$(mktemp /tmp/mysqldump_err.XXXXXX.log)"
trap 'rm -f "$TMP_OUTPUT" "$TMP_ERR"' EXIT

MYSQL_DUMP_CMD=(
  mysqldump
  -h "$MYSQL_HOST" -P "$MYSQL_PORT" -u "$MYSQL_USER"
  --default-character-set=utf8mb4
  --single-transaction
  --skip-lock-tables
  --routines
  --triggers
  "$DB_NAME"
)

if [[ -n "${MYSQL_PWD:-}" ]]; then
  if ! MYSQL_PWD="$MYSQL_PWD" "${MYSQL_DUMP_CMD[@]}" > "$TMP_OUTPUT" 2>"$TMP_ERR"; then
    echo "Error: fallo mysqldump. Archivo original no fue modificado." >&2
    cat "$TMP_ERR" >&2
    exit 1
  fi
else
  if ! "${MYSQL_DUMP_CMD[@]}" > "$TMP_OUTPUT" 2>"$TMP_ERR"; then
    echo "Error: fallo mysqldump. Archivo original no fue modificado." >&2
    cat "$TMP_ERR" >&2
    exit 1
  fi
fi

if [[ ! -s "$TMP_OUTPUT" ]]; then
  echo "Error: se genero un archivo vacio. Revisar credenciales, permisos y nombre de base." >&2
  exit 1
fi

mv "$TMP_OUTPUT" "$OUTPUT_ABS_PATH"

echo "Dump generado correctamente en: $OUTPUT_ABS_PATH"
echo "Tamano: $(wc -c < "$OUTPUT_ABS_PATH") bytes"
