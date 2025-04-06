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
	RedniBroj int,
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