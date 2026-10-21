# Producción

## Actividad 1: Datos y permisos

El esquema actual de `scripts/00 DDL.sql` incluye usuarios, equipos, futbolistas, posiciones, puntuaciones, plantillas y sus relaciones de titulares y suplentes. Ya tiene correo único, puntuación identificada por futbolista y fecha, fecha entre 1 y 49 y cotización hasta 99.999.999,99. `scripts/03 Inserts.sql` carga datos ficticios para probar.

La regla contra duplicados entre titulares y suplentes ya está implementada en `Plantilla.AgregarJugador` y en los triggers de `scripts/02 Triggers.sql`. La base también limita a 20 los jugadores de una plantilla.

El archivo `scripts/04 Usuarios.sql` agrega usuarios ficticios de la aplicación y crea dos cuentas MySQL: `admin`, con permisos completos sobre `bd_GranET12`, y `usuario`, con solo `SELECT`. Las claves de ejemplo deben reemplazarse localmente.

La comprobación se realizó en XAMPP MariaDB 10.4.32: una cuenta con permisos de `usuario` pudo consultar y el `INSERT` se rechazó con error 1142. El resultado está en [permisos.md](permisos.md); falta repetirlo en MySQL 8.

## Actividad 2: Modelo y servicios

El proyecto ya apunta a .NET 10. En `ProyectoCore` están los modelos, servicios y repositorios; los repositorios usan Dapper y las pruebas existentes usan xUnit. Sin embargo, todavía están agrupados en un solo proyecto. Para cumplir la consigna se deben separar en Dominio, Aplicación, Infraestructura, API y Pruebas, dejando las interfaces de repositorio en Aplicación y las implementaciones Dapper en Infraestructura.

Hay reglas ya implementadas, como el límite de cotización, la formación titular, la detección de jugadores repetidos y la puntuación cero cuando falta un registro. Se corrigió el alta de plantilla para permitir completar la formación después, y las pruebas de contraseña ahora aceptan el hash BCrypt que genera el servicio. Los tests de repositorios requieren MySQL; la suite completa no pudo terminar correctamente porque ese servidor no está disponible.

Correcciones realizadas en el programa:

- El presupuesto predeterminado ahora es 100.000.000, como pide la consigna.
- El alta de plantilla permite crearla antes de completar la formación titular; la validación completa corresponde al equipo ya armado.
- BCrypt genera hashes de 60 caracteres. Se quitó la exigencia incorrecta de longitud fija y se cambió la columna a `VARCHAR(64)` para almacenarlos sin relleno. Las contraseñas nunca se guardan en texto plano.

## Actividad 3: API y persistencia

La API existente usa controladores, servicios y repositorios. En desarrollo publica OpenAPI y Scalar para consultar la documentación. Todavía no implementa todas las operaciones del contrato con las rutas y estados acordados; por ejemplo, varios POST responden `200` en lugar de `201`.

La consigna menciona doce endpoints, pero el contrato de `doc/Indagacion/contrato-api.md` enumera diez. Para avanzar sin agregar rutas no solicitadas, se implementarán las diez operaciones enumeradas y se consultará cuáles serían las dos faltantes antes de inventarlas.

La conexión lee `ConnectionStrings:GranET12` desde configuración local o variables de entorno; se quitó la cadena de ejemplo del archivo versionado. Para cerrar la etapa hay que agregar solicitudes HTTP reproducibles para el recorrido completo y actualizar el README con inicio de MySQL, ejecución de la API, acceso a Scalar/OpenAPI y ejecución de pruebas.

## Orden de trabajo

1. Completar scripts de datos y permisos MySQL; comprobar lectura permitida y escritura denegada para `usuario`.
2. Separar los proyectos por capas y completar las reglas y pruebas pendientes.
3. Implementar las operaciones del contrato, verificar estados HTTP y probar el recorrido completo.
4. Documentar la ejecución y guardar una copia de la base con `mysqldump`, sin incluir credenciales.
