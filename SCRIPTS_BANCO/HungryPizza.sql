-- -----------------------------------------------------
-- Bank Model hungrypizza
-- -----------------------------------------------------

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema hungrypizza
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema hungrypizza
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS 'hungrypizza' DEFAULT CHARACTER SET utf8 ;
USE 'hungrypizza' ;

-- -----------------------------------------------------
-- Table 'hungrypizza'.'customer'
-- -----------------------------------------------------
DROP TABLE IF EXISTS 'hungrypizza'.'customer' ;

CREATE TABLE IF NOT EXISTS 'hungrypizza'.'customer' (
  'id' INT NOT NULL AUTO_INCREMENT,
  'iduser' INT NOT NULL,
  'name' VARCHAR(100) NOT NULL,
  'address' VARCHAR(100) NOT NULL,
  PRIMARY KEY ('id'))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table 'hungrypizza'.'user'
-- -----------------------------------------------------
DROP TABLE IF EXISTS 'hungrypizza'.'user' ;

CREATE TABLE IF NOT EXISTS 'hungrypizza'.'user' (
  'id' INT NOT NULL AUTO_INCREMENT,
  'email' VARCHAR(100) NOT NULL,
  'password' VARCHAR(20) NOT NULL,
  'active' TINYINT(1) NOT NULL,
  PRIMARY KEY ('id'))
ENGINE = InnoDB;

CREATE UNIQUE INDEX 'email_UNIQUE' ON 'hungrypizza'.'user' ('email' ASC);


-- -----------------------------------------------------
-- Table 'hungrypizza'.'pizza'
-- -----------------------------------------------------
DROP TABLE IF EXISTS 'hungrypizza'.'pizza' ;

CREATE TABLE IF NOT EXISTS 'hungrypizza'.'pizza' (
  'id' INT NOT NULL AUTO_INCREMENT,
  'name' VARCHAR(50) NOT NULL,
  'price' DECIMAL(5,2) NOT NULL,
  'active' TINYINT(1) NOT NULL,
  PRIMARY KEY ('id'))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table 'hungrypizza'.'request_pizza'
-- -----------------------------------------------------
DROP TABLE IF EXISTS 'hungrypizza'.'request_pizza' ;

CREATE TABLE IF NOT EXISTS 'hungrypizza'.'request_pizza' (
  'id' INT NOT NULL AUTO_INCREMENT,
  'idrequest' INT NOT NULL,
  'idpizzafirsthalf' INT NOT NULL,
  'idpizzasecondhalf' INT NOT NULL,
  'quantity' INT NOT NULL,
  'total' DECIMAL NOT NULL,
  'active' TINYINT(1) NOT NULL,
  PRIMARY KEY ('id'))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table 'hungrypizza'.'request'
-- -----------------------------------------------------
DROP TABLE IF EXISTS 'hungrypizza'.'request' ;

CREATE TABLE IF NOT EXISTS 'hungrypizza'.'request' (
  'id' INT NOT NULL AUTO_INCREMENT,
  'created_at' DATETIME NOT NULL,
  'uid' VARCHAR(100) NOT NULL,
  'quantity' INT NOT NULL,
  'total' DECIMAL(9,2) NOT NULL,
  'idcustomer' INT NULL,
  'address' VARCHAR(100) NULL,
  'active' TINYINT(1) NOT NULL,
  PRIMARY KEY ('id'))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table 'hungrypizza'.'pizza'
-- -----------------------------------------------------
START TRANSACTION;
USE 'hungrypizza';
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (1, '3 Queijos', 50, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (2, 'Frango com requeijão', 59.99, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (3, 'Mussarela', 42.50, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (4, 'Calabresa', 42.50, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (5, 'Pepperoni', 55, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (6, 'Portuguesa', 45, 1);
INSERT INTO 'hungrypizza'.'pizza' ('id', 'name', 'price', 'active') VALUES (7, 'Veggie', 59.99, 1);

COMMIT;

