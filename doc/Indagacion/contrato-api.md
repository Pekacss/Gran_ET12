# Actividad 2: Contrato de la API

Este contrato propone las operaciones indicadas en la consigna. Los nombres de los datos siguen los modelos del proyecto (`Jugador`, `Usuario`, `Plantilla` y `Puntuacion`). Las respuestas son ejemplos. Las rutas se conservan porque la consigna las especifica; actualmente los controladores usan `api/[controller]` y no todas estas operaciones están implementadas.

En escrituras: `400` indica datos inválidos; `404`, un recurso inexistente; y `409`, un duplicado cuando corresponda. Las cuentas MySQL administrador e invitado no son roles de autenticación HTTP. Los estados `201` de las altas son los acordados para este contrato; actualmente algunos controladores responden `200`.

## 1. GET /api/equipos

Sin entrada. Devuelve `200 OK`:

```json
[{ "id": 1, "nombre": "River Plate" }]
```

## 2. GET /api/futbolistas

Sin entrada. Devuelve `200 OK`, con equipo y cotización:

```json
[{ "id": 10, "nombre": "Franco", "apellido": "Armani", "idEquipo": 1, "equipo": "River Plate", "cotizacion": 14500000.00 }]
```

## 3. POST /api/futbolistas

Entrada: nombre, apellido, fecha de nacimiento, `idEquipo`, `idPosicion` y cotización; apodo es opcional.

```json
{ "nombre": "Kevin", "apellido": "Lomonaco", "fechaNacimiento": "2002-01-08", "idEquipo": 3, "idPosicion": 2, "cotizacion": 9800000.00 }
```

Devuelve `201 Created`:

```json
{ "id": 54, "nombre": "Kevin", "apellido": "Lomonaco", "fechaNacimiento": "2002-01-08", "idEquipo": 3, "idPosicion": 2, "cotizacion": 9800000.00 }
```

Errores: `400` datos inválidos; `409` si está duplicado.

## 4. PUT /api/futbolistas/{id}

Entrada: equipo y cotización nuevos.

```json
{ "idEquipo": 5, "cotizacion": 11200000.00 }
```

Devuelve `200 OK`:

```json
{ "id": 54, "nombre": "Kevin", "apellido": "Lomonaco", "idEquipo": 5, "equipo": "Independiente", "cotizacion": 11200000.00 }
```

Errores: `400` datos inválidos; `404` futbolista inexistente.

## 5. POST /api/usuarios

Entrada: nombre, apellido, email, fecha de nacimiento y contraseña. El servicio guarda la contraseña con hash.

```json
{ "nombre": "Lucia", "apellido": "Perez", "email": "lucia@example.com", "fechaNacimiento": "2001-04-19", "contrasena": "clave" }
```

Devuelve `201 Created` sin incluir la contraseña:

```json
{ "id": 101, "nombre": "Lucia", "apellido": "Perez", "email": "lucia@example.com", "fechaNacimiento": "2001-04-19", "administrador": false }
```

Errores: `400` datos inválidos; `409` email duplicado.

## 6. POST /api/futbolistas/{id}/puntuaciones

Entrada: fecha y puntaje.

```json
{ "fecha": 8, "puntaje": 7.5 }
```

Devuelve `201 Created`:

```json
{ "fecha": 8, "idJugador": 54, "puntaje": 7.5 }
```

Errores: `400` datos inválidos; `404` futbolista inexistente; `409` puntuación ya registrada para esa fecha.

## 7. GET /api/usuarios/{id}/plantillas

Sin entrada adicional. Devuelve `200 OK`:

```json
[{ "id": 300, "idUsuario": 101, "fecha": 8, "nombre": "Fecha 8" }]
```

Error: `404` usuario inexistente.

## 8. POST /api/usuarios/{id}/plantillas

Entrada: fecha y nombre de la plantilla.

```json
{ "fecha": 8, "nombre": "Fecha 8" }
```

Devuelve `201 Created`:

```json
{ "id": 300, "idUsuario": 101, "fecha": 8, "nombre": "Fecha 8" }
```

Errores: `400` datos inválidos; `404` usuario inexistente.

## 9. POST /api/plantillas/{id}/jugadores

Entrada: jugador y condición de titular o suplente.

```json
{ "idJugador": 54, "titular": true }
```

Devuelve `200 OK` con la plantilla actualizada:

```json
{ "id": 300, "idUsuario": 101, "titulares": [{ "id": 54, "nombre": "Kevin", "apellido": "Lomonaco" }], "suplentes": [] }
```

Errores: `400` datos o reglas de plantilla inválidos; `404` plantilla o futbolista inexistente; `409` futbolista repetido.

## 10. PUT /api/plantillas/{id}/jugadores/{futbolistaId}

Entrada: nueva condición.

```json
{ "titular": false }
```

Devuelve `200 OK`:

```json
{ "id": 300, "idUsuario": 101, "titulares": [], "suplentes": [{ "id": 54, "nombre": "Kevin", "apellido": "Lomonaco" }] }
```

Errores: `400` condición inválida; `404` plantilla inexistente o futbolista que no pertenece a ella.
