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

if "%~1"=="-h" goto help
if "%~1"=="--help" goto help
if "%~1"=="" goto usage
if not "%~3"=="" goto usage
set "DB_NAME=%~1"

set "VALIDATION_VALUE=%DB_NAME%"
powershell -NoProfile -Command "if ($env:VALIDATION_VALUE -notmatch '^[A-Za-z0-9_]+$') { exit 1 }"
if errorlevel 1 (
  echo Error: nombre de base invalido. Usa solo letras, numeros y guion bajo. 1>&2
  exit /b 1
)

if "%~2"=="" (
  for %%I in ("%SCRIPT_DIR%..\torneo.sql") do set "DUMP_PATH=%%~fI"
) else (
  set "DUMP_PATH=%~2"
)
if not exist "%DUMP_PATH%" (
  echo Error: no existe el dump en "%DUMP_PATH%". 1>&2
  exit /b 1
)

where mysql >nul 2>nul
if errorlevel 1 (
  echo Error: no se encontro 'mysql' en PATH. 1>&2
  exit /b 1
)
where powershell >nul 2>nul
if errorlevel 1 (
  echo Error: se requiere Windows PowerShell para limpiar el dump. 1>&2
  exit /b 1
)

set "TMP_DUMP=%TEMP%\torneo_clean_%RANDOM%_%RANDOM%.sql"
set "PASSWORD_ARG="
if not defined MYSQL_PWD set "PASSWORD_ARG=-p"

powershell -NoProfile -ExecutionPolicy Bypass -File "%SCRIPT_DIR%limpiar_dump.ps1" -InputPath "%DUMP_PATH%" -OutputPath "%TMP_DUMP%"
if errorlevel 1 (
  echo Error: no se pudo preparar el dump para importar. 1>&2
  if exist "%TMP_DUMP%" del "%TMP_DUMP%" >nul 2>nul
  exit /b 1
)

echo [1/3] Creando base de datos "%DB_NAME%" (si no existe)...
call mysql -h "%MYSQL_HOST%" -P "%MYSQL_PORT%" -u "%MYSQL_USER%" %PASSWORD_ARG% -e "CREATE DATABASE IF NOT EXISTS `%DB_NAME%` CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;"
if errorlevel 1 goto mysql_error

echo [2/3] Importando dump limpio en "%DB_NAME%"...
call mysql -h "%MYSQL_HOST%" -P "%MYSQL_PORT%" -u "%MYSQL_USER%" %PASSWORD_ARG% "%DB_NAME%" < "%TMP_DUMP%"
if errorlevel 1 goto mysql_error

echo [3/3] Conteo rapido de tablas principales...
call mysql -h "%MYSQL_HOST%" -P "%MYSQL_PORT%" -u "%MYSQL_USER%" %PASSWORD_ARG% -N -e "SELECT 'equipo', COUNT(*) FROM `%DB_NAME%`.equipo UNION ALL SELECT 'usuario', COUNT(*) FROM `%DB_NAME%`.usuario UNION ALL SELECT 'jugador', COUNT(*) FROM `%DB_NAME%`.jugador UNION ALL SELECT 'plantillatitular', COUNT(*) FROM `%DB_NAME%`.plantillatitular UNION ALL SELECT 'plantillasuplente', COUNT(*) FROM `%DB_NAME%`.plantillasuplente UNION ALL SELECT 'puntuacion', COUNT(*) FROM `%DB_NAME%`.puntuacion;"
if errorlevel 1 goto mysql_error

del "%TMP_DUMP%" >nul 2>nul
echo Restauracion completada.
exit /b 0

:mysql_error
echo Error: fallo mysql durante la restauracion. 1>&2
if exist "%TMP_DUMP%" del "%TMP_DUMP%" >nul 2>nul
exit /b 1

:usage
echo Uso:
echo   scripts\backup\win\restaurar_dump_win.bat ^<base_destino^> [ruta_dump]
echo.
echo Variables opcionales: MYSQL_HOST, MYSQL_PORT, MYSQL_USER, MYSQL_PWD
echo Si MYSQL_PWD no esta definida, mysql solicitara la contrasena.
exit /b 1

:help
call :usage
exit /b 0
