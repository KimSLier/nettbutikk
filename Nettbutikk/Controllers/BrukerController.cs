using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettButikk.Model;
using NettButikk.BLL;

namespace Nettbutikk.Controllers
{
    public class BrukerController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Bruker innBruker)
        {
            var brukerBll = new BrukerBLL();
            var erInne = brukerBll.LoggInn(innBruker);
            if (erInne)
            {
                Session["Rolle"] = brukerBll.HentBrukerRolle(innBruker);
                Session["LoggetInn"] = true;
                Session["Brukernavn"] = innBruker.Navn;
                ViewBag.Innlogget = true;
                return RedirectToAction("InnLoggetSide");
            }
            else {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrer(Bruker innBruker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
                try
                {
                    var brukerBll = new BrukerBLL();
                    var result = brukerBll.RegistrerBruker(innBruker);
                if (result)
                {
                    Session["Rolle"] = brukerBll.HentBrukerRolle(innBruker);
                    Session["LoggetInn"] = true;
                    Session["Brukernavn"] = innBruker.Navn;
                    return RedirectToAction("InnLoggetSide"); //redirect til side for å legge inn brukerInfo
                }
                else {
                    return View();
                }
                
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        
        public ActionResult InnLoggetSide()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    ViewBag.HarInfo = false;
                    //Sjekker om bruker har registrert brukerinformasjon
                    string brukernavn = Session["Brukernavn"].ToString();
                    if (brukernavn != string.Empty || brukernavn != null) {
                        var brukerInfoBll = new BrukerInfoBLL();
                        bool harInfo = brukerInfoBll.BrukerHarInfo(brukernavn);
                        if (harInfo) {
                            ViewBag.HarInfo = true;
                        }
                    }
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
    }
}