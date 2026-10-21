# Evaluación: entregables

Comparación con el cuadro. Revisión del 20/10/2026.

| Entrega | Requisito | Estado |
| --- | --- | --- |
| #1, semana 2 | Hipótesis, contraste y contrato con doce endpoints | Los documentos completos están en `doc/Indagacion`. El contrato enumera diez operaciones; la pauta pide doce. No agregué rutas sin definición. |
| #2, semana 3 | Scripts SQL, permisos, proyectos por capas, repositorios Dapper y pruebas | Parcial. Existen esquema, procedimientos, triggers, datos, repositorios Dapper y pruebas. Se agregó script de cuentas y se verificó SELECT/INSERT con XAMPP MariaDB. Se ajustaron BCrypt, presupuesto y alta gradual de plantillas. Falta separar los proyectos y repetir permisos con MySQL 8. |
| #3, semana 5 | Doce endpoints, Swagger, pruebas o solicitudes HTTP | Parcial. La API publica OpenAPI y Scalar; aún no implementa todas las operaciones del contrato. El archivo `.http` solo contiene WeatherForecast. Faltan las dos rutas no especificadas, el recorrido HTTP y la verificación de estados. |
| #4, semana 6 | Backup restaurable, README, comprobación de restauración, reflexión y defensa | El backup ficticio `backup/torneo.sql` se generó con `mysqldump` y se restauró correctamente en MariaDB de XAMPP. Falta repetir la restauración en MySQL 8 y realizar la defensa oral. |

## Comprobaciones

- Las pruebas focalizadas de plantilla dieron 21/21; las de usuario y BCrypt, 10/10.
- La suite completa no terminó en verde porque los tests de repositorio no pudieron conectar con MySQL. En esta revisión se pudo iniciar MariaDB de XAMPP, pero no se repitió la suite completa después de los últimos ajustes.
- La API compiló correctamente, con cero advertencias y cero errores.
- El dump restaurado contiene ocho tablas y datos ficticios: 1 equipo, 2 usuarios, 15 futbolistas, 11 titulares, 4 suplentes y 11 puntuaciones. También se ejecutó correctamente `sp_Usuario_ObtenerTodos`.
- La cuenta MySQL `usuario` pudo consultar y el intento de `INSERT` fue rechazado con error 1142 en MariaDB de XAMPP.

## Pendiente

1. Aclarar cuáles son los endpoints 11 y 12.
2. Separar la solución en los proyectos pedidos y completar las rutas HTTP faltantes.
3. Verificar usuarios/permisos y restauración específicamente con MySQL 8.
4. Repetir la suite completa y completar las solicitudes de integración.
5. Realizar la demostración y defensa oral.
