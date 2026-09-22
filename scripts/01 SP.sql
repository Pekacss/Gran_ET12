DELIMITER ?
-- Usuario
    CREATE PROCEDURE sp_Usuario_Agregar (
        p_Nombre VARCHAR(255),
        p_Apellido VARCHAR(255),
        p_Email VARCHAR(255),
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
-- Posicion
-- Jugador
-- Plantilla
-- Titulares
-- Suplentes
-- Puntuacion
DELIMITER ;