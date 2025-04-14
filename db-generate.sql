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
	DatumSnimanja date DEFAULT CURRENT_TIMESTAMP,
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
	REFERENCES Zaposleni(IDZaposleni) ON DELETE CASCADE,

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
	REFERENCES Zaposleni(IDZaposleni) ON DELETE CASCADE
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

INSERT INTO Scena (RedniBroj, DatumSnimanja, IDLokacija, DobaDana, Snimljeno) VALUES
(1, DATEADD(MONTH, -3, GETDATE()), 1, N'Jutro', 1),
(2, DATEADD(MONTH, -2, GETDATE()), 3, N'Dan', 1),
(3, DATEADD(MONTH, -1, GETDATE()), 5, N'Noć', 0),
(4, DATEADD(DAY, -15, GETDATE()), 2, N'Dan', 1),
(5, DATEADD(DAY, -7, GETDATE()), 8, N'Veče', 0),
(6, GETDATE(), 4, N'Jutro', 1),
(7, DATEADD(DAY, 7, GETDATE()), 6, N'Noć', 0),
(8, DATEADD(DAY, 15, GETDATE()), 9, N'Dan', 1),
(9, DATEADD(MONTH, 1, GETDATE()), 7, N'Jutro', 0),
(10, DATEADD(MONTH, 2, GETDATE()), 10, N'Noć', 1),
(11, DATEADD(MONTH, 3, GETDATE()), 11, N'Dan', 1),
(12, DATEADD(DAY, -45, GETDATE()), 12, N'Veče', 0),
(13, DATEADD(DAY, -30, GETDATE()), 13, N'Dan', 1),
(14, DATEADD(DAY, -10, GETDATE()), 14, N'Noć', 0),
(15, DATEADD(DAY, 10, GETDATE()), 15, N'Jutro', 1),
(16, DATEADD(DAY, 30, GETDATE()), 16, N'Dan', 0),
(17, DATEADD(DAY, 45, GETDATE()), 17, N'Veče', 1),
(18, DATEADD(MONTH, -2, DATEADD(DAY, -5, GETDATE())), 18, N'Noć', 1),
(19, DATEADD(MONTH, 1, DATEADD(DAY, 5, GETDATE())), 19, N'Dan', 1),
(20, DATEADD(MONTH, 3, DATEADD(DAY, -2, GETDATE())), 20, N'Jutro', 0),
(21, DATEADD(DAY, -25, GETDATE()), 3, N'Jutro', 1),
(22, DATEADD(DAY, -18, GETDATE()), 5, N'Dan', 0),
(23, DATEADD(DAY, -12, GETDATE()), 1, N'Veče', 1),
(24, DATEADD(DAY, -8, GETDATE()), 8, N'Noć', 0),
(25, DATEADD(DAY, -5, GETDATE()), 2, N'Dan', 1),
(26, DATEADD(DAY, -3, GETDATE()), 4, N'Jutro', 0),
(27, DATEADD(DAY, -1, GETDATE()), 6, N'Veče', 1),
(28, DATEADD(DAY, 2, GETDATE()), 9, N'Noć', 0),
(29, DATEADD(DAY, 4, GETDATE()), 7, N'Dan', 1),
(30, DATEADD(DAY, 6, GETDATE()), 10, N'Jutro', 0),
(31, DATEADD(DAY, 9, GETDATE()), 11, N'Veče', 1),
(32, DATEADD(DAY, 12, GETDATE()), 12, N'Noć', 0),
(33, DATEADD(DAY, 16, GETDATE()), 13, N'Dan', 1),
(34, DATEADD(DAY, 20, GETDATE()), 14, N'Jutro', 0),
(35, DATEADD(DAY, 25, GETDATE()), 15, N'Veče', 1),
(36, DATEADD(MONTH, -4, GETDATE()), 16, N'Noć', 0),
(37, DATEADD(MONTH, -3, DATEADD(DAY, -10, GETDATE())), 17, N'Dan', 1),
(38, DATEADD(MONTH, -2, DATEADD(DAY, 3, GETDATE())), 18, N'Jutro', 0),
(39, DATEADD(MONTH, -1, DATEADD(DAY, -7, GETDATE())), 19, N'Veče', 1),
(40, DATEADD(MONTH, 1, DATEADD(DAY, 8, GETDATE())), 20, N'Noć', 0),
(41, DATEADD(MONTH, 2, DATEADD(DAY, -15, GETDATE())), 1, N'Dan', 1),
(42, DATEADD(MONTH, 3, DATEADD(DAY, 10, GETDATE())), 3, N'Jutro', 0),
(43, DATEADD(WEEK, -3, GETDATE()), 5, N'Veče', 1),
(44, DATEADD(WEEK, -1, GETDATE()), 8, N'Noć', 0),
(45, DATEADD(WEEK, 1, GETDATE()), 2, N'Dan', 1),
(46, DATEADD(WEEK, 2, GETDATE()), 4, N'Jutro', 0),
(47, DATEADD(WEEK, 3, GETDATE()), 6, N'Veče', 1),
(48, DATEADD(HOUR, -36, GETDATE()), 9, N'Noć', 0),
(49, DATEADD(HOUR, -12, GETDATE()), 7, N'Dan', 1),
(50, DATEADD(HOUR, 24, GETDATE()), 10, N'Jutro', 0);

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
(17, 6), (17, 8), (18, 10), (18, 12), (19, 14), (19, 16), (20, 18), (20, 20),
(21, 1), (21, 3), (21, 5), (21, 7), (22, 2), (22, 4), (22, 6), (22, 8),
(23, 6), (23, 8), (23, 10), (23, 12), (24, 7), (24, 9), (24, 11), (24, 13),
(25, 11), (25, 13), (25, 15), (25, 17), (26, 12), (26, 14), (26, 16), (26, 18),
(27, 16), (27, 18), (27, 20), (27, 2), (28, 1), (28, 3), (28, 5), (28, 7),
(29, 5), (29, 7), (29, 9), (29, 11), (30, 2), (30, 4), (30, 6), (30, 8),
(31, 6), (31, 8), (31, 10), (31, 12), (32, 11), (32, 13), (32, 15), (32, 17),
(33, 15), (33, 17), (33, 19), (33, 1), (34, 12), (34, 14), (34, 16), (34, 18),
(35, 16), (35, 18), (35, 20), (35, 2), (36, 1), (36, 2), (36, 3), (36, 4),
(37, 3), (37, 5), (37, 7), (37, 9), (38, 4), (38, 6), (38, 8), (38, 10),
(39, 8), (39, 10), (39, 12), (39, 14), (40, 9), (40, 11), (40, 13), (40, 15),
(41, 13), (41, 15), (41, 17), (41, 19), (42, 14), (42, 16), (42, 18), (42, 20),
(43, 18), (43, 20), (43, 2), (43, 4), (44, 1), (44, 3), (44, 5), (44, 7),
(45, 5), (45, 7), (45, 9), (45, 11), (46, 6), (46, 8), (46, 10), (46, 12),
(47, 10), (47, 12), (47, 14), (47, 16), (48, 11), (48, 13), (48, 15), (48, 17),
(49, 15), (49, 17), (49, 19), (49, 1), (50, 16), (50, 18), (50, 20), (50, 2);
GO

