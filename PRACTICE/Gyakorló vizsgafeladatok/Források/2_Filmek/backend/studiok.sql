-- SQL Dump (gyakorló feladat)
--
-- Adatbázis: `vizsga_2026`
--

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET NAMES utf8mb4 */;

DROP TABLE IF EXISTS `studiok`;
CREATE TABLE IF NOT EXISTS `studiok` (
  `studio` varchar(30) NOT NULL,
  `alapitva` int NOT NULL,
  `orszag` varchar(30) NOT NULL,
  `dolgozok` int NOT NULL,
  PRIMARY KEY (`studio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `studiok` (`studio`, `alapitva`, `orszag`, `dolgozok`) VALUES
('Disney', 1923, 'USA', 195),
('Lionsgate', 1997, 'Kanada', 34),
('Paramount', 1912, 'USA', 88),
('Pixar', 1986, 'USA', 42),
('Sony', 1924, 'Japán', 120),
('Universal', 1912, 'USA', 76),
('Warner', 1923, 'USA', 101);
COMMIT;
