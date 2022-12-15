using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Jewilry.Assemblers;
using Jewilry.Models;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace Jewilry.Controllers
{
    public class LineaPedidoController : BasicController
    {
        // GET: Valoracion
        public ActionResult Index(int id)
        {
            return View();    
        }

        // GET: Valoracion/Details/5
        public ActionResult Details()
        {
            SessionInitialize();

            int currentUserId = 0;
            int idencontrado = 0;
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

            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listaArticulos = artCEN.ArticuloPedido(idencontrado);
            IList<SelectListItem> articulosItems = new List<SelectListItem>();
            foreach(ArticuloEN art in listaArticulos)
            {
                articulosItems.Add(new SelectListItem { Text = art.Nombre, Value = art.Foto});
            }

            ViewData["FotosArticulo"] = articulosItems;

            foreach (ArticuloEN art in listaArticulos)
            {
                articulosItems.Add(new SelectListItem { Text = art.Nombre, Value = art.Nombre });

            }

            ViewData["NombreArticulo"] = articulosItems;


            LineaPedidoCAD linPedCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linPedCAD);
            IList<LineaPedidoEN> lineaarticulos = linpedCEN.LineasPedido(idencontrado);



            IEnumerable<LineaPedidoViewModel> listViewModel = new LineaPedidoAssembler().ConvertListENToModel(lineaarticulos).ToList();

            float x = 0;
            foreach (var item in lineaarticulos)
            {
                x += (item.Unidades * item.Precio);
            }

            Session["total"] = x;

            return View(listViewModel);

        }

        public ActionResult Cantidad(int id)
        {
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN();
            LineaPedidoEN lineaarticulo = linpedCEN.DameLinea(id);

            int idencontrado = 0;
            int cantidad = lineaarticulo.Unidades + 1;
            float precio = lineaarticulo.Precio;
            int currentUserId = 0;
            if (Session["Usuario"] != null)
            {
                currentUserId = ((ClienteEN)Session["Usuario"]).Id;
            }

            linpedCEN.ModificarLinea(id, cantidad, precio);

            PedidoCEN pedCEN = new PedidoCEN();
            IList<PedidoEN> listaPedidos = pedCEN.PedidosTodosCliente(currentUserId);

            foreach (PedidoEN ped in listaPedidos)
            {
                if (ped.Estado == JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito)
                {
                    idencontrado = ped.Id;

                }
            }

            PedidoCAD pedidoCAD = new PedidoCAD();
            PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

            PedidoEN pedidoEN = pedidoCEN.DamePedido(idencontrado);

            pedidoEN.Total += lineaarticulo.Precio;

            pedidoCAD.ModifyDefault(pedidoEN);


            return RedirectToAction("Details");
        }
        public ActionResult Menos(int id)
        {
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN();
            LineaPedidoEN lineaarticulo = linpedCEN.DameLinea(id);

            if (lineaarticulo.Unidades > 1)
            {
                int idencontrado = 0;
                int cantidad = lineaarticulo.Unidades - 1;
                float precio = lineaarticulo.Precio;
                int currentUserId = 0;
                if (Session["Usuario"] != null)
                {
                    currentUserId = ((ClienteEN)Session["Usuario"]).Id;
                }

                linpedCEN.ModificarLinea(id, cantidad, precio);

                PedidoCEN pedCEN = new PedidoCEN();
                IList<PedidoEN> listaPedidos = pedCEN.PedidosTodosCliente(currentUserId);

                foreach (PedidoEN ped in listaPedidos)
                {
                    if (ped.Estado == JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito)
                    {
                        idencontrado = ped.Id;

                    }
                }

                PedidoCAD pedidoCAD = new PedidoCAD();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

                PedidoEN pedidoEN = pedidoCEN.DamePedido(idencontrado);

                pedidoEN.Total -= lineaarticulo.Precio;

                pedidoCAD.ModifyDefault(pedidoEN);

            }
            
            return RedirectToAction("Details");
        }

        // GET: Valoracion/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Valoracion/Create
        [HttpPost]
        public ActionResult Create(int id, ValoracionViewModel val)
        {
            try
            {
                ValoracionCEN valCEN = new ValoracionCEN();

                int currentUserId = 0;

                if (Session["Usuario"] != null)
                {
                    currentUserId = ((ClienteEN)Session["Usuario"]).Id;
                }

                System.Diagnostics.Debug.WriteLine((float)valCEN.CalcularMedia(id));

                int val1 = valCEN.CrearValoracion(val.Comentario, val.Valor, id, currentUserId);

                float media = (float)valCEN.CalcularMedia(id);

                ArticuloCEN artCEN = new ArticuloCEN();
                artCEN.CambiarMedia(id, media);

                return RedirectToAction("Index", "Articulo");
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

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                LineaPedidoCEN linpedCEN = new LineaPedidoCEN();
                linpedCEN.BorrarLinea(id);
                int currentUserId = 0;
                int idencontrado = 0;
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
                IList<LineaPedidoEN> lineaarticulos = linpedCEN.LineasPedido(idencontrado);

                float x = 0;
                foreach (var item in lineaarticulos)
                {
                    x += (item.Unidades * item.Precio);
                }

                Session["total"] = x;

                PedidoCAD pedidoCAD = new PedidoCAD();
                PedidoCEN pedidoCEN = new PedidoCEN(pedidoCAD);

                PedidoEN pedidoEN = pedidoCEN.DamePedido(idencontrado);

                pedidoEN.Total = x;

                pedidoCAD.ModifyDefault(pedidoEN);

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            SessionInitialize();

            int currentUserId = 0;
            int idencontrado = 0;
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

            ArticuloCAD artCAD = new ArticuloCAD(session);
            ArticuloCEN artCEN = new ArticuloCEN(artCAD);

            IList<ArticuloEN> listaArticulos = artCEN.ArticuloPedido(idencontrado);
            IList<SelectListItem> articulosItems = new List<SelectListItem>();
            foreach (ArticuloEN art in listaArticulos)
            {
                articulosItems.Add(new SelectListItem { Text = art.Nombre, Value = art.Foto });
            }

            ViewData["FotosArticulo"] = articulosItems;

            foreach (ArticuloEN art in listaArticulos)
            {
                articulosItems.Add(new SelectListItem { Text = art.Nombre, Value = art.Nombre });

            }

            ViewData["NombreArticulo"] = articulosItems;


            LineaPedidoCAD linPedCAD = new LineaPedidoCAD(session);
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linPedCAD);
            IList<LineaPedidoEN> lineaarticulos = linpedCEN.LineasPedido(idencontrado);



            IEnumerable<LineaPedidoViewModel> listViewModel = new LineaPedidoAssembler().ConvertListENToModel(lineaarticulos).ToList();





            return PartialView("DetallesPedido", listViewModel);
        }
    }
}
