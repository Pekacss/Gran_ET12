# Punto de partida: hipótesis

## Situación

Un usuario arma una plantilla con futbolistas y consulta los puntos obtenidos por sus titulares en una fecha. Este modelo inicial sirve para pensar los datos y las reglas antes de definir la solución.

## Objetos y datos

- **Usuario:** nombre, apellido y correo. Puede crear plantillas.
- **Futbolista:** nombre, apellido, apodo opcional, fecha de nacimiento, equipo, posición y cotización.
- **Plantilla:** nombre, usuario que la creó, presupuesto disponible y futbolistas elegidos.
- **Titular y suplente:** indican la condición del futbolista en la plantilla.
- **Puntuación:** futbolista, fecha y nota. Puede no haber una puntuación para cada fecha.

## Problemas posibles

- Elegir dos veces al mismo futbolista o superar el presupuesto o la cantidad máxima.
- Armar una formación con posiciones incorrectas o incompleta.
- Cargar una nota fuera del rango permitido o repetir la puntuación de un futbolista en una fecha.
- Consultar el puntaje de una fecha en la que falta una puntuación.

## Hipótesis sobre dónde controlar las reglas

1. Validar los datos del futbolista al registrarlo.
2. Validar fecha y puntaje al cargar una puntuación y evitar repetir futbolista y fecha.
3. Revisar presupuesto y cantidad de integrantes al agregar futbolistas.
4. Comprobar la formación titular cuando se confirma la plantilla, porque depende del conjunto de titulares y sus posiciones.

Son hipótesis iniciales que se revisarán al implementar y probar el programa.
