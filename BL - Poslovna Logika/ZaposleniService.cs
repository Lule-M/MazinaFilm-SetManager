using DL___Sloj_Podataka;
using Shared;

using System.Collections.Generic;

namespace BL___Poslovna_Logika
{
    public class ZaposleniService
    {
        private ZaposleniRepository zapRepo = ZaposleniRepository.Instance;
        private static ZaposleniService instance = null;

        public static ZaposleniService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ZaposleniService();
                }
                return instance;
            }
        }

        public List<Zaposleni> GetAllZaposleni()
        {
            return zapRepo.GetAllZaposleni();
        }

        public Zaposleni GetZaposleni(int id)
        {
            return zapRepo.GetZaposleni(id);
        }

        public bool UpdateZaposleni(Zaposleni zaposleni)
        {
            zapRepo.Update(zaposleni);
            return true;
        }

        public bool InsertZaposleni(Zaposleni zaposleni)
        {
            zapRepo.InsertIntoDataTable(zaposleni);
            return true;
        }

        public bool DeleteZaposleni(int id)
        {
            zapRepo.Delete(id);
            return true;
        }
    }
}
