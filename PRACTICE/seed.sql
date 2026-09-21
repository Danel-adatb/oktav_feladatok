-- Adatbázis kiválasztása
CREATE DATABASE IF NOT EXISTS szerszamok_db;
USE szerszamok_db;


-- ============================================
-- GYARTOK
-- ============================================

CREATE TABLE gyartok (
    gyarto VARCHAR(30) NOT NULL,
    alapitva INT,
    nemzetiseg VARCHAR(30),
    leanyvallalatok INT,

    PRIMARY KEY (gyarto)
);


-- ============================================
-- SZERSZAMOK
-- ============================================

CREATE TABLE szerszamok (
    sorszam INT NOT NULL AUTO_INCREMENT,
    gyarto VARCHAR(30) NOT NULL,
    tipus VARCHAR(30),
    ar INT,
    aramforras VARCHAR(30),
    kolcsonzes INT,

    PRIMARY KEY (sorszam),

    CONSTRAINT fk_szerszam_gyarto
        FOREIGN KEY (gyarto)
        REFERENCES gyartok(gyarto)
        ON UPDATE CASCADE
        ON DELETE RESTRICT
);


-- ============================================
-- GYARTOK DUMMY ADATOK
-- ============================================

INSERT INTO gyartok
    (gyarto, alapitva, nemzetiseg, leanyvallalatok)
VALUES
    ('Bosch',       1886, 'Nemet',    12),
    ('Makita',      1915, 'Japan',     8),
    ('DeWalt',      1924, 'Amerikai',  6),
    ('Milwaukee',   1924, 'Amerikai',  5),
    ('Metabo',      1924, 'Nemet',     4),
    ('Festool',     1925, 'Nemet',     3),
    ('Hilti',       1941, 'Liechtensteini', 7),
    ('Stanley',     1843, 'Amerikai', 10);


-- ============================================
-- SZERSZAMOK DUMMY ADATOK
-- ============================================

INSERT INTO szerszamok
    (gyarto, tipus, ar, aramforras, kolcsonzes)
VALUES
    ('Bosch',     'Furogep',          45000,  'Akkumulator',  5000),
    ('Bosch',     'Sarokcsiszolo',    52000,  'Akkumulator',  6000),
    ('Bosch',     'Szegbelovo',       38000,  'Akkumulator',  4500),

    ('Makita',    'Furogep',          49000,  'Akkumulator',  5500),
    ('Makita',    'Korfurosz',        68000,  'Akkumulator',  7500),
    ('Makita',    'Sarokcsiszolo',    55000,  'Akkumulator',  6000),

    ('DeWalt',    'Furogep',          57000,  'Akkumulator',  6500),
    ('DeWalt',    'Korfurosz',        72000,  'Akkumulator',  8000),
    ('DeWalt',    'Utofur',           63000,  'Akkumulator',  7000),

    ('Milwaukee', 'Furo-csavarozo',   61000,  'Akkumulator',  7000),
    ('Milwaukee', 'Sarokcsiszolo',    59000,  'Akkumulator',  6500),

    ('Metabo',    'Furogep',          47000,  'Halozati',     5000),
    ('Metabo',    'Sarokcsiszolo',    51000,  'Halozati',     5500),

    ('Festool',   'Furo-csavarozo',   89000,  'Akkumulator',  9500),
    ('Festool',   'Korfurosz',       110000,  'Akkumulator', 11000),

    ('Hilti',     'Utofur',           125000, 'Akkumulator', 13000),
    ('Hilti',     'Betonfuro',        98000,  'Akkumulator', 10500),

    ('Stanley',   'Furogep',          35000,  'Halozati',     4000),
    ('Stanley',   'Sarokcsiszolo',    42000,  'Halozati',     4500);