using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettButikk.Model;
using NettButikk.BLL;

namespace Nettbutikk.Controllers
{
    public class ProdukterController : Controller
    {
        // GET: Produkter
        public ActionResult Index()
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            ProduktBLL produkt = new ProduktBLL();
            return View("index", produkt.hentAlle());
        }

        //Slett produkt
        public ActionResult SlettProdukt(int id)
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            ProduktBLL produktBll = new ProduktBLL();
            var produkt = produktBll.SlettProdukt(id);
            return RedirectToAction("Index");
        }

        //Registrer produkt
        public ActionResult RegistrerProdukt()
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerProdukt(Produkt produkt)
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            try
            {
                ProduktBLL produktBll = new ProduktBLL();
                produktBll.RegistrerProdukt(produkt);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
            
        }

        //Oppdater produkt
        public ActionResult OppdaterProdukt(int id)
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            ProduktBLL produktBll = new ProduktBLL();
            var produkt = produktBll.HentProdukt(id);
            return View(produkt);
        }

        [HttpPost]
        public ActionResult OppdaterProdukt(Produkt produkt)
        {
            if (Session["Rolle"] == null || Session["Rolle"].ToString() != "admin")
            {
                RedirectToAction("Index", "Home");
            }
            try
            {
                ProduktBLL produktBll = new ProduktBLL();
                produktBll.OppdaterProdukt(produkt);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}