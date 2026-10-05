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
  `varos` varchar(30) NOT NULL,
  `szerzok` int NOT NULL,
  PRIMARY KEY (`kiado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `kiadok` (`kiado`, `alapitva`, `varos`, `szerzok`) VALUES
('Athenaeum', 1893, 'Budapest', 85),
('Európa', 1945, 'Budapest', 240),
('Jelenkor', 1989, 'Pécs', 60),
('Kalligram', 1991, 'Pozsony', 74),
('Libri', 2000, 'Budapest', 310),
('Magvető', 1955, 'Budapest', 190),
('Scolar', 1994, 'Budapest', 52);
COMMIT;