-- STORED PROCEDURE ZA UNOS

CREATE PROCEDURE ProcInsertZaposleni
    @Ime nvarchar(20),
    @Prezime nvarchar(20),
    @RadnoMesto nvarchar(50),
    @IDScena int = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        INSERT INTO Zaposleni (Ime, Prezime, RadnoMesto)
        VALUES (@Ime, @Prezime, @RadnoMesto);
        
		DECLARE @IDZaposleni int;
        SET @IDZaposleni = SCOPE_IDENTITY();
        
        IF @IDScena IS NOT NULL
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM Scena WHERE IDScena = @IDScena)
                THROW 50001, 'Scena sa navedenim ID ne postoji.', 1;
                
            INSERT INTO ScenaZaposleni (IDScena, IDZaposleni)
            VALUES (@IDScena, @IDZaposleni);
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        THROW;
    END CATCH
END;
GO

-- STORED PROCEDURE ZA UPDATE

CREATE PROCEDURE ProcUpdateZaposleni
    @IDZaposleni int,
    @Ime nvarchar(20) = NULL,
    @Prezime nvarchar(20) = NULL,
    @RadnoMesto nvarchar(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF NOT EXISTS (SELECT 1 FROM Zaposleni WHERE IDZaposleni = @IDZaposleni)
        BEGIN
            THROW 50002, 'Zaposleni sa navedenim ID ne postoji.', 1;
        END
        
        UPDATE Zaposleni
        SET 
            Ime = ISNULL(@Ime, Ime),
            Prezime = ISNULL(@Prezime, Prezime),
            RadnoMesto = ISNULL(@RadnoMesto, RadnoMesto)
        WHERE IDZaposleni = @IDZaposleni;
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
            
        THROW;
    END CATCH
END;
GO

-- UPITI

-- Pregled svih lokacija
SELECT * FROM Lokacija;

-- Pregled svih zaposlenih
SELECT * FROM Zaposleni;

-- Prikaz svih scena sa nazivom lokacije i da li su snimljene
SELECT 
    s.IDScena,
    s.RedniBroj,
    l.NazivLokacije,
    s.DatumSnimanja,
    s.DobaDana,
    CASE WHEN s.Snimljeno = 1 THEN 'Da' ELSE 'Ne' END AS Snimljeno
FROM Scena s
JOIN Lokacija l ON s.IDLokacija = l.IDLokacija;

-- Ko je radio na kojoj sceni
SELECT 
    s.IDScena,
    s.RedniBroj,
    z.Ime + ' ' + z.Prezime AS Zaposleni,
    z.RadnoMesto
FROM ScenaZaposleni sz
JOIN Scena s ON sz.IDScena = s.IDScena
JOIN Zaposleni z ON sz.IDZaposleni = z.IDZaposleni
ORDER BY s.IDScena, z.Prezime;