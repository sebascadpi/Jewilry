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


            return View( listViewModel);
        }
        public ActionResult PrecioDesc()
        {
            //ArticuloCEN artiuloCEN = new ArticuloCEN();
            //List<ArticuloEN> lista = artiuloCEN.DameArticulos(0, 20).ToList();
            SessionInitialize();
            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listEN = artCEN.ArticuloPrecioDesc();
            IEnumerable<ArticuloViewModel> listViewModel = new ArticuloAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return View("Index", listViewModel);

        }
        public ActionResult PrecioAsc()
        {
            //ArticuloCEN artiuloCEN = new ArticuloCEN();
            //List<ArticuloEN> lista = artiuloCEN.DameArticulos(0, 20).ToList();
            SessionInitialize();
            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listEN = artCEN.ArticuloPrecioAsc();
            IEnumerable<ArticuloViewModel> listViewModel = new ArticuloAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return View("Index", listViewModel);

        }
        public ActionResult PorCategoria(int id)
        {
            SessionInitialize();
            ArticuloCAD cadArt = new ArticuloCAD(session);
            CategoriaCAD cadCat = new CategoriaCAD(session);
            ArticuloCEN cen = new ArticuloCEN(cadArt);
            IList<ArticuloEN> listArtEn = cen.ArticuloCategoria(id);
            IEnumerable<ArticuloViewModel> listArt = new ArticuloAssembler().ConvertListENToModel(listArtEn).ToList();
            CategoriaEN catEN = cadCat.ReadOIDDefault(id);

            ViewData["IdCategoria"] = id;
            if (catEN != null)
                ViewData["NombreCategoria"] = catEN.Nombre;

            SessionClose();
            return View("Index", listArt);
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ArticuloCAD cadArt = new ArticuloCAD(session);
            ArticuloCEN cen = new ArticuloCEN(cadArt);


            ArticuloEN artEN2 = cen.DameArticulo(id);

            ArticuloViewModel listViewModel = new ArticuloAssembler().ConvertENToModelUI(artEN2);
            SessionClose();

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
        [ChildActionOnly]
        public ActionResult Navigation()
        {
            CategoriaCEN cen = new CategoriaCEN();
            IEnumerable<CategoriaEN> listaCat = cen.DameCategorias(0, -1).ToList();


            return PartialView("ListaCategorias", listaCat);
        }

        [ChildActionOnly]
        public ActionResult Carousel()
        {
            SessionInitialize();
            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listEN = artCEN.ArticuloPocoStock();
            IEnumerable<ArticuloViewModel> listViewModel = new ArticuloAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return PartialView("Articulos", listViewModel);
        }
        [ChildActionOnly]
        public ActionResult Novedades()
        {
            SessionInitialize();
            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listEN = artCEN.ArticuloNovedades();
            IEnumerable<ArticuloViewModel> listViewModel = new ArticuloAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return PartialView("ArticulosNovedades", listViewModel);
        }


    }
}
