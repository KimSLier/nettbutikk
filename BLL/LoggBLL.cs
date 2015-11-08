using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.DAL;
using NettButikk.Model;

namespace NettButikk.BLL
{
    public class LoggBLL
    {
        public bool Lagre(LoggModel logg) {
            LoggDAL loggDal = new LoggDAL();
            return loggDal.Lagre(logg);
        }

        public List<LoggModel> HentAlleLogg() {
            LoggDAL loggDal = new LoggDAL();
            return loggDal.HentAlleLogg();
        }
    }
}
