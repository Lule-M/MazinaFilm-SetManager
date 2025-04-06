using DL___Sloj_Podataka;
using Shared;

using System.Collections.Generic;

namespace BL___Poslovna_Logika
{
    public class ScenaService
    {
        private ScenaRepository scenaRepo = ScenaRepository.Instance;
        private static ScenaService instance = null;
        public static ScenaService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScenaService();
                }
                return instance;
            }
        }
        public List<Scena> GetAllScene()
        {
            return scenaRepo.GetAllScena();
        }
        public Scena GetScena(int id)
        {
            return scenaRepo.GetScena(id);
        }
        public bool UpdateScena(Scena scena)
        {
            scenaRepo.Update(scena);
            return true;
        }
        public bool InsertScena(Scena scena)
        {
            scenaRepo.InsertIntoDataTable(scena);
            return true;
        }
        public bool DeleteScena(int id)
        {
            scenaRepo.Delete(id);
            return true;
        }
    }
}
