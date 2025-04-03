CREATE DATABASE mazinafilm;
GO
USE mazinafilm;
GO

-- KREIRANJE TABELA

--    ┌──────────────────┐                                                                 
--    │      Scena       │░                ┌──────────────────────┐                        
--    │                  │░0:n         1:1 │       Lokacija       │░                       
--    │IDScena    :int   ├─────────────────┤                      │░                       
--    │Redni_broj :int   │░                │IDLokacija     :int   │░                       
--    │IDLokacija :int   │░                │Naziv_lokacije :string│░                       
--    │Doba_dana  :string│░                └──────────────────────┘░                       
--    └─────────┬────────┘░                 ░░░░░░░░░░░░░░░░░░░░░░░░                       
--     ░░░░░░░░░│░1:n░░░░░░                                                                
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
--    ┌─────────┴──────────┐                                                               
--    │     Zaposleni      │░          ┌────────────────┐           ┌────────────────────┐ 
--    │                    │░          │ZaposleniOprema │░          │       Oprema       │░
--    │IDZaposleni :int    │░1:n   0:n │                │░0:n   1:n │                    │░
--    │Ime         :string ├───────────┤IDZaposleni :int├───────────┤IDOprema :int       │░
--    │Prezime     :string │░          │IDOprema    :int│░          │Naziv_opreme :string│░
--    │Radno_mesto :string │░          └────────────────┘░          └────────────────────┘░
--    └────────────────────┘░           ░░░░░░░░░░░░░░░░░░           ░░░░░░░░░░░░░░░░░░░░░░
--     ░░░░░░░░░░░░░░░░░░░░░░                                                              


CREATE TABLE