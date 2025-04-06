using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Scena
    {
        private int idScena;
        private  int redniBroj;
        private DateTime datumSnimanja;
        private int idLokacija;
        private string dobaDana;
        private bool snimljeno;

        public int IdScena { get; set; }
        public int RedniBroj { get; set; }
        public DateTime DatumSnimanja { get; set; }
        public int IdLokacija { get; set; }
        public string DobaDana { get; set; }
        public bool Snimljeno { get; set; }
        public List<Zaposleni> Zaposleni { get; set; } = new List<Zaposleni>();
    }
}
