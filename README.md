TP - Gran ET12 ⚽
Relevamiento 📝
En esta ocasión, nos piden realizar una librería para el backend de una aplicación de simulación de un torneo ficticio, con jugadores reales. Una modalidad parecida al Gran DT.
De los futbolistas se almacenan nombres, apellidos, apodo (opcional), fecha de nacimiento  y equipo al que pertenece. A su vez, cada jugador posee una cotización, es decir, el monto de contratarlo en las plantillas de los usuarios. El monto máximo es de $99.999.999,99 y se estima que hay un máximo de 1500 jugadores en total. Además de cada futbolista se conoce el tipo de jugador (Arquero, Defensor, Mediocampista, Delantero).
De los equipos se almacena el nombre y se sabe que no hay más de 32 equipos. Los nombres no se pueden repetir
De nuestros usuarios, es importante conocer su nombre, apellido, email (único por cada usuario), fecha de nacimiento y contraseña. El sistema deberá soportar hasta 2000 usuarios. Es importante tener en cuenta que para la persistencia del usuario, mediante un algoritmo de encriptación, todas las contraseñas tendrán una longitud fija de 64 caracteres.
Ahora bien, nuestros Usuarios son capaces de generar sus Plantillas. Se sabe que hay un monto máximo de presupuesto que es igual para todas las plantillas al igual que una cantidad máxima de jugadores a incluir (actualmente 20, pero esta cantidad puede variar). Para esta primera iteración es importante tener en cuenta que para que una plantilla sea válida, en el equipo titular tiene que haber:
1 Arquero
4 Defensores
4 Mediocampistas
2 Delanteros

Cada plantilla tiene que ser capaz de soportar una colección de jugadores titulares, otra suplente y tiene que ser capaz de saber si es válida en presupuesto, si es valida con los requerimientos de los tipos de jugador. Tiene que poder devolver el presupuesto que maneja entre las cotizaciones de los jugadores que la componen.
Para cada jugador, se va a ir cargando fecha a fecha (número entero menor a 50), una puntuación (nota decimal del 1 al 10). Es importante saber que un jugador no puede tener 2 puntuaciones para una misma fecha y que existe la posibilidad de que no tenga puntuación/registro para una determinada fecha (esto representa que no jugó esa fecha). En base a esto, una plantilla tiene que ser capaz de: Para una fecha determinada, dar el puntaje correspondiente entendiéndolo como la sumatoria de puntajes de jugadores titulares para esa fecha determinada (plantilla.PuntajeFecha(4)).
Para la carga de las puntuaciones, ciertos usuarios especiales (Administradores) pueden ingresar al sistema de igual manera que los usuarios comunes, solo que a través de un aplicativo de escritorio. La función de estos va a ser crear futbolistas y cargar sus puntuaciones.
Requisitos Funcionales 🎯
Se pide desarrollar un proyecto integro donde aplique los conocimientos adquiridos en el espacio de integración Desarrollo.
Van a tener que desarrollar un proyecto de software que cumpla con:
Tener la lógica de negocio y modelo en un proyecto de Biblioteca de clases.
Tener la GUI en otro proyecto; tiene que ser funcional con los requisitos que se planteen en cada uno de los planes de aprendizaje.
Esta lógica de negocios tiene que poder persistir y leer información en una BD Relacional (MySQL). La recomendación es implementar 
Tiene que estar documentado siguiendo las normas y técnicas vistas durante la cursada de Desarrollo.
Alcances 📏
Se va a calificar en función del avance registrado, entendiéndolo como el correcto funcionamiento de visualización, modelado y persistencia (además de su adecuada documentación) para:
Aprobación Suficiente: mapeo, visualización y funcionamiento del loguin, junto con un caso de “muchos a uno” en persistencia.
Aprobación avanzado: lo anterior, más un caso de muchos a muchos (agregar Futbolistas a las plantillas y poder visualizar por Usuario, su plantilla).
Forma de Trabajo 🛠️
Presentación 🎁
La solución de este TP tiene que estar subida en un repositorio Público de Github, donde además tiene que mantener la siguiente estructura:

|
| README.md (completo con sus datos)
|
| scripts
	|
	| 00 DDL.sql (archivo que crea su BD)
	| 01 SP.sql (archivo que contiene sus definiciones de Funcs. y Procs. Almacenados)
	| 02 Triggers.sql (archivo que contiene sus triggers)
	| 03 Inserts.sql (archivo con algunos INSERTS)
	| 04 Usuarios.sql (archivo que crea los usuarios y permisos de su proyecto)
|
| Archivo .sln
|
| Proyecto.Core (carpeta de su proyecto de biblio de clases, cambiar Proyecto por el nombre del suyo)
	| Archivos de su proyecto
|

|
| Proyecto Minimal API
	| Archivos de su proyecto
|
| doc (carpeta para guardar documentación)
	|
| DER.png (Diagrama entidad relación)
	| Diagrama de Clases.png
	| Bitacora.md/xls
|

Sobre las tecnologías 💻
Para el desarrollo de este proyecto, se tiene que usar las tecnologías vistas en clase.
C# compilado mediante el SDK .NET versión 8 (la LST).
MySQL 8.0.X
Para poder tener una visión integrada del proyecto, les recomendamos trabajar con el editor VSCode. Si van a tener que usar el IDE Visual Studio para el diseño y programación de los formularios en WinForms.
Con respecto a la elaboración de la documentación, pueden optar por imágenes estáticas o documentación proveniente de Mermaid.js
Bitácora 📋
Es importante para la evaluación de este proyecto, llevar la bitácora al día, una tabla de doble entrada donde figuren la fecha, y las acciones que cada integrante realizó para la ejecución del mismo.
Evaluación 🧾
Para la aprobación de este trabajo, se debe cumplir con:
El mismo tiene que estar armado como se describió en su correspondiente repositorio respetando el formato mencionado.
Se tiene que cumplir con los requisitos funcionales establecidos para cada nivel de profundidad solicitado.
La documentación tiene que estar presentada en tiempo y forma.
Una vez que se verifique el cumplimiento de los puntos anteriores, se procede a la presentación y defensa oral/escrita del TP (según adecuación del plan).
