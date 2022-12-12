using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jewilry.Assemblers;
using Jewilry.Models;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using JewilryGenNHibernate.CP.JoyeriaJewirly;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace Jewilry.Controllers
{
        public class PedidoController : BasicController
    {
        // GET: Articulo
        public ActionResult Index()
        {
            //ArticuloCEN artiuloCEN = new ArticuloCEN();
            //List<ArticuloEN> lista = artiuloCEN.DameArticulos(0, 20).ToList();
            SessionInitialize();
            PedidoCAD artCAD = new PedidoCAD(session);
            PedidoCEN artCEN = new PedidoCEN(artCAD);

            
            SessionClose();


            return View();
        }

        // GET: Articulo/Details/5
        public ActionResult Details(int id)
        {
            PedidoEN artEN2 = new PedidoCAD().ReadOIDDefault(id);

            PedidoViewModel listViewModel = new PedidoAssembler().ConvertENToModelUI(artEN2);
            return View(listViewModel);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articulo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, int idArt1, int idPedido2)
        {
            PedidoCEN pedCEN = new PedidoCEN();

            try
            {


                int currentUserId = 0;

                if (Session["Usuario"] != null)
                {
                    currentUserId = ((ClienteEN)Session["Usuario"]).Id;
                }

                int idPedido = pedCEN.CrearPedido (currentUserId);

                return RedirectToAction("Index", "Articulo");
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
