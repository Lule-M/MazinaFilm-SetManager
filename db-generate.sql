CREATE DATABASE mazinafilm;
GO
USE mazinafilm;
GO

-- KREIRANJE TABELA

--    ┌─────────────────────┐                                                                 
--    │        Scena        │░                ┌──────────────────────┐                        
--    │                     │░0:n         1:1 │       Lokacija       │░                       
--    │IDScena       :int   ├─────────────────┤                      │░                       
--    │Redni_broj    :int   │░                │IDLokacija     :int   │░                       
--    │IDLokacija    :int   │░                │Naziv_lokacije :string│░                       
--    │Doba_dana     :string│░                └──────────────────────┘░
--    |Snimljeno     :bool  │░                 ░░░░░░░░░░░░░░░░░░░░░░░░
--    │DatumSnimanja :date  │░                                       
--    └─────────┬───────────┘░                                        
--     ░░░░░░░░░│░1:n░░░░░░░░░                                                                
--              │                                                                          
--              │ 1:n                                                                      
--     ┌────────┴───────┐                                                                  
--     │ ScenaZaposleni │░                                                                 
--     │                │░                                                                 
--     │IDScena     :int│░                                                                 
--     │IDZaposleni :int│░                                                                 
--     └────────┬───────┘░                                                                 
--      ░░░░░░░░│░1:n░░░░░                                                                 
--              │                                                                          
--              │ 0:n                                                                      
--    ┌─────────┴─────────┐                                                               
--    │     Zaposleni     │░          ┌────────────────┐           ┌────────────────────┐ 
--    │                   │░          │ZaposleniOprema │░          │       Oprema       │░
--    │IDZaposleni :int   │░1:n   0:n │                │░0:n   1:n │                    │░
--    │Ime         :string├───────────┤IDZaposleni :int├───────────┤IDOprema     :int   │░
--    │Prezime     :string│░          │IDOprema    :int│░          │Naziv_opreme :string│░
--    │Radno_mesto :string│░          └────────────────┘░          └────────────────────┘░
--    └───────────────────┘░           ░░░░░░░░░░░░░░░░░░           ░░░░░░░░░░░░░░░░░░░░░░
--     ░░░░░░░░░░░░░░░░░░░░░                                                              


CREATE TABLE Lokacija
(
	IDLokacija int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	NazivLokacije nvarchar(50) NOT NULL
);
GO

CREATE TABLE Scena
(
	IDScena int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	RedniBroj int NOT NULL,
	DatumSnimanja datetime DEFAULT CURRENT_TIMESTAMP,
	IDLokacija int NOT NULL,
	DobaDana nvarchar(10) NOT NULL,
	Snimljeno bit DEFAULT 0 NOT NULL,

	CONSTRAINT FK_Scena_Lokacija FOREIGN KEY (IDLokacija)
	REFERENCES Lokacija(IDLokacija)
);
GO

CREATE TABLE Oprema
(
	IDOprema int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	NazivOpreme nvarchar(100) NOT NULL
);
GO

CREATE TABLE Zaposleni
(
	IDZaposleni int identity(1, 1) NOT NULL PRIMARY KEY,
	Ime nvarchar(20) NOT NULL,
	Prezime nvarchar(20) NOT NULL,
	RadnoMesto nvarchar(50) NOT NULL
);
GO

CREATE TABLE ZaposleniOprema
(
	IDZaposleni int NOT NULL,
	IDOprema int NOT NULL,

	PRIMARY KEY (IDZaposleni, IDOprema),

	CONSTRAINT FK_ZaposleniOprema_Zaposleni FOREIGN KEY (IDZaposleni)
	REFERENCES Zaposleni(IDZaposleni),

	CONSTRAINT FK_ZaposleniOprema_Oprema FOREIGN KEY (IDOprema)
	REFERENCES Oprema(IDOprema)
);
GO

