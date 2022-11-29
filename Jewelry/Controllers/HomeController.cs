using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace Jewelry.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArticuloCEN articuloCEN = new ArticuloCEN();
            List<ArticuloEN> lista = articuloCEN.DameArticulos(8, 20).ToList();
            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}