using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.Model;

namespace NettButikk.DAL
{
    public class ProduktDAL
    {
        public List<Produkt> hentAlle()
        {
            var db = new ButikkContext();
            List<Produkt> alleProdukter = db.Produkter.Select(p => new Produkt()
            {
                id = p.ID,
                navn = p.Navn,
                pris = p.Pris
            }
                                ).ToList();
            return alleProdukter;
        }
    }
}
