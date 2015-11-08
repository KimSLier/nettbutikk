using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettButikk.Model;
using NettButikk.BLL;

namespace Nettbutikk.Controllers
{
    public class BrukerInfoController : Controller
    {
        // GET: BrukerInfo
        public ActionResult Index()
        {
            if (Session["LoggetInn"] == null) {
                RedirectToAction("Index", "Home");
            }

            try
            {
                var brukerInfo = new BrukerInfoBLL();
                var brukernavn = Session["Brukernavn"].ToString();
                var bi = brukerInfo.HentBrukerInfo(brukernavn);
                return View(bi);
            }
            catch {
                return View();
            }
        }

        //Registrer ny brukerInfo
        public ActionResult RegistrerBrukerInfo()
        {
            if (Session["LoggetInn"] == null)
            {
                RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult RegistrerBrukerInfo(BrukerInfo brukerInfo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var brukerInfoBll = new BrukerInfoBLL();
                var brukernavn = Session["Brukernavn"].ToString();
                brukerInfo.Brukernavn = brukernavn;
                var registrert = brukerInfoBll.RegistrerBrukerInfo(brukerInfo);
                if (registrert)
                {
                    RedirectToAction("Index");
                }
                else {
                    return View();
                }
                
            }
            catch {
                return View();
            }

            return View();
        }

        //Oppdater brukerinfo
        public ActionResult OppdaterBrukerInfo()
        {
            if (Session["LoggetInn"] == null)
            {
                RedirectToAction("Index", "Home");
            }

            var brukerInfoBll = new BrukerInfoBLL();
            var brukernavn = Session["Brukernavn"].ToString();
            var bi = brukerInfoBll.HentBrukerInfo(brukernavn);
            return View(bi);
        }

        [HttpPost]
        public ActionResult OppdaterBrukerInfo(BrukerInfo brukerInfo)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var brukerInfoBll = new BrukerInfoBLL();
                var registrert = brukerInfoBll.OppdaterBrukerInfo(brukerInfo);
                if (registrert)
                {
                    RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

    }
}