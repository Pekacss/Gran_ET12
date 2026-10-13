# Punto de partida: Actividad 1

## Situación

Un usuario arma una plantilla con futbolistas y consulta los puntos obtenidos por sus titulares en una fecha. Este es un modelo inicial para pensar qué datos y reglas se necesitan antes de definir la solución.

## Objetos y datos

- **Usuario:** nombre, apellido y correo. Puede crear plantillas.
- **Jugador:** nombre, apellido, apodo opcional, fecha de nacimiento, equipo, posición y cotización.
- **Plantilla:** nombre, usuario que la creó, presupuesto disponible y jugadores elegidos.
- **Titular y suplente:** indican el rol con el que un jugador forma parte de la plantilla.
- **Puntuación:** jugador, fecha y nota. Puede no haber una puntuación para cada fecha.

## ¿Qué podría salir mal?

- Elegir dos veces al mismo jugador o superar el presupuesto o la cantidad máxima.
- Armar una formación con posiciones incorrectas o incompleta.
- Cargar una nota fuera del rango permitido o repetir la puntuación de un jugador para la misma fecha.
- Consultar el puntaje de una fecha en la que el jugador no tiene puntuación.

## Hipótesis sobre dónde controlar las reglas

1. **Datos del jugador:** se podrían controlar al registrarlo, para no guardar información incompleta.
2. **Puntaje y fecha:** se podrían validar al cargar la puntuación y evitar que se repita jugador y fecha.
3. **Presupuesto y cantidad de integrantes:** se podrían revisar cuando se agrega un jugador.
4. **Formación titular:** se podría comprobar al confirmar la plantilla, porque depende del conjunto de titulares y sus posiciones.

Son ideas iniciales, no decisiones definitivas.

## Dudas para investigar

- ¿Cuál es el presupuesto máximo y cómo se define el máximo de jugadores?
- ¿La formación pedida se exige solo a los titulares? ¿Hay límites para los suplentes?
- Si un jugador no tiene puntuación en una fecha, ¿se considera cero?
- ¿Un jugador puede estar en plantillas de distintos usuarios?
- ¿Dónde conviene controlar cada regla?

## Recorrido de las solicitudes

El diagrama muestra solamente dos acciones: agregar un jugador como titular a una plantilla y consultar el puntaje de un jugador. En ambos casos se ve el recorrido desde la API hasta el repositorio; no se incluye la base de datos ni SQL.

[Diagram.png]

## Observaciones del código actual

- Para agregar un titular intervienen `PlantillaTitularController`, `ServicePlantillaTitular`, `IRepoPlantillaTitular` y `RepoPlantillaTitular`.
- Para consultar un puntaje por jugador y fecha intervienen `PuntuacionController`, `ServicePuntuacion`, `IRepoPuntuacion` y `RepoPuntuacion`.
- El servicio de titulares exige que `Id` sea distinto de cero, aunque el repositorio genera ese identificador al guardar. Conviene revisar esa validación.
- Los servicios reciben una interfaz de repositorio y delegan en ella; también están declarados como implementaciones de esa interfaz.
