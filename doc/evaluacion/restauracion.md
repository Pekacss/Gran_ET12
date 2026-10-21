# Restauración de la base

## Resultado

El 20/10/2026 generé `backup/torneo.sql` con `mysqldump` de XAMPP. Para no copiar datos personales de la base original, usé una base temporal que contiene solamente fixtures ficticios.

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

Con XAMPP iniciado, se puede restaurar en otra base de prueba vacía:

```powershell
$mysql = "C:\xampp\mysql\bin\mysql.exe"
& $mysql -u root -e "CREATE DATABASE bd_granet12_restore_test CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;"
& $mysql -u root bd_granet12_restore_test -e "source backup/torneo.sql"
& $mysql -u root -e "SELECT COUNT(*) FROM bd_granet12_restore_test.jugador;"
```

Para regenerar el dump, usar una base de pruebas con datos exclusivamente ficticios. No hacer el dump de la base local original si contiene datos personales. El archivo exportado incluye esquema, datos de demostración, rutinas y triggers; no incluye cuentas MySQL ni credenciales.

## Permisos

El script `scripts/04 Usuarios.sql` tiene claves de ejemplo que deben reemplazarse localmente. En XAMPP MariaDB se comprobó que la cuenta `usuario` puede ejecutar `SELECT` y que `INSERT` es rechazado; el resultado está en [permisos.md](../produccion/permisos.md). Falta repetirlo en MySQL 8.
