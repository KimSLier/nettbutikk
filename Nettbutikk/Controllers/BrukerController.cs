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
            if ((innBruker.Navn != string.Empty || innBruker.Navn != null) && 
                (innBruker.Passord != string.Empty || innBruker.Passord != null))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
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
                    return RedirectToAction("Index");
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
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
    }
}