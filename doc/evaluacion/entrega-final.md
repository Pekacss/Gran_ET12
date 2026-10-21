# Entrega final

Este documento reúne los resultados y enlaza los entregables completos, organizados por etapa.

## Indagación

Se compararon las hipótesis iniciales con la arquitectura y las reglas del proyecto. El modelo y los servicios se ocupan de las reglas del torneo; los controladores traducen HTTP y los repositorios acceden a MySQL. El contrato disponible enumera diez rutas, aunque la pauta menciona doce; no se inventaron las dos faltantes.

- [Hipótesis](../Indagacion/hipotesis.md)
- [Contraste de reglas, capas y prueba de concepto](../Indagacion/contraste.md)
- [Contrato de la API](../Indagacion/contrato-api.md)

## Producción

El proyecto ya usa .NET 10, Dapper, MySQL, modelos, servicios, repositorios, pruebas y controladores. Se ajustaron el presupuesto predeterminado a 100 millones, la creación gradual de plantillas y el manejo de hashes BCrypt. Se agregó un script de permisos MySQL con claves de ejemplo para reemplazar localmente.

- [Resolución de producción](../produccion/resolucion.md)
- [Matriz de usuarios](../matriz-usuarios.md)
- [Permisos MySQL](../produccion/permisos.md)

## Evaluación

Se generó `backup/torneo.sql` desde una base temporal con datos ficticios y se restauró en MariaDB 10.4 de XAMPP. Se verificaron ocho tablas, sus conteos y un procedimiento almacenado. También se comprobó que la cuenta de lectura puede consultar y que el `INSERT` se rechaza con error 1142. Falta repetir en MySQL 8.

Las pruebas focalizadas dieron 21/21 para plantilla y 10/10 para usuario/BCrypt. La suite completa de repositorios requiere MySQL. La API compiló sin advertencias ni errores.

- [Estado frente al cuadro de entregas](entregas.md)
- [Resultado de restauración](restauracion.md)
- [Reflexión final](reflexion-final.md)

## Pendiente

- Definir las dos rutas que faltan en la pauta de doce endpoints.
- Separar el proyecto en las cinco capas indicadas y completar las rutas HTTP.
- Repetir permisos, restauración y pruebas en MySQL 8.
- Demostrar la API y realizar la defensa oral.
