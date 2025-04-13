using Shared;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DL___Sloj_Podataka
{
    public class ScenaRepository
    {
        private SqlConnection sc = new SqlConnection();
        private SqlDataAdapter daScena = new SqlDataAdapter();
        private DataTable dtScena = new DataTable();

        private static ScenaRepository instance = null;

        public static ScenaRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScenaRepository();
                }
                return instance;
            }
        }

        private ScenaRepository()
        {
            var mf = ConfigurationManager.ConnectionStrings["MazinaFilm"];
            sc.ConnectionString = mf.ConnectionString;
            LoadScena();
        }

        private void LoadScena()
        {
            dtScena.Clear();

            var cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Scena";
            daScena.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daScena);

            sc.Open();
            daScena.Fill(dtScena);
            daScena.UpdateCommand = cb.GetUpdateCommand();
            sc.Close();
        }

        public bool InsertIntoDb(int redniBroj, DateTime datumSnimanja, int idLokacija, string dobaDana, bool snimljeno)
        {
            if (sc.State == ConnectionState.Closed)
            {
                sc.Open();
            }
            
            using (SqlTransaction tran = sc.BeginTransaction())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Scena (RedniBroj, DatumSnimanja, IdLokacija, DobaDana, Snimljeno) VALUES (@RedniBroj, @DatumSnimanja, @IdLokacija, @DobaDana, @Snimljeno)", sc);
                    
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@RedniBroj", redniBroj);
                    cmd.Parameters.AddWithValue("@DatumSnimanja", datumSnimanja);
                    cmd.Parameters.AddWithValue("@IdLokacija", idLokacija);
                    cmd.Parameters.AddWithValue("@DobaDana", dobaDana);
                    cmd.Parameters.AddWithValue("@Snimljeno", snimljeno);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        tran.Rollback();
                        return false;
                    }

                    tran.Commit();
                    LoadScena();
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error inserting data: " + ex.Message);
                }
                finally
                {
                    sc.Close();
                }
            }

        }

        public bool InsertIntoDataTable(Scena scena)
        {
            DataRow dr = dtScena.NewRow();

            dr["IDScena"] = scena.IdScena;
            dr["RedniBroj"] = scena.RedniBroj;
            dr["DatumSnimanja"] = scena.DatumSnimanja;
            dr["IdLokacija"] = scena.IdLokacija;
            dr["DobaDana"] = scena.DobaDana;
            dr["Snimljeno"] = scena.Snimljeno;

            dtScena.Rows.Add(dr);
            return true;
        }

        private void UpdateDb()
        {
            daScena.Update(dtScena);
            LoadScena();
        }

        public bool Update(Scena scena)
        {
            DataRow dr = dtScena.Select("IDScena =" + scena.RedniBroj.ToString())[0];

            dr["IDScena"] = scena.IdScena;
            dr["RedniBroj"] = scena.RedniBroj.ToString();
            dr["DatumSnimanja"] = scena.DatumSnimanja;
            dr["IdLokacija"] = scena.IdLokacija;
            dr["DobaDana"] = scena.DobaDana;
            dr["Snimljeno"] = scena.Snimljeno;

            UpdateDb();
            return true;
        }

        public bool Delete(int id)
        {
            dtScena.Select("IDScena =" + id.ToString())[0].Delete();

            UpdateDb();
            return true;
        }

        public Scena GetScena(int id)
        {
            DataRow dr = dtScena.Select("IDScena =" + id.ToString())[0];

            Scena scena = new Scena();

            scena.IdScena = int.Parse(dr["IDScena"].ToString());
            scena.RedniBroj = int.Parse(dr["RedniBroj"].ToString());
            scena.DatumSnimanja = DateTime.Parse(dr["DatumSnimanja"].ToString());
            scena.IdLokacija = int.Parse(dr["IdLokacija"].ToString());
            scena.DobaDana = dr["DobaDana"].ToString();
            scena.Snimljeno = bool.Parse(dr["Snimljeno"].ToString());
            scena.Zaposleni = GetZaposleniNaSceni(scena.RedniBroj);

            return scena;
        }

        public List<Scena> GetAllScena()
        {
            List<Scena> scenaList = new List<Scena>();

            foreach (DataRow dr in dtScena.Rows)
            {
                Scena scena = new Scena();

                scena = GetScena(int.Parse(dr["IDScena"].ToString()));

                scenaList.Add(scena);

            }
            return scenaList;
        }

        public List<Scena> GetAllScena(int idLokacija)
        {
            List<Scena> scenaList = new List<Scena>();

            foreach (DataRow dr in dtScena.Rows)
            {
                if (int.Parse(dr["IDLokacija"].ToString()) != idLokacija)
                    continue;

                Scena scena = new Scena();

                scena = GetScena(int.Parse(dr["IDScena"].ToString()));

                scenaList.Add(scena);
            }
            return scenaList;
        }

        private  List<Zaposleni> GetZaposleniNaSceni(int idScena)
        {
            List<Zaposleni> zaposleniList = new List<Zaposleni>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = sc;
                cmd.CommandText = @"
                                    SELECT z.* 
                                    FROM Zaposleni z
                                    INNER JOIN ScenaZaposleni sz ON z.IDZaposleni = sz.IDZaposleni
                                    WHERE sz.IDScena = @IDScena";

                cmd.Parameters.AddWithValue("@IDScena", idScena);

                sc.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        zaposleniList.Add(new Zaposleni()
                        {
                            IDZaposleni = (int)dr["IDZaposleni"],
                            Ime = dr["Ime"].ToString(),
                            Prezime = dr["Prezime"].ToString(),
                            RadnoMesto = dr["RadnoMesto"].ToString()
                        });
                    }
                }
                sc.Close();
            }

            return zaposleniList;
        }

        public bool DodajZaposlenogNaScenu(int idScena, int idZaposleni)
        {
            try
            {
                using (SqlTransaction tran = sc.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ScenaZaposleni (IDScena, IDZaposleni) VALUES (@IDScena, @IDZaposleni)", sc);
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@IDScena", idScena);
                    cmd.Parameters.AddWithValue("@IDZaposleni", idZaposleni);

                    sc.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        tran.Rollback();
                        return false;
                    }

                    tran.Commit();
                    return true;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Greška pri dodavanju zaposlenog na scenu: " + ex.Message);
            }
        }

        public bool UkloniZaposlenogSaScene(int scenaId, int zaposleniId)
        {
            try
            {
                using(SqlTransaction tran = sc.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM ScenaZaposleni WHERE ScenaId = @ScenaId AND ZaposleniId = @ZaposleniId", sc);
                    cmd.Transaction = tran;
                    cmd.Parameters.AddWithValue("@ScenaId", scenaId);
                    cmd.Parameters.AddWithValue("@ZaposleniId", zaposleniId);

                    sc.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        tran.Rollback();
                        return false;
                    }

                    tran.Commit();
                    return true;
                }
               
            }
            catch (SqlException ex)
            {
                throw new Exception("Greška pri uklanjanju zaposlenog sa scene: " + ex.Message);
            }
        }


    }
}
