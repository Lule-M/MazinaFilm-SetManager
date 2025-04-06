using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Zaposleni
    {
        private int idZaposleni;
        private string ime;
        private string prezime;
        private string radnoMesto;

        public int IDZaposleni { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string RadnoMesto { get; set; } = string.Empty;
    }
}
