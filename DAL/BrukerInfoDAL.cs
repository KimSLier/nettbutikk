using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NettButikk.Model;

namespace NettButikk.DAL
{
    public class BrukerInfoDAL
    {
        //Registrer brukerinformasjon 
        public bool RegistrerBrukerInfo(BrukerInfo brukerInfo)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var bruker = db.Brukere.Where(b => b.Brukernavn == brukerInfo.Brukernavn).FirstOrDefault();

                    var brukerInformasjon = new Brukerinformasjon();
                    brukerInformasjon.Fornavn = brukerInfo.Fornavn;
                    brukerInformasjon.Etternavn = brukerInfo.Etternavn;
                    brukerInformasjon.Adresse = brukerInfo.Adresse;
                    brukerInformasjon.Postnr = brukerInfo.Postnr;
                    brukerInformasjon.Epost = brukerInfo.Epost;
                    brukerInformasjon.Bruker = bruker;
                    db.Brukerinformasjon.Add(brukerInformasjon);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //Oppdaterer brukerinformasjonen
        public bool OppdaterBrukerInfo(BrukerInfo brukerInfo)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var oppdater = db.Brukerinformasjon.Where(b => b.ID == brukerInfo.ID).FirstOrDefault();
                    oppdater.Fornavn = brukerInfo.Fornavn;
                    oppdater.Etternavn = brukerInfo.Etternavn;
                    oppdater.Adresse = brukerInfo.Adresse;
                    oppdater.Postnr = brukerInfo.Postnr;
                    oppdater.Epost = brukerInfo.Epost;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        //Henter brukerens brukerinfo
        public BrukerInfo HentBrukerInfo(string brukernavn)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var brukerInfo =
                    (from b in db.Brukerinformasjon
                    where b.Bruker.Brukernavn == brukernavn
                    select new BrukerInfo { ID = b.ID, Fornavn = b.Fornavn, Etternavn = b.Etternavn,
                        Adresse = b.Adresse, Postnr = b.Postnr, Epost = b.Epost, Brukernavn = b.Bruker.Brukernavn}).FirstOrDefault();
                    return brukerInfo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Sjekker om bruker har registrert brukerinformasjon.
        public bool BrukerHarInfo(string brukernavn)
        {
            try
            {
                using (var db = new ButikkContext())
                {
                    var bruker = db.Brukerinformasjon.Where(b => b.Bruker.Brukernavn == brukernavn).FirstOrDefault();
                    if (bruker != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
