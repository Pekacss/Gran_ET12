# Punto de partida: Actividad 1

## Situación
Un usuario arma una plantilla con futbolistas y consulta los puntos obtenidos por sus titulares en una fecha. Antes de definir la solución, este modelo reúne las primeras ideas sobre los datos y las reglas. Es un borrador para revisar durante el proyecto.

## Objetos y datos
- **Usuario:** nombre, apellido y correo. Puede crear una o más plantillas.
- **Jugador:** nombre, apellido, apodo opcional, fecha de nacimiento, equipo, posición y cotización.
- **Plantilla:** nombre, usuario que la creó, presupuesto disponible y jugadores elegidos.
- **Integrante de plantilla:** relaciona un jugador con una plantilla e indica si es titular o suplente. El rol pertenece a la elección del usuario, no a los datos propios del futbolista.
- **Puntuación:** jugador, fecha y nota. Un jugador puede no tener puntuación en una fecha.

## ¿Qué podría salir mal?
- Elegir dos veces al mismo jugador o superar el presupuesto o la cantidad máxima.
- Armar una formación con posiciones incorrectas o con jugadores faltantes.
- Cargar una nota fuera del rango permitido o registrar dos notas para el mismo jugador en una fecha.
- Consultar una fecha en la que algún titular no tenga una puntuación cargada.

## Hipótesis sobre dónde controlar las reglas
1. **Datos obligatorios del jugador:** supongo que se controlan al registrar al jugador, para evitar guardar información incompleta.
2. **Puntaje y fecha:** supongo que se validan al cargar la puntuación; además, el sistema de guardado debe impedir dos puntuaciones del mismo jugador para una fecha.
3. **Presupuesto y cantidad de integrantes:** supongo que se revisan al agregar un jugador a la plantilla, para avisar el problema en ese momento.
4. **Formación titular:** supongo que se comprueba cuando se confirma la plantilla, porque depende del conjunto completo de titulares y sus posiciones.

Estas son ideas iniciales, no decisiones definitivas. Habrá que confirmar dónde conviene aplicar cada control.

## Dudas para investigar
- ¿Cuál es el presupuesto máximo y cómo se define el máximo de jugadores?
- ¿La formación indicada se exige solo a los titulares? ¿Hay límites para los suplentes?
- Si un titular no tiene puntuación en una fecha, ¿se cuenta como cero o se deja sin registro?
- ¿Un mismo jugador puede estar en plantillas de distintos usuarios?
- ¿Las reglas se controlan en un solo lugar o también al guardar los datos?
