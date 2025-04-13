using Shared;
using DL___Sloj_Podataka;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL___Poslovna_Logika
{
    public class LokacijaService
    {
        private LokacijaRepository lokacijaRepo = LokacijaRepository.Instance;
        private static LokacijaService instance = null;

        public static LokacijaService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LokacijaService();
                }
                return instance;
            }
        }

        public List<Lokacija> GetAllLokacije()
        {
            return lokacijaRepo.GetAllLokacija();
        }

        public Lokacija GetLokacija(int id)
        {
            return lokacijaRepo.GetLokacija(id);
        }
    }
}
