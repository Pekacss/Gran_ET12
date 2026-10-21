# Matriz de usuarios

La matriz separa permisos por clase y por acción. `Admin` es el usuario de aplicación con `Usuario.Administrador = true`; `Usuario` es una cuenta común (`false`). “Propias” significa que el usuario común solo opera sobre sus datos o plantillas.

Estos permisos describen la regla prevista. La API todavía no implementa autenticación y autorización HTTP para hacerlos cumplir.

## Usuario

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | Sí, al registrarse |
| Ver | Todos | Solo su cuenta |
| Modificar | Todas las cuentas | Solo sus datos |
| Eliminar | Todas las cuentas | Solo su cuenta |

## Equipo

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Posicion

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Jugador (futbolista)

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar datos y cotización | Sí | No |
| Eliminar | Sí | No |

## Puntuacion

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Plantilla

| Acción | Admin | Usuario |
| --- | --- | --- |
| Crear | Sí | Sí, propia |
| Ver | Todas | Solo propias |
| Modificar | Todas | Solo propias |
| Eliminar | Todas | Solo propias |

## PlantillaTitular

| Acción | Admin | Usuario |
| --- | --- | --- |
| Agregar titular | Sí | Sí, en plantilla propia |
| Ver titulares | Sí | Sí, en plantilla propia |
| Cambiar condición | Sí | Sí, en plantilla propia |
| Quitar titular | Sí | Sí, en plantilla propia |

## PlantillaSuplente

| Acción | Admin | Usuario |
| --- | --- | --- |
| Agregar suplente | Sí | Sí, en plantilla propia |
| Ver suplentes | Sí | Sí, en plantilla propia |
| Cambiar condición | Sí | Sí, en plantilla propia |
| Quitar suplente | Sí | Sí, en plantilla propia |

## Cuentas MySQL

Las cuentas de MySQL son independientes de los usuarios de la aplicación y no son roles HTTP. El script [04 Usuarios.sql](../scripts/04%20Usuarios.sql) configura:

| Cuenta MySQL | Crear/leer/modificar/eliminar datos | Administrar esquema |
| --- | --- | --- |
| `admin` | Sí | Sí, solo en `bd_GranET12` |
| `usuario` | Solo lectura (`SELECT`) | No |

Las claves del script son marcadores de ejemplo: deben reemplazarse localmente y nunca subirse a Git.
