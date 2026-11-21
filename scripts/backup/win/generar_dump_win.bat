@echo off
setlocal DisableDelayedExpansion

set "SCRIPT_DIR=%~dp0"
for %%I in ("%SCRIPT_DIR%..\..\..") do set "REPO_ROOT=%%~fI"
set "MYSQL_HOST=%MYSQL_HOST%"
set "MYSQL_PORT=%MYSQL_PORT%"
set "MYSQL_USER=%MYSQL_USER%"
if not defined MYSQL_HOST set "MYSQL_HOST=localhost"
if not defined MYSQL_PORT set "MYSQL_PORT=3306"
if not defined MYSQL_USER set "MYSQL_USER=root"

if "%~1"=="-h" goto usage
if "%~1"=="--help" goto usage
if not "%~3"=="" goto invalid_args
if "%~1"=="" (
  set /p "DB_NAME=Base origen: "
) else (
  set "DB_NAME=%~1"
)
if not defined DB_NAME (
  echo Error: debes indicar una base origen. 1>&2
  exit /b 1
)

if "%~2"=="" (
  set "OUTPUT_PATH=scripts\backup\torneo.sql"
) else (
  set "OUTPUT_PATH=%~2"
)

set "VALIDATION_VALUE=%DB_NAME%"
powershell -NoProfile -Command "if ($env:VALIDATION_VALUE -notmatch '^[A-Za-z0-9_]+$') { exit 1 }"
if errorlevel 1 (
  echo Error: nombre de base invalido. Usa solo letras, numeros y guion bajo. 1>&2
  exit /b 1
)

where mysqldump >nul 2>nul
if errorlevel 1 (
  echo Error: no se encontro 'mysqldump' en PATH. 1>&2
  exit /b 1
)

if "%OUTPUT_PATH:~1,1%"==":" (
  set "OUTPUT_ABS_PATH=%OUTPUT_PATH%"
) else if "%OUTPUT_PATH:~0,2%"=="\\" (
  set "OUTPUT_ABS_PATH=%OUTPUT_PATH%"
) else (
  set "OUTPUT_ABS_PATH=%REPO_ROOT%\%OUTPUT_PATH%"
)

for %%I in ("%OUTPUT_ABS_PATH%") do set "OUTPUT_ABS_PATH=%%~fI"
for %%I in ("%OUTPUT_ABS_PATH%") do set "OUTPUT_DIR=%%~dpI"
if not exist "%OUTPUT_DIR%" mkdir "%OUTPUT_DIR%"
if errorlevel 1 (
  echo Error: no se pudo crear el directorio de salida. 1>&2
  exit /b 1
)

set "TMP_OUTPUT=%OUTPUT_ABS_PATH%.tmp.%RANDOM%.%RANDOM%"
set "PASSWORD_ARG="
if not defined MYSQL_PWD set "PASSWORD_ARG=-p"

echo Generando dump en "%OUTPUT_ABS_PATH%" ...
call mysqldump -h "%MYSQL_HOST%" -P "%MYSQL_PORT%" -u "%MYSQL_USER%" %PASSWORD_ARG% --default-character-set=utf8mb4 --single-transaction --skip-lock-tables --routines --triggers "%DB_NAME%" > "%TMP_OUTPUT%"
if errorlevel 1 (
  echo Error: fallo mysqldump. El archivo original no fue modificado. 1>&2
  del "%TMP_OUTPUT%" >nul 2>nul
  exit /b 1
)

for %%I in ("%TMP_OUTPUT%") do if %%~zI EQU 0 (
  echo Error: se genero un archivo vacio. Revisar credenciales, permisos y nombre de base. 1>&2
  del "%TMP_OUTPUT%" >nul 2>nul
  exit /b 1
)

move /Y "%TMP_OUTPUT%" "%OUTPUT_ABS_PATH%" >nul
if errorlevel 1 (
  echo Error: no se pudo guardar el dump en "%OUTPUT_ABS_PATH%". 1>&2
  del "%TMP_OUTPUT%" >nul 2>nul
  exit /b 1
)

echo Dump generado correctamente en: "%OUTPUT_ABS_PATH%"
for %%I in ("%OUTPUT_ABS_PATH%") do echo Tamano: %%~zI bytes
exit /b 0

:usage
echo Uso:
echo   scripts\backup\win\generar_dump_win.bat ^<base_origen^> [archivo_salida]
echo.
echo Si archivo_salida es relativo, se interpreta desde la raiz del repositorio.
echo Variables opcionales: MYSQL_HOST, MYSQL_PORT, MYSQL_USER, MYSQL_PWD
echo Si MYSQL_PWD no esta definida, mysqldump solicitara la contrasena.
exit /b 0

:invalid_args
call :usage
exit /b 1
