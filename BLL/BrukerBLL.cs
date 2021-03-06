﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.DAL;
using NettButikk.Model;

namespace NettButikk.BLL
{
    public class BrukerBLL
    {
        public bool RegistrerBruker(Bruker innBruker)
        {
            var brukerDAL = new BrukerDAL();
            return brukerDAL.RegistrerBruker(innBruker);
        }

        public bool LoggInn(Bruker innBruker) {
            var brukerDAL = new BrukerDAL();
            return brukerDAL.LoggInn(innBruker);
        }

        public string HentBrukerRolle(Bruker innBruker) {
            var brukerDAL = new BrukerDAL();
            return brukerDAL.BrukerRolle(innBruker);
        }
    }
}
