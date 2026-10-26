# Matriz de usuarios

`Admin`: `Usuario.Administrador = true`. `Usuario`: valor `false`. La matriz describe las reglas previstas; la API aún no aplica autorización HTTP.

**Leyenda:** Sí = permitido · No = prohibido · Propias = solo datos o plantillas del usuario.

## Usuario

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear cuenta | Sí | Sí |
| Ver cuentas | Todas | Propias |
| Modificar cuenta | Todas | Propias |
| Eliminar cuenta | Todas | Propias |

## Equipo

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Posicion

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Jugador (futbolista)

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar datos o cotización | Sí | No |
| Eliminar | Sí | No |

## Puntuacion

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear | Sí | No |
| Ver | Sí | Sí |
| Modificar | Sí | No |
| Eliminar | Sí | No |

## Plantilla

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Crear | Sí | Propias |
| Ver | Todas | Propias |
| Modificar | Todas | Propias |
| Eliminar | Todas | Propias |

## PlantillaTitular

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Agregar titular | Sí | En propias |
| Ver titulares | Sí | En propias |
| Cambiar condición | Sí | En propias |
| Quitar titular | Sí | En propias |

## PlantillaSuplente

| Acción | Admin | Usuario |
|:--|:--:|:--:|
| Agregar suplente | Sí | En propias |
| Ver suplentes | Sí | En propias |
| Cambiar condición | Sí | En propias |
| Quitar suplente | Sí | En propias |

## Cuentas MySQL

Estas cuentas son independientes de los usuarios de la aplicación y no son roles HTTP. Las claves de ejemplo de [04 Usuarios.sql](../scripts/04%20Usuarios.sql) deben reemplazarse localmente.

| Cuenta | Leer datos | Escribir datos | Administrar esquema |
|:--|:--:|:--:|:--:|
| `admin` | Sí | Sí | Sí, solo `bd_GranET12` |
| `usuario` | Sí (`SELECT`) | No | No |
