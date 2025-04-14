using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL___Sloj_Podataka
{
    public class XML_SerializationRepository
    {
        private SqlConnection sc = new SqlConnection();
        private SqlDataAdapter daScena = new SqlDataAdapter();
        private DataSet ds = new DataSet();

        private static XML_SerializationRepository instance = null;

        public static XML_SerializationRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XML_SerializationRepository();
                }
                return instance;
            }
        }

        public XML_SerializationRepository()
        {
            var mf = ConfigurationManager.ConnectionStrings["MazinaFilm"];
            sc.ConnectionString = mf.ConnectionString;
        }

        public void AddRelationships()
        {
            // Relationship between Scena and ScenaZaposleni
            DataRelation sceneRelation = new DataRelation(
                "FK_ScenaZaposleni_Scena",
                ds.Tables["Scena"].Columns["IDScena"],              
                ds.Tables["ScenaZaposleni"].Columns["IDScena"]
            );
            ds.Relations.Add(sceneRelation);

            // Relationship between Zaposleni and ScenaZaposleni
            DataRelation employeeRelation = new DataRelation(
                "FK_ScenaZaposleni_Zaposleni",
                ds.Tables["Zaposleni"].Columns["IDZaposleni"],
                ds.Tables["ScenaZaposleni"].Columns["IDZaposleni"]
            );
            ds.Relations.Add(employeeRelation);
        }

        public DataSet FillDataSet()
        {
            string[] tableNames = {"Zaposleni", "Scena", "ScenaZaposleni"};

            foreach (string tableName in tableNames)
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {tableName}", sc);
                adapter.Fill(ds, tableName);
            }

            AddRelationships();

            return ds;
        }

        public bool SerializeToXML()
        {
            try
            {
                FillDataSet();

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                ds.WriteXml($"{desktopPath}_schema.xml", XmlWriteMode.WriteSchema);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving XML: {ex.Message}");
                return false;
            }
        }
    }
}
