CREATE TABLE Jugador
(
    Id SMALLINT UNSIGNED PRIMARY KEY,
    IdEquipo TINYINT UNSIGNED NOT NULL,
    IdPosicion TINYINT UNSIGNED NOT NULL,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Apodo VARCHAR(50) NULL,
    FechaNacimiento DATE NOT NULL,
    Cotizacion DECIMAL(10,2) NOT NULL,
    CONSTRAINT FK_Jugador_Equipo FOREIGN KEY (IdEquipo) REFERENCES Equipo(Id),
    CONSTRAINT FK_Jugador_Posicion FOREIGN KEY (IdPosicion) REFERENCES Posicion(Id)
);

CREATE TABLE Posicion
(
    Id TINYINT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(20) NOT NULL,
    CONSTRAINT UQ_Posicion_Nombre UNIQUE (Nombre)
);

CREATE TABLE Equipo
(
    Id TINYINT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Equipo_Nombre UNIQUE (Nombre)
);

CREATE TABLE Puntuacion
(
    Fecha TINYINT UNSIGNED PRIMARY KEY,
    IdJugador SMALLINT UNSIGNED PRIMARY KEY,
    Puntuacion DECIMAL(3,1) NOT NULL,
    CONSTRAINT PFK_Puntuacion_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);

CREATE TABLE Plantilla
(
    Id INT UNSIGNED PRIMARY KEY,
    IdUsuario TINYINT UNSIGNED NOT NULL,
    Fecha TINYINT UNSIGNED NOT NULL ,
    Nombre VARCHAR(60) NULL,
    CONSTRAINT FK_Plantilla_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(Id)
);

CREATE TABLE PlantillaTitular
(
    Id INT UNSIGNED PRIMARY KEY,
    IdPlantilla INT UNSIGNED NOT NULL,
    IdJugador SMALLINT UNSIGNED NOT NULL,
    CONSTRAINT FK_PlantillaTitular_Plantilla FOREIGN KEY (IdPlantilla) REFERENCES Plantilla(Id),
    CONSTRAINT FK_PlantillaTitular_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);

CREATE TABLE PlantillaSuplente
(
    Id INT UNSIGNED PRIMARY KEY,
    IdPlantilla INT UNSIGNED NOT NULL,
    IdJugador SMALLINT UNSIGNED NOT NULL,
    CONSTRAINT FK_PlantillaSuplente_Plantilla FOREIGN KEY (IdPlantilla) REFERENCES Plantilla(Id),
    CONSTRAINT FK_PlantillaSuplente_Jugador FOREIGN KEY (IdJugador) REFERENCES Jugador(Id)
);

CREATE TABLE Usuario
(
    Id TINYINT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Contrasena VARCHAR(64) NOT NULL,
    CONSTRAINT UQ_Usuario_Email UNIQUE (Email)
);