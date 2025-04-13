using Shared;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DL___Sloj_Podataka
{
    public class LokacijaRepository
    {
        private SqlConnection sc = new SqlConnection();
        private SqlDataAdapter daLokacija = new SqlDataAdapter();
        private DataTable dtLokacija = new DataTable();

        private static LokacijaRepository instance = null;

        public static LokacijaRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LokacijaRepository();
                }
                return instance;
            }
        }

        private LokacijaRepository()
        {
            var mf = ConfigurationManager.ConnectionStrings["MazinaFilm"];
            sc.ConnectionString = mf.ConnectionString;
            LoadLokacija();
        }

        private void LoadLokacija()
        {
            dtLokacija.Clear();

            var cmd = sc.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Lokacija";
            daLokacija.SelectCommand = cmd;
            SqlCommandBuilder cb = new SqlCommandBuilder(daLokacija);

            sc.Open();
            daLokacija.Fill(dtLokacija);
            daLokacija.UpdateCommand = cb.GetUpdateCommand();
            sc.Close();
        }

        public Lokacija GetLokacija(int id)
        {
            DataRow dr = dtLokacija.Select("IdLokacija =" + id.ToString())[0];
            Lokacija lokacija = new Lokacija();

            lokacija.IdLokacija = Convert.ToInt32(dr["IdLokacija"]);
            lokacija.Naziv = dr["Naziv"].ToString();

            return lokacija;
        }

        public List<Lokacija> GetAllLokacija()
        {
            List<Lokacija> lokacijaList = new List<Lokacija>();

            foreach (DataRow dr in dtLokacija.Rows)
            {
                Lokacija lokacija = new Lokacija();

                lokacija.IdLokacija = Convert.ToInt32(dr["IdLokacija"]);
                lokacija.Naziv = dr["NazivLokacije"].ToString();
                lokacijaList.Add(lokacija);
            }

            return lokacijaList;
        }
    }
}
