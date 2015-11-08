using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NettButikk.Model;
using NettButikk.BLL;


namespace Nettbutikk.Controllers
{
    public class LoggController : Controller
    {
        // GET: Logg
        public ActionResult Index()
        {
            LoggBLL loggBll = new LoggBLL();
            return View("Index", loggBll.HentAlleLogg());
        }
    }
}