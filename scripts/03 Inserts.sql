USE bd_GranET12;

-- Usuario base requerido por la plantilla de prueba; la clave de prueba es GranDT2026!.
INSERT INTO Usuario (Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena)
VALUES (1, 'Usuario', 'Demo', 'demo.plantilla@example.com', '2000-01-01', FALSE,
		'AAECAwQFBgcICQoLDA0OD6rgwt0MEpg/NlUUoMDIbyUp6SpMTiYtLJ2k5Ak0b0iZ')
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre), Apellido = VALUES(Apellido),
	FechaNacimiento = VALUES(FechaNacimiento), Administrador = VALUES(Administrador),
	Contrasena = VALUES(Contrasena);

INSERT INTO Posicion (Id, Nombre) VALUES
	(1, 'Arquero'),
	(2, 'Defensor'),
	(3, 'Mediocampista'),
	(4, 'Delantero')
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre);

INSERT INTO Equipo (Id, Nombre) VALUES
	(1, 'River Plate'),
	(2, 'Boca Juniors'),
	(3, 'Racing Club')
ON DUPLICATE KEY UPDATE Nombre = VALUES(Nombre);

INSERT IGNORE INTO Jugador
	(Id, Nombre, Apellido, Apodo, FechaNacimiento, IdEquipo, Cotizacion, IdPosicion)
VALUES
	(1, 'Franco', 'Armani', 'Pulpo', '1986-10-16', 1, 5000000.00, 1),
	(2, 'Milton', 'Casco', '', '1988-04-11', 1, 3000000.00, 2),
	(3, 'Paulo', 'Diaz', '', '1994-08-25', 1, 4500000.00, 2),
	(4, 'Leandro', 'Gonzalez Pirez', '', '1992-02-26', 1, 2500000.00, 2),
	(5, 'Enzo', 'Diaz', '', '1995-12-07', 1, 3500000.00, 2),
	(6, 'Enzo', 'Perez', '', '1986-02-22', 1, 2000000.00, 3),
	(7, 'Ignacio', 'Fernandez', 'Nacho', '1990-01-12', 1, 4200000.00, 3),
	(8, 'Nicolas', 'De La Cruz', '', '1997-06-01', 1, 6000000.00, 3),
	(9, 'Esequiel', 'Barco', '', '1999-03-29', 1, 5500000.00, 3),
	(10, 'Miguel', 'Borja', '', '1993-01-26', 1, 6500000.00, 4),
	(11, 'Pablo', 'Solari', '', '2001-03-22', 1, 5000000.00, 4),
	(12, 'Sergio', 'Romero', 'Chiquito', '1987-02-22', 2, 3000000.00, 1),
	(13, 'Marcos', 'Rojo', '', '1990-03-20', 2, 3500000.00, 2),
	(14, 'Juan', 'Quintero', '', '1993-01-18', 3, 4000000.00, 3),
	(15, 'Adrian', 'Martinez', 'Maravilla', '1992-07-07', 3, 5200000.00, 4);

INSERT IGNORE INTO Plantilla (Id, IdUsuario, Fecha, Nombre)
VALUES (1, 1, 1, 'Plantilla demo');

INSERT IGNORE INTO PlantillaTitular (Id, IdPlantilla, IdJugador) VALUES
	(1, 1, 1), (2, 1, 2), (3, 1, 3), (4, 1, 4), (5, 1, 5),
	(6, 1, 6), (7, 1, 7), (8, 1, 8), (9, 1, 9), (10, 1, 10), (11, 1, 11);

INSERT IGNORE INTO PlantillaSuplente (Id, IdPlantilla, IdJugador) VALUES
	(1, 1, 12), (2, 1, 13), (3, 1, 14), (4, 1, 15);

INSERT IGNORE INTO Puntuacion (Fecha, IdJugador, Puntaje) VALUES
	(1, 1, 8.0), (1, 2, 7.0), (1, 3, 6.5), (1, 4, 7.5), (1, 5, 6.0),
	(1, 6, 6.5), (1, 7, 8.5), (1, 8, 9.0), (1, 9, 7.0), (1, 10, 8.0), (1, 11, 7.5);