CREATE TABLE ScenaZaposleni
(
	IDScena int NOT NULL,
	IDZaposleni int NOT NULL,

	PRIMARY KEY (IDScena, IDZaposleni),

	CONSTRAINT FK_ScenaZaposleni_Scena FOREIGN KEY (IDScena)
	REFERENCES Scena(IDSCena),

	CONSTRAINT FK_ScenaZaposleni_Zaposleni FOREIGN KEY (IDZaposleni)
	REFERENCES Zaposleni(IDZaposleni)
);
GO

-- UNOS PODATAKA

INSERT INTO Lokacija (NazivLokacije) VALUES
(N'Centar grada'), (N'Filmski studio A'), (N'Park kod reke'), (N'Učionica 3'),
(N'Krov zgrade'), (N'Magacin opreme'), (N'Podrum muzeja'), (N'Sportska hala'),
(N'Pijaca'), (N'Autobuska stanica'), (N'Plaža'), (N'Planinski dom'), (N'Bioskopska sala'),
(N'Terasa restorana'), (N'Ulica Beogradska'), (N'Zgrada opštine'), (N'Tunel'), (N'Autoput E75'),
(N'Kafić u centru'), (N'Galerija savremene umetnosti');
GO

INSERT INTO Oprema (NazivOpreme) VALUES
(N'Kamera RED Komodo'), (N'Bum mikrofoni'), (N'LED svetla'), (N'Slider za kameru'),
(N'Dron DJI Mavic'), (N'Stativ Manfrotto'), (N'Zvučna izolacija'), (N'Monitor za režiju'),
(N'Rasveta softbox'), (N'Bežični mikrofon'), (N'Smoke machine'), (N'Green screen'),
(N'Objektiv 50mm'), (N'Objektiv 24-70mm'), (N'Kran za kameru'), (N'Boom pole'),
(N'Power bank za opremu'), (N'Tasna za opremu'), (N'Walkie-talkie'), (N'Traka za označavanje');
GO

INSERT INTO Zaposleni (Ime, Prezime, RadnoMesto) VALUES
(N'Marko', N'Petrović', N'Reditelj'), (N'Ivana', N'Jovanović', N'Kameraman'),
(N'Nikola', N'Savić', N'Tonac'), (N'Jelena', N'Pavlović', N'Svetlo majstor'),
(N'Dragan', N'Milić', N'Snimatelj drona'), (N'Milica', N'Tomić', N'Scenograf'),
(N'Petar', N'Janković', N'Reditelj zvuka'), (N'Mina', N'Djordjević', N'Montažer'),
(N'Dejan', N'Vuković', N'Producent'), (N'Anđela', N'Lukić', N'Asistent kamere'),
(N'Bojan', N'Popović', N'Vođa produkcije'), (N'Nina', N'Marković', N'Make-up artist'),
(N'Ognjen', N'Dimitrijević', N'Kostimograf'), (N'Sanja', N'Tanasković', N'Skripter'),
(N'Darko', N'Živković', N'Vozač opreme'), (N'Kristina', N'Babić', N'Snimatelj II'),
(N'Marko', N'Ćosić', N'Pomoćnik režije'), (N'Danica', N'Kovačević', N'Set dizajner'),
(N'Igor', N'Ristić', N'Asistent produkcije'), (N'Jovana', N'Petrić', N'Koordinator lokacije');
GO

INSERT INTO Scena (RedniBroj, IDLokacija, DobaDana, Snimljeno) VALUES
(1, 1, N'Jutro', 1), (2, 3, N'Dan', 1), (3, 5, N'Noć', 0), (4, 2, N'Dan', 1),
(5, 8, N'Veče', 0), (6, 4, N'Jutro', 1), (7, 6, N'Noć', 0), (8, 9, N'Dan', 1),
(9, 7, N'Jutro', 0), (10, 10, N'Noć', 1), (11, 11, N'Dan', 1), (12, 12, N'Veče', 0),
(13, 13, N'Dan', 1), (14, 14, N'Noć', 0), (15, 15, N'Jutro', 1), (16, 16, N'Dan', 0),
(17, 17, N'Veče', 1), (18, 18, N'Noć', 1), (19, 19, N'Dan', 1), (20, 20, N'Jutro', 0);
GO

