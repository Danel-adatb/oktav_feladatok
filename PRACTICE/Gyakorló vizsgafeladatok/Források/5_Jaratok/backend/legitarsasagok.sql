-- SQL Dump (gyakorló feladat)
--
-- Adatbázis: `vizsga_2026`
--

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET NAMES utf8mb4 */;

DROP TABLE IF EXISTS `legitarsasagok`;
CREATE TABLE IF NOT EXISTS `legitarsasagok` (
  `legitarsasag` varchar(30) NOT NULL,
  `alapitva` int NOT NULL,
  `orszag` varchar(30) NOT NULL,
  `flotta` int NOT NULL,
  PRIMARY KEY (`legitarsasag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `legitarsasagok` (`legitarsasag`, `alapitva`, `orszag`, `flotta`) VALUES
('Air France', 1933, 'Franciaország', 220),
('Emirates', 1985, 'Egyesült Arab Emírségek', 260),
('KLM', 1919, 'Hollandia', 117),
('Lufthansa', 1953, 'Németország', 730),
('Ryanair', 1984, 'Írország', 550),
('Turkish', 1933, 'Törökország', 440),
('Wizz Air', 2003, 'Magyarország', 190);
COMMIT;
