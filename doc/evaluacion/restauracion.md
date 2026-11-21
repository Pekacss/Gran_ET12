# Restauración de la base

## Resultado

El 20/10/2026 generé `scripts/backup/torneo.sql` con `mysqldump` de XAMPP. Para no copiar datos personales de la base original, usé una base temporal que contiene solamente fixtures ficticios.

Restauré el archivo en una segunda base vacía (`bd_granet12_restauracion_final_20261020`) usando XAMPP MariaDB 10.4.32. La importación creó las ocho tablas, los triggers y los procedimientos almacenados. Verifiqué `sp_Usuario_ObtenerTodos` y estos conteos:

| Tabla | Registros |
| --- | ---: |
| Equipo | 1 |
| Usuario | 2 |
| Jugador | 15 |
| PlantillaTitular | 11 |
| PlantillaSuplente | 4 |
| Puntuacion | 11 |

Los dos usuarios usan correos `@example.invalid`; el dump no incluye las filas de la base original. El hash almacenado es BCrypt; la contraseña de demostración es `clave-demo`.

La prueba confirma la restauración en MariaDB de XAMPP, no en MySQL 8. Queda pendiente repetirla en MySQL 8 para cubrir exactamente la versión solicitada.

## Repetir

Los scripts están separados por sistema operativo:

- `scripts/backup/linux/restaurar_dump_linux.sh` y `scripts/backup/win/restaurar_dump_win.bat`: restauran el dump en una base destino (esto es lo que se entrega como restauración).
- `scripts/backup/linux/generar_dump_linux.sh` y `scripts/backup/win/generar_dump_win.bat`: regeneran el dump desde una base origen (opcional, para volver a exportar).

Uso recomendado en Linux (restauración):

```bash
cd /home/et12alumno/Escritorio/Gran_ET12
./scripts/backup/linux/restaurar_dump_linux.sh bd_granet12_restore_test
```

Si necesitás credenciales/host/puerto distintos:

```bash
MYSQL_HOST=localhost MYSQL_PORT=3306 MYSQL_USER=root ./scripts/backup/linux/restaurar_dump_linux.sh bd_granet12_restore_test
```

En Windows, desde PowerShell en la raíz del repositorio:

```powershell
.\scripts\backup\win\restaurar_dump_win.bat bd_granet12_restore_test
```

Si necesitás credenciales, definí `MYSQL_HOST`, `MYSQL_PORT`, `MYSQL_USER` y opcionalmente `MYSQL_PWD` en el entorno antes de ejecutar el `.bat`. Si no definís `MYSQL_PWD`, `mysql` solicita la contraseña.

Regenerar dump en Linux (opcional):

```bash
cd /home/et12alumno/Escritorio/Gran_ET12
./scripts/backup/linux/generar_dump_linux.sh bd_granet12_restauracion_20261020 scripts/backup/torneo.sql
```

En Windows:

```powershell
.\scripts\backup\win\generar_dump_win.bat bd_granet12_restauracion_20261020 scripts\backup\torneo.sql
```

Para regenerar el dump, usar una base de pruebas con datos exclusivamente ficticios. No hacer el dump de la base local original si contiene datos personales. El archivo exportado incluye esquema, datos de demostración, rutinas y triggers; no incluye cuentas MySQL ni credenciales.

## Permisos

El script `scripts/04 Usuarios.sql` tiene claves de ejemplo que deben reemplazarse localmente. En XAMPP MariaDB se comprobó que la cuenta `usuario` puede ejecutar `SELECT` y que `INSERT` es rechazado; el resultado está en [permisos.md](../produccion/permisos.md). Falta repetirlo en MySQL 8.
