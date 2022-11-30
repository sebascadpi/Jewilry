﻿using System;
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
    public class ValoracionController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index(int id)
        {

            SessionInitialize();
            

            ValoracionCAD artCAD = new ValoracionCAD(session);
            ValoracionCEN artCEN = new ValoracionCEN(artCAD);

            ArticuloEN artEN2 = new ArticuloCAD().ReadOIDDefault(id);

            IList<ValoracionEN> listEN = artCEN.ValoracionArticulos(id);

            IEnumerable<ValoracionViewModel> listViewModel = new ValoracionAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return View(listViewModel);

           
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valoracion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Valoracion/Create
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

        // GET: Valoracion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Valoracion/Edit/5
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

        // GET: Valoracion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Valoracion/Delete/5
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
        public ActionResult Navigation(int id)
        {
            SessionInitialize();


            ValoracionCAD artCAD = new ValoracionCAD(session);
            ValoracionCEN artCEN = new ValoracionCEN(artCAD);

            ArticuloEN artEN2 = new ArticuloCAD().ReadOIDDefault(id);

            IList<ValoracionEN> listEN = artCEN.ValoracionArticulos(id);

            IEnumerable<ValoracionViewModel> listViewModel = new ValoracionAssembler().ConvertListENToModel(listEN).ToList();
            


           

            return PartialView("Valoraciones", listViewModel);
            SessionClose();
        }
    }
}
