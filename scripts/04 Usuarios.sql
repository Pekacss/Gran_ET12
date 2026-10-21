USE bd_GranET12;

-- Usuarios ficticios de la aplicacion; las contrasenas ya estan almacenadas como hashes.
INSERT INTO Usuario (Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena)
VALUES
	(2, 'Usuario', 'Prueba', 'usuario@example.com', '2000-06-15', FALSE,
	 'ICEiIyQlJicoKSorLC0uL1YXIfaj4ChlWCVJCVHLCzWkyZTAxCaJxKiyObVhDzOG'),
	(3, 'Admin', 'Prueba', 'admin@example.com', '1990-03-20', TRUE,
	 'EBESExQVFhcYGRobHB0eH7VzaYlIdpEw5wia3E3ftV8sNo0vjddLZD/YwSDeFfdz');

-- Reemplazar ambas contrasenas de ejemplo antes de ejecutar.
-- Ejecutar con una cuenta administradora de MySQL despues de crear bd_GranET12.
-- No guardar contrasenas reales en el repositorio.

DROP USER IF EXISTS 'torneo_admin'@'localhost';
DROP USER IF EXISTS 'torneo_invitado'@'localhost';

CREATE USER IF NOT EXISTS 'admin'@'localhost'
    IDENTIFIED BY 'REEMPLAZAR_CLAVE_ADMIN';
CREATE USER IF NOT EXISTS 'usuario'@'localhost'
	IDENTIFIED BY 'REEMPLAZAR_CLAVE_USUARIO';

REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'admin'@'localhost';
REVOKE ALL PRIVILEGES, GRANT OPTION FROM 'usuario'@'localhost';

GRANT ALL PRIVILEGES ON bd_GranET12.* TO 'admin'@'localhost';
GRANT SELECT ON bd_GranET12.* TO 'usuario'@'localhost';

SHOW GRANTS FOR 'admin'@'localhost';
SHOW GRANTS FOR 'usuario'@'localhost';