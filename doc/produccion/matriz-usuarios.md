# Matriz de usuarios

En el sistema hay que distinguir los usuarios de la aplicación de las cuentas de MySQL. No existe un perfil de invitado.

## Usuarios de la aplicación

La propiedad `Usuario.Administrador` separa al administrador (`true`) del usuario común (`false`). La API actual todavía no implementa autenticación y autorización para aplicar esta matriz; describe las acciones previstas para el sistema.

| Acción | Administrador | Usuario común |
| --- | --- | --- |
| Consultar equipos, futbolistas, cotizaciones y puntuaciones | Sí | Sí |
| Crear o actualizar futbolistas y sus cotizaciones | Sí | No |
| Cargar puntuaciones | Sí | No |
| Crear una plantilla propia | Sí | Sí |
| Incorporar futbolistas a una plantilla propia | Sí | Sí |
| Cambiar titular/suplente en una plantilla propia | Sí | Sí |
| Consultar puntaje y validez de una plantilla propia | Sí | Sí |
| Modificar plantillas de otro usuario | No | No |
| Administrar cuentas o permisos de MySQL | No | No |

## Cuentas de MySQL

Estas cuentas controlan acceso a la base de datos; no son roles HTTP ni reemplazan las reglas de la aplicación.

| Cuenta | Permitido en `bd_GranET12` | No permitido |
| --- | --- | --- |
| `admin` | Lectura, escritura y administración del esquema del proyecto | Acceso fuera de `bd_GranET12` |
| `usuario` | `SELECT` sobre las tablas del esquema | `INSERT`, `UPDATE`, `DELETE`, DDL y cambios de permisos |

`scripts/04 Usuarios.sql` crea esas dos cuentas. Antes de ejecutarlo hay que reemplazar `REEMPLAZAR_CLAVE_ADMIN` y `REEMPLAZAR_CLAVE_USUARIO` en una copia local. No se deben subir credenciales reales.
