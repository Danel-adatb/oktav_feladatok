-- SQL Dump (gyakorló feladat)
--
-- Adatbázis: `vizsga_2026`
--

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET NAMES utf8mb4 */;

DROP TABLE IF EXISTS `kiadok`;
CREATE TABLE IF NOT EXISTS `kiadok` (
  `kiado` varchar(30) NOT NULL,
  `alapitva` int NOT NULL,
  `orszag` varchar(30) NOT NULL,
  `jatekok` int NOT NULL,
  PRIMARY KEY (`kiado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `kiadok` (`kiado`, `alapitva`, `orszag`, `jatekok`) VALUES
('Bethesda', 1986, 'USA', 48),
('Capcom', 1979, 'Japán', 95),
('CD Projekt', 1994, 'Lengyelország', 12),
('Nintendo', 1889, 'Japán', 210),
('Sega', 1960, 'Japán', 130),
('Ubisoft', 1986, 'Franciaország', 87),
('Valve', 1996, 'USA', 9);
COMMIT;
