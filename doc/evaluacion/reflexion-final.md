# Reflexión final

Al comienzo, en [hipotesis.md](../Indagacion/hipotesis.md), propuse validar los datos del futbolista y la puntuación al cargarlos, y revisar el presupuesto y la formación al armar la plantilla.

Mantuve esa separación: el modelo `Plantilla` controla formación, presupuesto, cantidad y jugadores repetidos; los servicios validan operaciones y delegan la persistencia; los repositorios usan Dapper y MySQL; los controladores traducen las solicitudes HTTP. También confirmé que `scripts/02 Triggers.sql` impide repetir un futbolista entre titulares y suplentes y limita el total de jugadores.

Ajusté dos decisiones al probar el programa. Primero, una plantilla se crea antes de completar su formación, por eso el servicio no debe exigir la formación final en el alta. La validez completa se comprueba cuando se evalúa el equipo armado. Segundo, BCrypt produce hashes de 60 caracteres; no corresponde exigir 64 solo porque la columna se definió con ese tamaño. Se cambió la columna a `VARCHAR(64)` y se valida que la contraseña guardada no esté vacía.

El modelo ahora usa un presupuesto predeterminado de 100.000.000. Si falta la puntuación de un titular en una fecha, el cálculo suma cero. Las cuentas MySQL son distintas de los usuarios de la aplicación y no representan roles HTTP.

Aprendí que una regla importante debe probarse tanto en el modelo/servicio como en la persistencia cuando corresponda. El backup se restauró en una base temporal de XAMPP y los permisos de la cuenta MySQL `usuario` se comprobaron con una lectura permitida y un `INSERT` rechazado. XAMPP ejecuta MariaDB 10.4, así que falta repetirlo en MySQL 8. La suite completa de repositorios no se repitió después de iniciar la base y la demostración de la API en Scalar queda pendiente.
