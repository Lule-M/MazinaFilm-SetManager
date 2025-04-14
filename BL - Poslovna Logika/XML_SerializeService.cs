using DL___Sloj_Podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL___Poslovna_Logika
{
    public class XML_SerializeService
    {
        private XML_SerializationRepository xmlSerializationRepo = XML_SerializationRepository.Instance;
        private static XML_SerializeService instance = null;

        public static XML_SerializeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new XML_SerializeService();
                }
                return instance;
            }
        }

        public bool SerializeToXML()
        {
            return xmlSerializationRepo.SerializeToXML();
        }
    }
}
