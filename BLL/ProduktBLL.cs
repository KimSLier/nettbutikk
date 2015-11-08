using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.DAL;
using NettButikk.Model;

namespace NettButikk.BLL
{
    public class ProduktBLL
    {
        public List<Produkt> hentAlle()
        {
            var produktDAL = new ProduktDAL();
            List<Produkt> alleProdukter = produktDAL.hentAlle();
            return alleProdukter;
        }

        public bool RegistrerProdukt(Produkt produkt)
        {
            var produktDAL = new ProduktDAL();
            return produktDAL.RegistrerProdukt(produkt);
        }

        public bool OppdaterProdukt(Produkt produkt)
        {
            var produktDAL = new ProduktDAL();
            return produktDAL.OppdaterProdukt(produkt);

        }

        public bool SlettProdukt(int produkt)
        {
            var produktDAL = new ProduktDAL();
            return produktDAL.SlettProdukt(produkt);

        }

        public Produkt HentProdukt(int id) {
            var produktDAL = new ProduktDAL();
            return produktDAL.HentProdukt(id);
        }
    }
}
