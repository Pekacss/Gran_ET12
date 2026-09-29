CREATE DATABASE IF NOT EXISTS bd_GranET12
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_0900_ai_ci;

USE bd_GranET12;

CREATE TABLE IF NOT EXISTS Usuario
(
    Id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Administrador BOOLEAN NOT NULL DEFAULT FALSE,
    Contrasena CHAR(64) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (Email)
);

CREATE TABLE IF NOT EXISTS Posicion
(
    Id TINYINT UNSIGNED NOT NULL,
    Nombre VARCHAR(20) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (Nombre),
    CONSTRAINT CK_Posicion_Id CHECK (Id BETWEEN 1 AND 4)
);

CREATE TABLE IF NOT EXISTS Equipo
(
    Id TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (Nombre)
);

CREATE TABLE IF NOT EXISTS Jugador
(
    Id SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Apodo VARCHAR(50) NOT NULL DEFAULT '',
    FechaNacimiento DATE NOT NULL,
    IdEquipo TINYINT UNSIGNED NOT NULL,
    Cotizacion DECIMAL(10,2) NOT NULL,
    IdPosicion TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    CONSTRAINT CK_Jugador_Cotizacion CHECK (Cotizacion >= 0 AND Cotizacion <= 99999999.99),
    CONSTRAINT FK_Jugador_Equipo FOREIGN KEY (IdEquipo) REFERENCES Equipo(Id),
    CONSTRAINT FK_Jugador_Posicion FOREIGN KEY (IdPosicion) REFERENCES Posicion(Id)
);

CREATE TABLE IF NOT EXISTS Plantilla
(
    Id INT NOT NULL AUTO_INCREMENT,
    IdUsuario SMALLINT UNSIGNED NOT NULL,
    Fecha TINYINT UNSIGNED NOT NULL,
    Nombre VARCHAR(60) NULL,
    PRIMARY KEY (Id),
    CONSTRAINT CK_Plantilla_Fecha CHECK (Fecha > 0 AND Fecha < 50),
    CONSTRAINT FK_Plantilla_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE IF NOT EXISTS PlantillaTitular
(
    Id INT NOT NULL AUTO_INCREMENT,
    IdPlantilla INT NOT NULL,
    IdJugador SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (IdPlantilla, IdJugador),
    CONSTRAINT FK_PlantillaTitular_Plantilla FOREIGN KEY (IdPlantilla) REFERENCES Plantilla(Id) ON DELETE CASCADE,
    CONSTRAINT FK_PlantillaTitular_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);

CREATE TABLE IF NOT EXISTS PlantillaSuplente
(
    Id INT NOT NULL AUTO_INCREMENT,
    IdPlantilla INT NOT NULL,
    IdJugador SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (Id),
    UNIQUE (IdPlantilla, IdJugador),
    CONSTRAINT FK_PlantillaSuplente_Plantilla FOREIGN KEY (IdPlantilla) REFERENCES Plantilla(Id) ON DELETE CASCADE,
    CONSTRAINT FK_PlantillaSuplente_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);

CREATE TABLE IF NOT EXISTS Puntuacion
(
    Fecha TINYINT UNSIGNED NOT NULL,
    IdJugador SMALLINT UNSIGNED NOT NULL,
    Puntaje DECIMAL(3,1) NOT NULL,
    PRIMARY KEY (Fecha, IdJugador),
    CONSTRAINT CK_Puntuacion_Fecha CHECK (Fecha > 0 AND Fecha < 50),
    CONSTRAINT CK_Puntuacion_Puntaje CHECK (Puntaje >= 1.0 AND Puntaje <= 10.0),
    CONSTRAINT FK_Puntuacion_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);
