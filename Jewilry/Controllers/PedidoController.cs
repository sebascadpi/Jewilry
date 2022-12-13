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

        
        public ActionResult Create(int id, PedidoViewModel val)
        {
            int currentUserId = 0;
            bool haycarrito = false;
            int idencontrado = 0;
            if (Session["Usuario"] != null)
            {
                currentUserId = ((ClienteEN)Session["Usuario"]).Id;
            }

            PedidoCEN pedCEN = new PedidoCEN();
            IList<PedidoEN> listaPedidos = pedCEN.PedidosTodosCliente(currentUserId);

            foreach (PedidoEN ped in listaPedidos)
            {
                if(ped.Estado == JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito)
                {
                    haycarrito = true;
                    idencontrado = ped.Id;
                }
            }

            if (haycarrito == false)
            {
                
                    int idPedido = pedCEN.CrearPedido(currentUserId);
                    System.Web.HttpContext.Current.Session["NumPedido"] = idPedido;

                    LineaPedidoCP linCP = new LineaPedidoCP();

                    ArticuloEN artEN = new ArticuloCAD().DameArticulo(id);



                    linCP.CrearLinea(id, idPedido, 1, artEN.Precio);


                    return RedirectToAction("Details", "LineaPedido");
                
                
            }
            else
            {
                ArticuloEN artEN = new ArticuloCAD().DameArticulo(id);

                LineaPedidoCP linCP = new LineaPedidoCP();



                linCP.CrearLinea(id, idencontrado, 1, artEN.Precio);

                return RedirectToAction("Details", "LineaPedido");

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
