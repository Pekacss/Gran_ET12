USE bd_GranET12;

DROP PROCEDURE IF EXISTS sp_Usuario_Agregar;
DROP PROCEDURE IF EXISTS sp_Usuario_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Usuario_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_Usuario_ObtenerPorEmail;
DROP PROCEDURE IF EXISTS sp_Usuario_Eliminar;
DROP PROCEDURE IF EXISTS sp_Equipo_Agregar;
DROP PROCEDURE IF EXISTS sp_Equipo_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Equipo_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_Equipo_ObtenerJugadores;
DROP PROCEDURE IF EXISTS sp_Equipo_Eliminar;
DROP PROCEDURE IF EXISTS sp_Posicion_Agregar;
DROP PROCEDURE IF EXISTS sp_Posicion_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Posicion_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_Posicion_ObtenerJugadores;
DROP PROCEDURE IF EXISTS sp_Posicion_Eliminar;
DROP PROCEDURE IF EXISTS sp_Jugador_Agregar;
DROP PROCEDURE IF EXISTS sp_Jugador_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Jugador_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_Jugador_ObtenerEquipo;
DROP PROCEDURE IF EXISTS sp_Jugador_ObtenerPosicion;
DROP PROCEDURE IF EXISTS sp_Jugador_Eliminar;
DROP PROCEDURE IF EXISTS sp_Plantilla_Agregar;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerPorUsuario;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerPorFecha;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerPorNombre;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerJugadores;
DROP PROCEDURE IF EXISTS sp_Plantilla_ObtenerCalificacion;
DROP PROCEDURE IF EXISTS sp_Plantilla_Eliminar;
DROP PROCEDURE IF EXISTS sp_PlantillaTitular_Agregar;
DROP PROCEDURE IF EXISTS sp_PlantillaTitular_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_PlantillaTitular_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_PlantillaTitular_ObtenerJugadores;
DROP PROCEDURE IF EXISTS sp_PlantillaTitular_Eliminar;
DROP PROCEDURE IF EXISTS sp_PlantillaSuplente_Agregar;
DROP PROCEDURE IF EXISTS sp_PlantillaSuplente_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_PlantillaSuplente_ObtenerPorId;
DROP PROCEDURE IF EXISTS sp_PlantillaSuplente_ObtenerJugadores;
DROP PROCEDURE IF EXISTS sp_PlantillaSuplente_Eliminar;
DROP PROCEDURE IF EXISTS sp_Puntuacion_Agregar;
DROP PROCEDURE IF EXISTS sp_Puntuacion_ObtenerTodos;
DROP PROCEDURE IF EXISTS sp_Puntuacion_ObtenerPorFecha;
DROP PROCEDURE IF EXISTS sp_Puntuacion_ObtenerPorJugador;
DROP PROCEDURE IF EXISTS sp_Puntuacion_ObtenerPorFechaJugador;
DROP PROCEDURE IF EXISTS sp_Puntuacion_Eliminar;

DELIMITER $$

CREATE PROCEDURE sp_Usuario_Agregar(
    IN p_Nombre VARCHAR(50), IN p_Apellido VARCHAR(50), IN p_Email VARCHAR(100),
    IN p_FechaNacimiento DATE, IN p_Administrador BOOLEAN, IN p_Contrasena CHAR(64)
)
BEGIN
    INSERT INTO Usuario (Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena)
    VALUES (p_Nombre, p_Apellido, p_Email, p_FechaNacimiento, p_Administrador, p_Contrasena);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_Usuario_ObtenerTodos()
BEGIN
    SELECT Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena AS Contraseña FROM Usuario;
END$$

CREATE PROCEDURE sp_Usuario_ObtenerPorId(IN p_Id SMALLINT UNSIGNED)
BEGIN
    SELECT Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena AS Contraseña
    FROM Usuario WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_Usuario_ObtenerPorEmail(IN p_Email VARCHAR(100))
BEGIN
    SELECT Id, Nombre, Apellido, Email, FechaNacimiento, Administrador, Contrasena AS Contraseña
    FROM Usuario WHERE Email = p_Email;
END$$

CREATE PROCEDURE sp_Usuario_Eliminar(IN p_Id SMALLINT UNSIGNED)
BEGIN
    DELETE FROM Usuario WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_Equipo_Agregar(IN p_Nombre VARCHAR(50))
BEGIN
    INSERT INTO Equipo (Nombre) VALUES (p_Nombre);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_Equipo_ObtenerTodos()
BEGIN
    SELECT Id, Nombre FROM Equipo;
END$$

CREATE PROCEDURE sp_Equipo_ObtenerPorId(IN p_Id TINYINT UNSIGNED)
BEGIN
    SELECT Id, Nombre FROM Equipo WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_Equipo_ObtenerJugadores(IN p_Id TINYINT UNSIGNED)
