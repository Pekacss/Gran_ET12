# Actividad 1: Reglas, capas y pruebas pequeñas

En el proyecto, los modelos representan los datos y algunas reglas; los servicios validan operaciones y llaman a los repositorios; los repositorios se ocupan de consultar o guardar en MySQL; y los controladores reciben las solicitudes y devuelven respuestas HTTP.

En `Plantilla`, el modelo impide repetir un jugador entre titulares y suplentes. También calcula el presupuesto y controla la cantidad y la formación. `ServiceJugador` y `ServicePuntuacion` validan los datos antes de guardarlos.

## Prueba de concepto

Una ruta Minimal API puede devolver JSON así:

```csharp
app.MapGet("/api/prueba", () => Results.Json(new { correcto = true }));
```

La respuesta es `200 OK` con:

```json
{
  "correcto": true
}
```

Para documentar una API con Swagger se puede configurar `AddEndpointsApiExplorer`, `AddSwaggerGen`, `UseSwagger` y `UseSwaggerUI`. En este proyecto se usa OpenAPI y Scalar: `AddOpenApi`, `MapOpenApi` y `MapScalarApiReference`.

## Comparación con la hipótesis

La hipótesis de [PuntoDePartida/Act1/hipotesis.md](PuntoDePartida/Act1/hipotesis.md) proponía validar los datos al cargar jugadores y puntuaciones, y controlar el presupuesto y la formación al armar la plantilla. Esto coincide con la separación observada: las reglas del torneo corresponden al modelo o a los servicios, no al controlador. Así se pueden reutilizar y probar sin depender de HTTP.

- Para evitar repetir un futbolista, `Plantilla` revisa si ya figura como titular o suplente. La base de datos también puede reforzar esta regla con una restricción única.
- Si falta la puntuación de un jugador en una fecha, el cálculo actual de la plantilla suma cero por ese jugador.
- Validar datos significa revisar reglas del programa, como el rango de la puntuación. Verificar permisos MySQL significa comprobar qué operaciones permite la cuenta de base de datos. Son controles distintos.
- Las cuentas MySQL administrador e invitado no son roles de autenticación HTTP.
