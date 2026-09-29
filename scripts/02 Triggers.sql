USE bd_GranET12;

DROP TRIGGER IF EXISTS BefInsUsuario;
DROP TRIGGER IF EXISTS BefInsEquipo;
DROP TRIGGER IF EXISTS BefInsJugador;
DROP TRIGGER IF EXISTS BefInsPlantillaTitular;
DROP TRIGGER IF EXISTS BefUpdPlantillaTitular;
DROP TRIGGER IF EXISTS BefInsBefInsUsuario;
DROP TRIGGER IF EXISTS BefUpdPlantillaSuplente;

DELIMITER ?

CREATE TRIGGER BefInsUsuario
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Usuario;
	IF cantidad >= 2000 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 2000 usuarios.';
	END IF;
END?

CREATE TRIGGER BefInsEquipo
BEFORE INSERT ON Equipo
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Equipo;
	IF cantidad >= 32 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 32 equipos.';
	END IF;
END?

CREATE TRIGGER BefInsJugador
BEFORE INSERT ON Jugador
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	SELECT COUNT(*) INTO cantidad FROM Jugador;
	IF cantidad >= 1500 THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La base ya contiene el maximo de 1500 jugadores.';
	END IF;
END?

CREATE TRIGGER BefInsPlantillaTitular
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
END?

CREATE TRIGGER BefUpdPlantillaTitular
BEFORE UPDATE ON PlantillaTitular
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	IF NEW.IdPlantilla <> OLD.IdPlantilla THEN
		SELECT COUNT(*) INTO cantidad FROM PlantillaTitular
		WHERE IdPlantilla = NEW.IdPlantilla AND Id <> OLD.Id;
		SELECT cantidad + COUNT(*) INTO cantidad FROM PlantillaSuplente
		WHERE IdPlantilla = NEW.IdPlantilla;
		IF cantidad >= 20 THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Una plantilla no puede superar 20 jugadores.';
		END IF;
	END IF;

	IF EXISTS (
		SELECT 1 FROM PlantillaSuplente
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como suplente de esta plantilla.';
	END IF;
END?

CREATE TRIGGER BefInsBefInsUsuario
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
END?

CREATE TRIGGER BefUpdPlantillaSuplente
BEFORE UPDATE ON PlantillaSuplente
FOR EACH ROW
BEGIN
	DECLARE cantidad INT;
	IF NEW.IdPlantilla <> OLD.IdPlantilla THEN
		SELECT COUNT(*) INTO cantidad FROM PlantillaSuplente
		WHERE IdPlantilla = NEW.IdPlantilla AND Id <> OLD.Id;
		SELECT cantidad + COUNT(*) INTO cantidad FROM PlantillaTitular
		WHERE IdPlantilla = NEW.IdPlantilla;
		IF cantidad >= 20 THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Una plantilla no puede superar 20 jugadores.';
		END IF;
	END IF;

	IF EXISTS (
		SELECT 1 FROM PlantillaTitular
		WHERE IdPlantilla = NEW.IdPlantilla AND IdJugador = NEW.IdJugador
	) THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya esta cargado como titular de esta plantilla.';
	END IF;
END?

DELIMITER ;
