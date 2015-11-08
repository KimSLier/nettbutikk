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
        //registrerer ny bruker.
        public bool RegistrerBruker(Bruker innBruker) {
            try
            {
                using (var db = new ButikkContext())
                {
                    var nyBruker = new Brukere();
                    byte[] passordDb = lagHash(innBruker.Passord);
                    nyBruker.Passord = passordDb;
                    nyBruker.Brukernavn = innBruker.Navn;
                    if (innBruker.Navn.ToLower().Equals("admin"))
                    {
                        nyBruker.Rolle = "admin";
                    }
                    else {
                        nyBruker.Rolle = "kunde";
                    }
                    db.Brukere.Add(nyBruker);
                    db.SaveChanges();
                    return true;
                }
            }
            catch {
                return false;
            }
            
        }

        //Prøver å logge brukeren inn.
        public bool LoggInn(Bruker innBruker) {
            try
            {
                return Bruker_i_DB(innBruker);
            }
            catch {
                return false;
            }
        }

        //Henter brukerens rolle
        public string BrukerRolle(Bruker innBruker)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    
                    byte[] passordDb = lagHash(innBruker.Passord);
                    var bruker = db.Brukere.Where(b => b.Brukernavn == innBruker.Navn && b.Passord == passordDb).FirstOrDefault();
                    return bruker.Rolle;
                }
            }
            catch
            {
                return "kunde";
            }

        }

        //Oppdaterer brukerens rolle
        public bool OppdaterBrukerRolle(Bruker innBruker, string rolle)
        {
            try
            {
                using (var db = new ButikkContext())
                {

                    byte[] passordDb = lagHash(innBruker.Passord);
                    var bruker = db.Brukere.Where(b => b.Brukernavn == innBruker.Navn && b.Passord == passordDb).FirstOrDefault();
                    bruker.Rolle = rolle;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //Private metoder
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