BEGIN
    SELECT * FROM Jugador WHERE IdEquipo = p_Id;
END$$

CREATE PROCEDURE sp_Equipo_Eliminar(IN p_Id TINYINT UNSIGNED)
BEGIN
    DELETE FROM Equipo WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_Posicion_Agregar(IN p_Id TINYINT UNSIGNED, IN p_Nombre VARCHAR(20))
BEGIN
    INSERT INTO Posicion (Id, Nombre) VALUES (p_Id, p_Nombre);
    SELECT p_Id AS Id;
END$$

CREATE PROCEDURE sp_Posicion_ObtenerTodos()
BEGIN
    SELECT Id, Nombre FROM Posicion ORDER BY Id;
END$$

CREATE PROCEDURE sp_Posicion_ObtenerPorId(IN p_Id TINYINT UNSIGNED)
BEGIN
    SELECT Id, Nombre FROM Posicion WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_Posicion_ObtenerJugadores(IN p_Id TINYINT UNSIGNED)
BEGIN
    SELECT * FROM Jugador WHERE IdPosicion = p_Id;
END$$

CREATE PROCEDURE sp_Posicion_Eliminar(IN p_Id TINYINT UNSIGNED)
BEGIN
    DELETE FROM Posicion WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_Jugador_Agregar(
    IN p_Nombre VARCHAR(50), IN p_Apellido VARCHAR(50), IN p_Apodo VARCHAR(50),
    IN p_FechaNacimiento DATE, IN p_IdEquipo TINYINT UNSIGNED,
    IN p_Cotizacion DECIMAL(10,2), IN p_IdPosicion TINYINT UNSIGNED
)
BEGIN
    INSERT INTO Jugador (Nombre, Apellido, Apodo, FechaNacimiento, IdEquipo, Cotizacion, IdPosicion)
    VALUES (p_Nombre, p_Apellido, p_Apodo, p_FechaNacimiento, p_IdEquipo, p_Cotizacion, p_IdPosicion);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_Jugador_ObtenerTodos()
BEGIN
    SELECT * FROM Jugador;
END$$

CREATE PROCEDURE sp_Jugador_ObtenerPorId(IN p_Id SMALLINT UNSIGNED)
BEGIN
    SELECT * FROM Jugador WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_Jugador_ObtenerEquipo(IN p_Id SMALLINT UNSIGNED)
BEGIN
    SELECT e.* FROM Equipo e INNER JOIN Jugador j ON j.IdEquipo = e.Id WHERE j.Id = p_Id;
END$$

CREATE PROCEDURE sp_Jugador_ObtenerPosicion(IN p_Id SMALLINT UNSIGNED)
BEGIN
    SELECT p.* FROM Posicion p INNER JOIN Jugador j ON j.IdPosicion = p.Id WHERE j.Id = p_Id;
END$$

CREATE PROCEDURE sp_Jugador_Eliminar(IN p_Id SMALLINT UNSIGNED)
BEGIN
    DELETE FROM Jugador WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_Plantilla_Agregar(
    IN p_IdUsuario SMALLINT UNSIGNED, IN p_Fecha TINYINT UNSIGNED, IN p_Nombre VARCHAR(60)
)
BEGIN
    INSERT INTO Plantilla (IdUsuario, Fecha, Nombre) VALUES (p_IdUsuario, p_Fecha, p_Nombre);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerTodos()
BEGIN
    SELECT * FROM Plantilla;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerPorId(IN p_Id INT UNSIGNED)
BEGIN
    SELECT * FROM Plantilla WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerPorUsuario(IN p_IdUsuario SMALLINT UNSIGNED)
BEGIN
    SELECT * FROM Plantilla WHERE IdUsuario = p_IdUsuario ORDER BY Fecha DESC LIMIT 1;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerPorFecha(IN p_Fecha TINYINT UNSIGNED)
BEGIN
    SELECT * FROM Plantilla WHERE Fecha = p_Fecha ORDER BY Id LIMIT 1;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerPorNombre(IN p_Nombre VARCHAR(60))
BEGIN
    SELECT * FROM Plantilla WHERE Nombre = p_Nombre ORDER BY Id LIMIT 1;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerJugadores(IN p_Id INT UNSIGNED)
BEGIN
    SELECT j.* FROM Jugador j INNER JOIN PlantillaTitular pt ON pt.IdJugador = j.Id WHERE pt.IdPlantilla = p_Id
    UNION ALL
    SELECT j.* FROM Jugador j INNER JOIN PlantillaSuplente ps ON ps.IdJugador = j.Id WHERE ps.IdPlantilla = p_Id;
END$$

CREATE PROCEDURE sp_Plantilla_ObtenerCalificacion(IN p_Id INT UNSIGNED)
BEGIN
    SELECT COALESCE(SUM(p.Puntaje), 0) AS Calificacion
    FROM Plantilla t
    INNER JOIN PlantillaTitular pt ON pt.IdPlantilla = t.Id
    LEFT JOIN Puntuacion p ON p.IdJugador = pt.IdJugador AND p.Fecha = t.Fecha
    WHERE t.Id = p_Id;
