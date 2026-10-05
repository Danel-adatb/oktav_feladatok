-- SQL Dump (gyakorló feladat)
--
-- Adatbázis: `vizsga_2026`
--

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET NAMES utf8mb4 */;

DROP TABLE IF EXISTS `markak`;
CREATE TABLE IF NOT EXISTS `markak` (
  `gyarto` varchar(30) NOT NULL,
  `alapitva` int NOT NULL,
  `nemzetiseg` varchar(30) NOT NULL,
  `uzemek` int NOT NULL,
  PRIMARY KEY (`gyarto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `markak` (`gyarto`, `alapitva`, `nemzetiseg`, `uzemek`) VALUES
('Cube', 1993, 'Németország', 6),
('Canyon', 2002, 'Németország', 9),
('Giant', 1972, 'Tajvan', 31),
('Merida', 1972, 'Tajvan', 24),
('Scott', 1958, 'Svájc', 14),
('Specialized', 1974, 'USA', 17),
('Trek', 1976, 'USA', 38);
COMMIT;
