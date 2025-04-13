using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Lokacija
    {
        public int IdLokacija { get; set; }
        public string Naziv { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{IdLokacija}-{Naziv}";
        }
    }

}
