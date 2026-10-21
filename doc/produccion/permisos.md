# Permisos de MySQL

`scripts/04 Usuarios.sql` agrega usuarios ficticios de la aplicación y crea dos cuentas MySQL para `bd_GranET12`: `admin`, con todos los permisos sobre el esquema, y `usuario`, con permiso `SELECT` solamente.

Antes de ejecutarlo, reemplazar localmente `REEMPLAZAR_CLAVE_ADMIN` y `REEMPLAZAR_CLAVE_USUARIO` en una copia temporal del script. Ejecutarlo con una cuenta administradora de MySQL después de crear el esquema. No subir claves reales a Git.

## Comprobación

El 20/10/2026, en XAMPP MariaDB 10.4.32, una cuenta de prueba con permisos de usuario pudo consultar el total de equipos (4) y el `INSERT` fue rechazado con `ERROR 1142`. La cuenta temporal se eliminó luego de la prueba. Queda pendiente repetirlo en MySQL 8.

La matriz de acciones de la aplicación está en [matriz-usuarios.md](../matriz-usuarios.md). Los usuarios de MySQL no son roles HTTP.
