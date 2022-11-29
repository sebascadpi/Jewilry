
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Recibo_imprimirRecibo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class ReciboCEN
{
public void ImprimirRecibo (int p_oid, JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Recibo_imprimirRecibo) ENABLED START*/

        Console.WriteLine ("Factura de compra: \n");
        Console.WriteLine ("Usuario: " + pedido.Cliente.Nombre + " " + pedido.Cliente.Apellidos + "\n");
        Console.WriteLine ("fecha: " + pedido.Fecha + "\n");
        Console.WriteLine ("Con un importe de:" + pedido.Total + "\n");

        // Console.WriteLine("Lista de productos: \n" + pedido.LineaPedido);
        Console.WriteLine ("A dirección de envio: " + pedido.CodigoPostal + " " + pedido.Provincia + " " + pedido.Localidad + " " + pedido.Direccion);
        Console.WriteLine ("Método de pago: " + pedido.TipoPago + "\n");
        Console.WriteLine ("Gracias por confiar en nuestros servicios \n");

        /*PROTECTED REGION END*/
}
}
}
