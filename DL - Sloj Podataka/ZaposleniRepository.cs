using Shared;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DL___Sloj_Podataka
{
    public class ZaposleniRepository
    {
        private SqlConnection sc = new SqlConnection();
        private SqlDataAdapter daZaposleni = new SqlDataAdapter();
        private DataTable dtZaposleni = new DataTable();

        private static ZaposleniRepository instance = null;

        public static ZaposleniRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ZaposleniRepository();
                }
                return instance;
            }
        }

        private ZaposleniRepository()
        {
            var mf = ConfigurationManager.ConnectionStrings["MazinaFilm"];
            sc.ConnectionString = mf.ConnectionString;
            LoadZaposleni();
        }

        private void LoadZaposleni()
        {
            dtZaposleni.Clear();

            var cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT *  FROM Zaposleni";
            daZaposleni.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daZaposleni);

            sc.Open();
            daZaposleni.Fill(dtZaposleni);
            daZaposleni.UpdateCommand = cb.GetUpdateCommand();
            sc.Close();
        }

        public bool InsertIntoDb(string ime, string prezime, string radnoMesto, int? idScena)
        {
            if (sc.State == ConnectionState.Closed)
            {
                sc.Open();
            }

            using (SqlTransaction tran = sc.BeginTransaction())
            {
                try
                {
                    var cmd = sc.CreateCommand();

                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProcInsertZaposleni";
                    cmd.Parameters.AddWithValue("@Ime", ime);
                    cmd.Parameters.AddWithValue("@Prezime", prezime);
                    cmd.Parameters.AddWithValue("@RadnoMesto", radnoMesto);
                    cmd.Parameters.AddWithValue("@IDScena", idScena);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        tran.Rollback();
                        return false;
                    }

                    tran.Commit();
                    sc.Close();
                    LoadZaposleni();    
                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error inserting data: " + ex.Message); // Consider logging the exception or handling it appropriately in the UI
                }
                finally
                {
                    sc.Close();
                }
            }
        }

        public bool InsertIntoDataTable(Zaposleni zaposleni)
        {
            DataRow dr = dtZaposleni.NewRow();

            dr["IDZaposleni"] = zaposleni.IDZaposleni;
            dr["Ime"] = zaposleni.Ime;
            dr["Prezime"] = zaposleni.Prezime;
            dr["RandoMesto"] = zaposleni.RadnoMesto;

            dtZaposleni.Rows.Add(dr);
            return true;
        }

        private void UpdateDb()
        {
            daZaposleni.Update(dtZaposleni);
            LoadZaposleni();
        }

        public bool Update(int idZaposleni, string ime, string prezime, string radnoMesto)
        {
            if (sc.State == ConnectionState.Closed)
            {
                sc.Open();
            }

            using (SqlTransaction tran = sc.BeginTransaction())
            {
                try
                {
                    var cmd = sc.CreateCommand();

                    cmd.Transaction = tran;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ProcUpdateZaposleni";
                    cmd.Parameters.AddWithValue("@IDZaposleni", idZaposleni);
                    cmd.Parameters.AddWithValue("@Ime", ime);
                    cmd.Parameters.AddWithValue("@Prezime", prezime);
                    cmd.Parameters.AddWithValue("@RadnoMesto", radnoMesto);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        tran.Rollback();
                        return false;
                    }

                    tran.Commit();
                    sc.Close();
                    LoadZaposleni();

                    return true;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error inserting data: " + ex.Message); // Consider logging the exception or handling it appropriately in the UI
                }
                finally
                {
                    sc.Close();
                }
            }
        }

        public bool Delete(int id)
        {
            dtZaposleni.Select("IDZaposleni =" + id.ToString())[0].Delete();

            UpdateDb();
            return true;
        }

        public Zaposleni GetZaposleni(int id)
        {
            DataRow dr = dtZaposleni.Select("IDZaposleni =" + id.ToString())[0];
            Zaposleni zaposleni = new Zaposleni();

            zaposleni.IDZaposleni = Int32.Parse(dr["IDZaposleni"].ToString());
            zaposleni.Ime = dr["Ime"].ToString();
            zaposleni.Prezime = dr["Prezime"].ToString();
            zaposleni.RadnoMesto = dr["RadnoMesto"].ToString();

            return zaposleni;
        }

        public List<Zaposleni> GetAllZaposleni()
        {
            List<Zaposleni> zaposleniList = new List<Zaposleni>();

            foreach (DataRow dr in dtZaposleni.Rows)
            {
                Zaposleni zaposleni = new Zaposleni();

                zaposleni.IDZaposleni = int.Parse(dr["IDZaposleni"].ToString());
                zaposleni.Ime = dr["Ime"].ToString();
                zaposleni.Prezime = dr["Prezime"].ToString();
                zaposleni.RadnoMesto = dr["RadnoMesto"].ToString();
                zaposleniList.Add(zaposleni);
            }

            return zaposleniList;
        }

        public void InsertIntoDataTable(string ime, string prezime, string radnoMesto, int? idScena)
        {
            throw new NotImplementedException();
        }
    }
}