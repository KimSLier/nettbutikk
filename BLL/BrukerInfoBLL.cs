using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.DAL;
using NettButikk.Model;

namespace NettButikk.BLL
{
    public class BrukerInfoBLL
    {
        public BrukerInfo HentBrukerInfo(string brukernavn)
        {
            var brukerInfoDAL = new BrukerInfoDAL();
            return brukerInfoDAL.HentBrukerInfo(brukernavn);
        }

        public bool BrukerHarInfo(string brukernavn)
        {
            var brukerInfoDAL = new BrukerInfoDAL();
            return brukerInfoDAL.BrukerHarInfo(brukernavn);
        }

        public bool RegistrerBrukerInfo(BrukerInfo brukerInfo) {
            var brukerInfoDAL = new BrukerInfoDAL();
            return brukerInfoDAL.RegistrerBrukerInfo(brukerInfo);
        }

        public bool OppdaterBrukerInfo(BrukerInfo brukerInfo)
        {
            var brukerInfoDAL = new BrukerInfoDAL();
            return brukerInfoDAL.OppdaterBrukerInfo(brukerInfo);
        }
    }
}
