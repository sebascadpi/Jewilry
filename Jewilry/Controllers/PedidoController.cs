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

        public ActionResult DetallesPedido(int id)
        {
            LineaPedidoCAD linPedCAD2 = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN2 = new LineaPedidoCEN(linPedCAD2);
            


                


            PedidoEN pedidoEN = new PedidoCAD().ReadOIDDefault(id);

            PedidoViewModel listViewModel = new PedidoAssembler().ConvertENToModelUI(pedidoEN);
            return View(listViewModel);
        }

        public ActionResult ResumenPedido()
        {

            //ArticuloCEN artiuloCEN = new ArticuloCEN();
            //List<ArticuloEN> lista = artiuloCEN.DameArticulos(0, 20).ToList();

            int idencontrado = 0;

            int currentUserId = 0;
            int contador = 0;

            if (Session["Usuario"] != null)
            {
                currentUserId = ((ClienteEN)Session["Usuario"]).Id;
            }

            PedidoCEN pedCEN = new PedidoCEN();
            IList<PedidoEN> listaPedidos = pedCEN.PedidosTodosCliente(currentUserId);

            foreach (PedidoEN ped in listaPedidos)
            {
                if (ped.Estado == JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito)
                {
                    idencontrado = ped.Id;

                }
            }
            LineaPedidoCAD linPedCAD2 = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN2 = new LineaPedidoCEN(linPedCAD2);
            IList<LineaPedidoEN> lineaarticulos2 = linpedCEN2.LineasPedido(idencontrado);
            foreach (var item in lineaarticulos2)
            {

                contador++;


            }
            if (contador != 0) {
                

                if (Session["totaldesc"] != null)
                {
                    float x = 0;

                    float desc = float.Parse(Session["desc"].ToString());
                    float total = float.Parse(Session["total"].ToString());
                    LineaPedidoCAD linPedCAD = new LineaPedidoCAD(session);
                    LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linPedCAD);
                    IList<LineaPedidoEN> lineaarticulos = linpedCEN.LineasPedido(idencontrado);
                    foreach (var item in lineaarticulos)
                    {

                        x += (item.Unidades * item.Precio);


                    }
                    float y = x * desc;
                    Session["totaldesc"] = total - y;
                }


                PedidoEN pedidoEN = new PedidoCAD().ReadOIDDefault(idencontrado);

                PedidoViewModel listViewModel = new PedidoAssembler().ConvertENToModelUI(pedidoEN);
                return View(listViewModel);
            }
            return RedirectToAction("Details", "LineaPedido");

        }
        [HttpPost]
        public ActionResult ResumenPedido(PedidoViewModel ped)
        {
            if (ModelState.IsValid) { 
                int idencontrado = 0;
                int iddescuento = 0;
                int currentUserId = 0;
                if (Session["Usuario"] != null)
                {
                    currentUserId = ((ClienteEN)Session["Usuario"]).Id;
                }

                PedidoCEN pedCEN = new PedidoCEN();
                IList<PedidoEN> listaPedidos = pedCEN.PedidosTodosCliente(currentUserId);

                foreach (PedidoEN pedi in listaPedidos)
                {
                    if (pedi.Estado == JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito)
                    {
                        idencontrado = pedi.Id;

                    }
                }

                PedidoCAD pedidoCAD = new PedidoCAD();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

                PedidoEN pedidoEN = pedidoCEN.DamePedido(idencontrado);

                if(ped.Localidad != null && ped.Direccion != null && ped.CodigoPostal != null && ped.Provincia != null)
                {
                    pedidoEN.Localidad = ped.Localidad;
                    pedidoEN.Direccion = ped.Direccion;
                    pedidoEN.CodigoPostal = ped.CodigoPostal;
                    pedidoEN.Provincia = ped.Provincia;
                    pedidoCAD.ModifyDefault(pedidoEN);

                }


                DescuentoCEN descCEN = new DescuentoCEN();
                IList<DescuentoEN> listaDescuentos = descCEN.DameDescuentos(1,-1);


                
                pedidoCEN.CambiarPago(idencontrado, ped.TipoPago, ped.TipoTarjeta, ped.NumeroTarjeta);
                

                if (Session["ValDesc"] != null)
                {
                    foreach (DescuentoEN desc in listaDescuentos)
                    {
                        if (desc.Cupon == Session["nomDesc"].ToString())
                        {
                            iddescuento = desc.Id;

                        }
                    }
                    DescuentoEN descEN = descCEN.DameDescuento(iddescuento);
                    pedidoCEN.AplicarDescuento(idencontrado, descEN);

                }

                pedidoCEN.RealizarPedido(idencontrado);
                Session["HayPedido"] = null;

                return RedirectToAction("Index", "Home");
            }
            return View("ResumenPedido");
        }
        public ActionResult MostrarPedidos()
        {
            SessionInitialize();
            int currentUserId = 0;
            if (Session["Usuario"] != null)
            {
                currentUserId = ((ClienteEN)Session["Usuario"]).Id;
            }

            PedidoCAD pedCAD = new PedidoCAD(session);
            PedidoCEN pedCEN = new PedidoCEN(pedCAD);

            IList<PedidoEN> listEN = pedCEN.PedidosCliente(currentUserId);
            IEnumerable<PedidoViewModel> listViewModel = new PedidoAssembler().ConvertListENToModel(listEN).ToList();
            SessionClose();


            return View(listViewModel);
        }
        public ActionResult Descuento(string codigo)
        {

            int idencontrado = 0;

            DescuentoCEN descCEN = new DescuentoCEN();
            IList<DescuentoEN> listaDescuentos = descCEN.DameDescuentos(1,-1);

            foreach (DescuentoEN desc in listaDescuentos)
            {
                if (desc.Cupon == codigo)
                {
                    idencontrado = desc.Id;

                }
            }

            if (idencontrado == 0)
            {
                Session["ValDesc"] = "Descuento no valido";
                Session["totaldesc"] = null;
                Session["ValDesc"] = null;
                Session["nomDesc"] = null;
            }
            else
            {
                DescuentoEN descuentoEN = new DescuentoCAD().ReadOIDDefault(idencontrado);
                float precio = Convert.ToInt32(Session["total"]);
                Session["totaldesc"] = 0;
                Session["desc"] = descuentoEN.Descuento * 0.01;
                Session["nomDesc"] = codigo;
                Session["ValDesc"] = "Descuento aplicado";
            }

            return RedirectToAction("ResumenPedido");
        }
        public ActionResult Cancelar()
        {
            Session["totaldesc"] = null;
            Session["ValDesc"] = null;
            Session["nomDesc"] = null;
            return RedirectToAction("ResumenPedido");
        }

        public ActionResult CancelarPedido(int id)
        {
            PedidoCAD pedidoCAD = new PedidoCAD();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

            pedidoCEN.CancelarPedido(id);

            return RedirectToAction("MostrarPedidos");
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


                    System.Web.HttpContext.Current.Session["HayPedido"] = "hay";

                    linCP.CrearLinea(id, idPedido, 1, artEN.Precio);

                    return RedirectToAction("Details", "LineaPedido");
                
                
            }
            else
            {
                int idArtEncontrado = 0;
                int idLinPedEncontrado = 0;
                bool repetido = false;
                ArticuloEN artEN = new ArticuloCAD().DameArticulo(id);

                LineaPedidoCP linCP = new LineaPedidoCP();


                ArticuloCEN artCEN = new ArticuloCEN();
                IList<ArticuloEN> listaArticulos = artCEN.ArticuloPedido(idencontrado);

                foreach (ArticuloEN art in listaArticulos)
                {
                    if (art.Id == id)
                    {
                        idArtEncontrado = art.Id;
                        repetido = true;
                    }
                }

                if(repetido == true)
                {
                    int cantidad = 0;
                    int idPedido = 0;
                    float precio = 0;

                    LineaPedidoEN linpedPrinEN = new LineaPedidoEN();
                    LineaPedidoCEN linpedCEN = new LineaPedidoCEN();
                    IList<LineaPedidoEN> lineaarticulos = linpedCEN.LineasPedido(idencontrado);

                    foreach (LineaPedidoEN linped in lineaarticulos)
                    {
                        if (linped.Articulo.Id == idArtEncontrado)
                        {
                            idLinPedEncontrado = linped.Id;
                            cantidad = linped.Unidades + 1;
                            precio = linped.Precio;
                            idPedido = linped.Pedido.Id;
                        }
                    }

                    linpedCEN.ModificarLinea(idLinPedEncontrado, cantidad, precio);


                    LineaPedidoEN lineaPedidoEN = linpedCEN.DameLinea(idLinPedEncontrado);

                    PedidoCAD pedidoCAD = new PedidoCAD();
                    PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

                    PedidoEN pedidoEN = pedidoCEN.DamePedido(idPedido);

                    pedidoEN.Total += lineaPedidoEN.Precio ;

                    pedidoCAD.ModifyDefault(pedidoEN);

                }
                else
                {
                    linCP.CrearLinea(id, idencontrado, 1, artEN.Precio);

                }

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
