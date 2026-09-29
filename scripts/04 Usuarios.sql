USE bd_GranET12;

-- Clave de prueba para ambas cuentas: GranDT2026!.
INSERT INTO Usuario (Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena)
VALUES
	(2, 'Usuario', 'Prueba', 'usuario@example.com', '2000-06-15', FALSE,
	 'ICEiIyQlJicoKSorLC0uL1YXIfaj4ChlWCVJCVHLCzWkyZTAxCaJxKiyObVhDzOG'),
	(3, 'Admin', 'Prueba', 'admin@example.com', '1990-03-20', TRUE,
	 'EBESExQVFhcYGRobHB0eH7VzaYlIdpEw5wia3E3ftV8sNo0vjddLZD/YwSDeFfdz')
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre), Apellido = VALUES(Apellido),
	FechaNacimiento = VALUES(FechaNacimiento), Administrador = VALUES(Administrador),
	Contrasena = VALUES(Contrasena);
