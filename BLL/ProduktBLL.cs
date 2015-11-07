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
            var ProduktDAL = new ProduktDAL();
            List<Produkt> alleProdukter = ProduktDAL.hentAlle();
            return alleProdukter;
        }
    }
}
