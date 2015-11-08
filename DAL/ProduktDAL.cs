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

        public bool RegistrerProdukt(Produkt produkt) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var nyttProdukt = new Produkter()
                    {
                        Navn = produkt.navn,
                        Pris = produkt.pris
                    };
                    db.Produkter.Add(nyttProdukt);
                    db.SaveChanges();
                    return true;
                }
            }
            catch {
                return false;
            }
        }

        public bool OppdaterProdukt(Produkt produkt) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var oppdaterProdukt = db.Produkter.Where(p => p.ID == produkt.id).FirstOrDefault();
                    oppdaterProdukt.Navn = produkt.navn;
                    oppdaterProdukt.Pris = produkt.pris;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SlettProdukt(int produktId)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var slettProdukt = db.Produkter.Where(p => p.ID == produktId).FirstOrDefault();
                    db.Produkter.Remove(slettProdukt);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Produkt HentProdukt(int id) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var produkt = db.Produkter.Where(p => p.ID == id).FirstOrDefault();
                    var prod = new Produkt()
                    {
                        id = produkt.ID,
                        navn = produkt.Navn,
                        pris = produkt.Pris
                    };
                    return prod;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
