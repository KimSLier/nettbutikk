using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.Model;

namespace NettButikk.DAL
{
    public class OrdrerDAL
    {
        public bool RegistrerOrdre(int prodId) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var produkter = db.Produkter.Where(p => p.ID == prodId).ToList();

                    var ordrer = new Ordrer()
                    {
                        Dato = DateTime.Now,
                        Betalt = "true",
                        Sendt = "false",
                        Produkter = produkter
                    };
                    db.Ordrer.Add(ordrer);
                    db.SaveChanges();
                    return true;
                }
            }
            catch {
                return false;
            }
                    
        }

        public bool SendOrdre(int ordreId) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var ordre = db.Ordrer.Where(p => p.ID == ordreId).FirstOrDefault();
                    ordre.Sendt = "true";
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Ordre> AlleOrdre() {
            try
            {
                using (var db = new ButikkContext())
                {
                    List<Ordre> ordrer = new List<Ordre>();
                    var ordre = db.Ordrer.ToList();
                    foreach (var o in ordre) {
                        var ord = new Ordre()
                        {
                            Dato = (DateTime)o.Dato,
                            Betalt = o.Betalt,
                            Sendt = o.Sendt
                        };
                        ordrer.Add(ord);
                    }
                    
                    return ordrer;
                }
            }
            catch
            {
                return new List<Ordre>();
            }
        }

        public List<Ordre> AlleUbehandledeOrdre() {
            try
            {
                using (var db = new ButikkContext())
                {
                    List<Ordre> ordrer = new List<Ordre>();
                    var ordre = db.Ordrer.Where(p => p.Sendt == "false").ToList();
                    foreach (var o in ordre)
                    {
                        var ord = new Ordre()
                        {
                            Dato = (DateTime)o.Dato,
                            Betalt = o.Betalt,
                            Sendt = o.Sendt
                        };
                        ordrer.Add(ord);
                    }

                    return ordrer;
                }
            }
            catch
            {
                return new List<Ordre>();
            }
        }



    }
}
