using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.Model;

namespace NettButikk.DAL
{
    public class LoggDAL
    {
        public bool Lagre(LoggModel logg)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var nyLogg = new Logg()
                    {
                        Bruker = logg.Bruker,
                        Tidspunkt = DateTime.Now,
                        Handling = logg.Handling
                    };
                    db.Logg.Add(nyLogg);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<LoggModel> HentAlleLogg() {
            try
            {
                using (var db = new ButikkContext())
                {
                    List<LoggModel> loggList = new List<LoggModel>();
                    var loggs = db.Logg.ToList();
                    foreach (var l in loggs) {
                        var loggM = new LoggModel()
                        {
                            Tidspunkt = l.Tidspunkt,
                            Bruker = l.Bruker,
                            Handling = l.Handling
                        };
                        loggList.Add(loggM);
                    }
                    return loggList;
                }
            }
            catch
            {
                return new List<LoggModel>();
            }
        }
    }
}
