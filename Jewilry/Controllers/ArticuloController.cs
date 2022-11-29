using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewilry.Assemblers;
using Jewilry.Models;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace Jewilry.Controllers
{
    public class ArticuloController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            //ArticuloCEN artiuloCEN = new ArticuloCEN();
            //List<ArticuloEN> lista = artiuloCEN.DameArticulos(0, 20).ToList();
            SessionInitialize();
            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listEN = artCEN.DameArticulos(0, -1);
            IEnumerable<ArticuloViewModel> listViewModel = new ArticuloAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return View(listViewModel);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            ArticuloEN artEN2 = new ArticuloCAD().ReadOIDDefault(id);

            ArticuloViewModel listViewModel = new ArticuloAssembler().ConvertENToModelUI(artEN2);
            return View(listViewModel);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
