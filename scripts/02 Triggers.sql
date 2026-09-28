USE bd_GranET12;

DROP TRIGGER IF EXISTS trg_Usuario_Maximo;
DROP TRIGGER IF EXISTS trg_Equipo_Maximo;
DROP TRIGGER IF EXISTS trg_Jugador_Maximo;
DROP TRIGGER IF EXISTS trg_PlantillaTitular_Validar;
DROP TRIGGER IF EXISTS trg_PlantillaTitular_ValidarActualizacion;
DROP TRIGGER IF EXISTS trg_PlantillaSuplente_Validar;
DROP TRIGGER IF EXISTS trg_PlantillaSuplente_ValidarActualizacion;

DELIMITER $$

CREATE TRIGGER trg_Usuario_Maximo
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Usuario;
	IF cantidad >= 2000 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 2000 usuarios.';
	END IF;
END$$

CREATE TRIGGER trg_Equipo_Maximo
BEFORE INSERT ON Equipo
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Equipo;
	IF cantidad >= 32 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 32 equipos.';
	END IF;
END$$

CREATE TRIGGER trg_Jugador_Maximo
BEFORE INSERT ON Jugador
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Jugador;
	IF cantidad >= 1500 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 1500 jugadores.';
	END IF;
END$$

CREATE TRIGGER trg_PlantillaTitular_Validar
BEFORE INSERT ON PlantillaTitular
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM PlantillaTitular WHERE IdPlantilla = NEW.IdPlantilla;
	SELECT cantidad + COUNT(*) INTO cantidad FROM PlantillaSuplente WHERE IdPlantilla = NEW.IdPlantilla;

	IF cantidad >= 20 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Una plantilla no puede superar 20 jugadores.';
	END IF;

	IF EXISTS (
		SELECT 1 FROM PlantillaSuplente
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como suplente de esta plantilla.';
	END IF;
END$$

CREATE TRIGGER trg_PlantillaTitular_ValidarActualizacion
BEFORE UPDATE ON PlantillaTitular
FOR EACH ROW
BEGIN
	IF EXISTS (
		SELECT 1 FROM PlantillaSuplente
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como suplente de esta plantilla.';
	END IF;
END$$

CREATE TRIGGER trg_PlantillaSuplente_Validar
BEFORE INSERT ON PlantillaSuplente
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM PlantillaTitular WHERE IdPlantilla = NEW.IdPlantilla;
	SELECT cantidad + COUNT(*) INTO cantidad FROM PlantillaSuplente WHERE IdPlantilla = NEW.IdPlantilla;

	IF cantidad >= 20 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Una plantilla no puede superar 20 jugadores.';
	END IF;

	IF EXISTS (
		SELECT 1 FROM PlantillaTitular
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como titular de esta plantilla.';
	END IF;
END$$

CREATE TRIGGER trg_PlantillaSuplente_ValidarActualizacion
BEFORE UPDATE ON PlantillaSuplente
FOR EACH ROW
BEGIN
	IF EXISTS (
		SELECT 1 FROM PlantillaTitular
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como titular de esta plantilla.';
	END IF;
END$$

DELIMITER ;
