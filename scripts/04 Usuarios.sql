USE bd_GranET12;

-- Clave de prueba para ambas cuentas: GranDT2026!.
INSERT INTO Usuario (Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena)
VALUES
	(2, 'Usuario', 'Prueba', 'usuario@example.com', '2000-06-15', FALSE,
	 'AAECAwQFBgcICQoLDA0OD6rgwt0MEpg/NlUUoMDIbyUp6SpMTiYtLJ2k5Ak0b0iZ'),
	(3, 'Admin', 'Prueba', 'admin@example.com', '1990-03-20', TRUE,
	 'EBESExQVFhcYGRobHB0eH7VzaYlIdpEw5wia3E3ftV8sNo0vjddLZD/YwSDeFfdz')
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre), Apellido = VALUES(Apellido),
	FechaNacimiento = VALUES(FechaNacimiento), Administrador = VALUES(Administrador),
	Contrasena = VALUES(Contrasena);

-- MySQL 8 genera la contraseña aleatoria y la muestra al ejecutar el script.
-- Guardarla para completar ConnectionStrings:GranET12 en appsettings.Development.json.
CREATE USER IF NOT EXISTS 'gran_et12_app'@'localhost' IDENTIFIED BY RANDOM PASSWORD;
GRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE ON bd_GranET12.* TO 'gran_et12_app'@'localhost';
