using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettButikk.Model;
using NettButikk.BLL;

namespace Nettbutikk.Controllers
{
    public class OrdreController : Controller
    {
        // GET: Ordre
        public ActionResult Index()
        {
            OrdrerBLL ordreBll = new OrdrerBLL();
            return View(ordreBll.AlleOrdre());
        }

        public ActionResult Send(int id)
        {
            OrdrerBLL ordreBll = new OrdrerBLL();
            ordreBll.SendOrdre(id);
            return View("Index");
        }

        public ActionResult Bestill(int id)
        {
            OrdrerBLL ordreBll = new OrdrerBLL();
            ordreBll.RegistrerOrdre(id);
            return RedirectToAction("Index", "Home");
        }


    }
}