INSERT INTO ZaposleniOprema (IDZaposleni, IDOprema) VALUES
(1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6), (4, 7), (4, 8),
(5, 9), (5, 10), (6, 11), (6, 12), (7, 13), (7, 14), (8, 15), (8, 16),
(9, 17), (9, 18), (10, 19), (10, 20), (11, 1), (11, 3), (12, 5), (12, 7),
(13, 9), (13, 11), (14, 13), (14, 15), (15, 17), (15, 19), (16, 2), (16, 4),
(17, 6), (17, 8), (18, 10), (18, 12), (19, 14), (19, 16), (20, 18), (20, 20);
GO

INSERT INTO ScenaZaposleni (IDScena, IDZaposleni) VALUES
(1, 1), (1, 2), (2, 3), (2, 4), (3, 5), (3, 6), (4, 7), (4, 8),
(5, 9), (5, 10), (6, 11), (6, 12), (7, 13), (7, 14), (8, 15), (8, 16),
(9, 17), (9, 18), (10, 19), (10, 20), (11, 1), (11, 3), (12, 5), (12, 7),
(13, 9), (13, 11), (14, 13), (14, 15), (15, 17), (15, 19), (16, 2), (16, 4),
(17, 6), (17, 8), (18, 10), (18, 12), (19, 14), (19, 16), (20, 18), (20, 20);
GO

-- UPITI

-- 1. Pregled svih lokacija
SELECT * FROM Lokacija;

-- 2. Prikaz svih scena sa nazivom lokacije i da li su snimljene
SELECT 
    s.IDScena,
    s.RedniBroj,
    l.NazivLokacije,
    s.DatumSnimanja,
    s.DobaDana,
    CASE WHEN s.Snimljeno = 1 THEN 'Da' ELSE 'Ne' END AS Snimljeno
FROM Scena s
JOIN Lokacija l ON s.IDLokacija = l.IDLokacija;

-- 3. Koja oprema je dodeljena kom zaposlenom
SELECT 
    z.Ime + ' ' + z.Prezime AS Zaposleni,
    o.NazivOpreme
FROM ZaposleniOprema zo
JOIN Zaposleni z ON zo.IDZaposleni = z.IDZaposleni
JOIN Oprema o ON zo.IDOprema = o.IDOprema
ORDER BY Zaposleni;

-- 4. Ko je radio na kojoj sceni
SELECT 
    s.IDScena,
    s.RedniBroj,
    z.Ime + ' ' + z.Prezime AS Zaposleni,
    z.RadnoMesto
FROM ScenaZaposleni sz
JOIN Scena s ON sz.IDScena = s.IDScena
JOIN Zaposleni z ON sz.IDZaposleni = z.IDZaposleni
ORDER BY s.IDScena, z.Prezime;

-- 5. Scene koje su snimane po doba dana
SELECT 
    DobaDana,
    COUNT(*) AS BrojScena
FROM Scena
GROUP BY DobaDana;

-- 6. Sve snimljene scene i njihovi zaposleni
SELECT 
    s.IDScena,
    s.RedniBroj,
    z.Ime + ' ' + z.Prezime AS Zaposleni
FROM Scena s
JOIN ScenaZaposleni sz ON s.IDScena = sz.IDScena
JOIN Zaposleni z ON sz.IDZaposleni = z.IDZaposleni
WHERE s.Snimljeno = 1
ORDER BY s.IDScena;

-- 7. Broj zaposlenih po radnom mestu
SELECT 
    RadnoMesto,
    COUNT(*) AS BrojZaposlenih
FROM Zaposleni
GROUP BY RadnoMesto
ORDER BY BrojZaposlenih DESC;

-- 8. Koliko opreme koristi svaki zaposleni
SELECT 
    z.Ime + ' ' + z.Prezime AS Zaposleni,
    COUNT(*) AS BrojOpreme
FROM ZaposleniOprema zo
JOIN Zaposleni z ON zo.IDZaposleni = z.IDZaposleni
GROUP BY z.Ime, z.Prezime
ORDER BY BrojOpreme DESC;