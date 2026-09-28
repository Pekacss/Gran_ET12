DELIMITER ?
-- Usuario
    CREATE PROCEDURE sp_Usuario_Agregar (
        p_Nombre VARCHAR(50),
        p_Apellido VARCHAR(50),
        p_Email VARCHAR(100),
        p_FechaNacimiento DATE,
        p_Administrador BOOLEAN,
        p_Contraseña CHAR(64)
    )
    BEGIN
        INSERT INTO Usuario (Nombre, Apellido, Email, FechaNacimiento, Administrador, Contraseña)
        VALUES (p_Nombre, p_Apellido, p_Email, p_FechaNacimiento, p_Administrador, p_Contraseña);
    END?

    CREATE PROCEDURE sp_Usuario_ObtenerTodos ()
    BEGIN
        SELECT * FROM Usuario;
    END?

    CREATE PROCEDURE sp_Usuario_ObtenerPorId (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Usuario WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Usuario_Eliminar (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        DELETE FROM Usuario WHERE Id = p_Id;
    END?

-- Equipo
    CREATE PROCEDURE sp_Equipo_Agregar (
        p_Nombre VARCHAR(50)
    )
    BEGIN
        INSERT INTO Equipo (Nombre)
        VALUES (p_Nombre);
    END?

    CREATE PROCEDURE sp_Equipo_ObtenerTodos ()
    BEGIN
        SELECT * FROM Equipo;
    END?

    CREATE PROCEDURE sp_Equipo_ObtenerPorId (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Equipo WHERE Id = p_Id;
    END?

    CREATE PROCEdURE sp_Equipo_ObtenerJugadores (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Jugador WHERE EquipoId = p_Id;
    END?

    CREATE PROCEDURE sp_Equipo_Eliminar (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        DELETE FROM Equipo WHERE Id = p_Id;
    END?

-- Posicion
    CREATE PROCEDURE sp_Posicion_Agregar (
        p_Nombre VARCHAR(50)
    )
    BEGIN
        INSERT INTO Posicion (Nombre)
        VALUES (p_Nombre);
    END?

    CREATE PROCEDURE sp_Posicion_ObtenerTodos ()
    BEGIN
        SELECT * FROM Posicion;
    END?

    CREATE PROCEDURE sp_Posicion_ObtenerPorId (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Posicion WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Posicion_ObtenerJugadores (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Jugador WHERE PosicionId = p_Id;
    END?

    CREATE PROCEDURE sp_Posicion_Eliminar (
        p_Id TINYINT UNSIGNED
    )
    BEGIN
        DELETE FROM Posicion WHERE Id = p_Id;
    END?

-- Jugador
    CREATE PROCEDURE sp_Jugador_Agregar (
        p_Nombre VARCHAR(255),
        p_Apellido VARCHAR(255),
        p_FechaNacimiento DATE,
        p_EquipoId TINYINT UNSIGNED,
        p_PosicionId TINYINT UNSIGNED
    )
    BEGIN
        INSERT INTO Jugador (Nombre, Apellido, FechaNacimiento, EquipoId, PosicionId)
        VALUES (p_Nombre, p_Apellido, p_FechaNacimiento, p_EquipoId, p_PosicionId);
    END?

    CREATE PROCEDURE sp_Jugador_ObtenerTodos ()
    BEGIN
        SELECT * FROM Jugador;
    END?

    CREATE PROCEDURE sp_Jugador_ObtenerPorId (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Jugador WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Jugador_Eliminar (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        DELETE FROM Jugador WHERE Id = p_Id;
    END?

-- Plantilla
    CREATE PROCEDURE sp_Plantilla_Agregar (
        p_JugadorId SMALLINT UNSIGNED,
        p_EquipoId TINYINT UNSIGNED
    )
    BEGIN
        INSERT INTO Plantilla (JugadorId, EquipoId)
        VALUES (p_JugadorId, p_EquipoId);
    END?

    CREATE PROCEDURE sp_Plantilla_ObtenerTodos ()
    BEGIN
        SELECT * FROM Plantilla;
    END?

    CREATE PROCEDURE sp_Plantilla_ObtenerPorId (
        p_Id INT UNSIGNED
    )
    BEGIN
        SELECT * FROM Plantilla WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Plantilla_Eliminar (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        DELETE FROM Plantilla WHERE Id = p_Id;
    END?

-- Titulares
    CREATE PROCEDURE sp_Titulares_Agregar (
        p_JugadorId SMALLINT UNSIGNED,
        p_EquipoId TINYINT UNSIGNED
    )
    BEGIN
        INSERT INTO PlantillaTitular (JugadorId, EquipoId)
        VALUES (p_JugadorId, p_EquipoId);
    END?

    CREATE PROCEDURE sp_Titulares_ObtenerTodos ()
    BEGIN
        SELECT * FROM PlantillaTitular;
    END?

    CREATE PROCEDURE sp_Titulares_ObtenerPorId (
        p_Id INT UNSIGNED
    )
    BEGIN
        SELECT * FROM PlantillaTitular WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Titulares_Eliminar (
        p_Id INT UNSIGNED
    )
    BEGIN
        DELETE FROM PlantillaTitular WHERE Id = p_Id;
    END?

-- Suplentes
    CREATE PROCEDURE sp_Suplentes_Agregar (
        p_JugadorId SMALLINT UNSIGNED,
        p_EquipoId TINYINT UNSIGNED
    )
    BEGIN
        INSERT INTO PlantillaSuplente (JugadorId, EquipoId)
        VALUES (p_JugadorId, p_EquipoId);
    END?

    CREATE PROCEDURE sp_Suplentes_ObtenerTodos ()
    BEGIN
        SELECT * FROM PlantillaSuplente;
    END?

    CREATE PROCEDURE sp_Suplentes_ObtenerPorId (
        p_Id INT UNSIGNED
    )
    BEGIN
        SELECT * FROM PlantillaSuplente WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Suplentes_Eliminar (
        p_Id INT UNSIGNED
    )
    BEGIN
        DELETE FROM PlantillaSuplente WHERE Id = p_Id;
    END?

-- Puntuacion
    CREATE PROCEDURE sp_Puntuacion_Agregar (
        p_Puntaje DECIMAL(3,1),
        p_Fecha TINYINT UNSIGNED,
        p_JugadorId SMALLINT UNSIGNED
    )
    BEGIN
        INSERT INTO Puntuacion (Puntaje, Fecha, JugadorId)
        VALUES (p_Puntaje, p_Fecha, p_JugadorId);
    END?

    CREATE PROCEDURE sp_Puntuacion_ObtenerTodos ()
    BEGIN
        SELECT * FROM Puntuacion;
    END?

    CREATE PROCEDURE sp_Puntuacion_ObtenerPorId (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        SELECT * FROM Puntuacion WHERE Id = p_Id;
    END?

    CREATE PROCEDURE sp_Puntuacion_Eliminar (
        p_Id SMALLINT UNSIGNED
    )
    BEGIN
        DELETE FROM Puntuacion WHERE Id = p_Id;
    END?

DELIMITER ;