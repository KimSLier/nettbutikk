using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.Model;

namespace NettButikk.DAL
{
    public class BrukerDAL
    {
        public bool RegistrerBruker(Bruker innBruker) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var nyBruker = new Brukere();
                    byte[] passordDb = lagHash(innBruker.Passord);
                    nyBruker.Passord = passordDb;
                    nyBruker.Brukernavn = innBruker.Navn;
                    db.Brukere.Add(nyBruker);
                    db.SaveChanges();
                    return true;
                }
            }
            catch {
                return false;
            }
            
        }

        public bool LoggInn(Bruker innBruker) {
            try
            {
                return Bruker_i_DB(innBruker);
            }
            catch {
                return false;
            }
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        private static bool Bruker_i_DB(Bruker innBruker)
        {
            using (var db = new ButikkContext())
            {
                byte[] passordDb = lagHash(innBruker.Passord);
                Brukere funnetBruker = db.Brukere.FirstOrDefault
                    (b => b.Passord == passordDb && b.Brukernavn == innBruker.Navn);
                if (funnetBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