END$$

CREATE PROCEDURE sp_Plantilla_Eliminar(IN p_Id INT UNSIGNED)
BEGIN
    DELETE FROM Plantilla WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_PlantillaTitular_Agregar(IN p_IdPlantilla INT UNSIGNED, IN p_IdJugador SMALLINT UNSIGNED)
BEGIN
    INSERT INTO PlantillaTitular (IdPlantilla, IdJugador) VALUES (p_IdPlantilla, p_IdJugador);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_PlantillaTitular_ObtenerTodos()
BEGIN
    SELECT * FROM PlantillaTitular;
END$$

CREATE PROCEDURE sp_PlantillaTitular_ObtenerPorId(IN p_Id INT UNSIGNED)
BEGIN
    SELECT * FROM PlantillaTitular WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_PlantillaTitular_ObtenerJugadores(IN p_Id INT UNSIGNED)
BEGIN
    SELECT j.* FROM Jugador j INNER JOIN PlantillaTitular pt ON pt.IdJugador = j.Id WHERE pt.IdPlantilla = p_Id;
END$$

CREATE PROCEDURE sp_PlantillaTitular_Eliminar(IN p_Id INT UNSIGNED)
BEGIN
    DELETE FROM PlantillaTitular WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_PlantillaSuplente_Agregar(IN p_IdPlantilla INT UNSIGNED, IN p_IdJugador SMALLINT UNSIGNED)
BEGIN
    INSERT INTO PlantillaSuplente (IdPlantilla, IdJugador) VALUES (p_IdPlantilla, p_IdJugador);
    SELECT LAST_INSERT_ID() AS Id;
END$$

CREATE PROCEDURE sp_PlantillaSuplente_ObtenerTodos()
BEGIN
    SELECT * FROM PlantillaSuplente;
END$$

CREATE PROCEDURE sp_PlantillaSuplente_ObtenerPorId(IN p_Id INT UNSIGNED)
BEGIN
    SELECT * FROM PlantillaSuplente WHERE Id = p_Id;
END$$

CREATE PROCEDURE sp_PlantillaSuplente_ObtenerJugadores(IN p_Id INT UNSIGNED)
BEGIN
    SELECT j.* FROM Jugador j INNER JOIN PlantillaSuplente ps ON ps.IdJugador = j.Id WHERE ps.IdPlantilla = p_Id;
END$$

CREATE PROCEDURE sp_PlantillaSuplente_Eliminar(IN p_Id INT UNSIGNED)
BEGIN
    DELETE FROM PlantillaSuplente WHERE Id = p_Id;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

CREATE PROCEDURE sp_Puntuacion_Agregar(
    IN p_Fecha TINYINT UNSIGNED, IN p_IdJugador SMALLINT UNSIGNED, IN p_Puntaje DECIMAL(3,1)
)
BEGIN
    INSERT INTO Puntuacion (Fecha, IdJugador, Puntaje) VALUES (p_Fecha, p_IdJugador, p_Puntaje);
    SELECT p_Fecha AS Fecha, p_IdJugador AS IdJugador, p_Puntaje AS Puntaje;
END$$

CREATE PROCEDURE sp_Puntuacion_ObtenerTodos()
BEGIN
    SELECT Fecha, IdJugador, Puntaje FROM Puntuacion;
END$$

CREATE PROCEDURE sp_Puntuacion_ObtenerPorFecha(IN p_Fecha TINYINT UNSIGNED)
BEGIN
    SELECT Fecha, IdJugador, Puntaje FROM Puntuacion WHERE Fecha = p_Fecha;
END$$

CREATE PROCEDURE sp_Puntuacion_ObtenerPorJugador(IN p_IdJugador SMALLINT UNSIGNED)
BEGIN
    SELECT Fecha, IdJugador, Puntaje FROM Puntuacion WHERE IdJugador = p_IdJugador;
END$$

CREATE PROCEDURE sp_Puntuacion_ObtenerPorFechaJugador(IN p_Fecha TINYINT UNSIGNED, IN p_IdJugador SMALLINT UNSIGNED)
BEGIN
    SELECT Fecha, IdJugador, Puntaje FROM Puntuacion WHERE Fecha = p_Fecha AND IdJugador = p_IdJugador;
END$$

CREATE PROCEDURE sp_Puntuacion_Eliminar(IN p_Fecha TINYINT UNSIGNED, IN p_IdJugador SMALLINT UNSIGNED)
BEGIN
    DELETE FROM Puntuacion WHERE Fecha = p_Fecha AND IdJugador = p_IdJugador;
    SELECT ROW_COUNT() AS FilasAfectadas;
END$$

DELIMITER ;