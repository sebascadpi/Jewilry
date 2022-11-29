
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_cambiarPago) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class PedidoCEN
{
public void CambiarPago (int p_oid, string nuevoPago, string nuevaTarjeta, long nuevoNumero)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_cambiarPago) ENABLED START*/

        PedidoEN en = _IPedidoCAD.DamePedido (p_oid);

        //Condiciones
        if (nuevoPago.Equals (en.TipoPago))
                throw new ModelException ("El método de pago nuevo es igual al anterior.");

        if (String.IsNullOrEmpty (nuevoPago))
                throw new ModelException ("No se ha encontrado método de pago.");

        if (String.IsNullOrEmpty (nuevaTarjeta))
                throw new ModelException ("No se ha encontrado el nuevo tipo de tarjeta.");

        if ((nuevoNumero > 0) == false && (nuevoNumero.ToString ().Length <= 16) == false)
                throw new ModelException ("El número de tarjeta tiene un formato erróneo");


        en.TipoPago = nuevoPago;
        en.TipoTarjeta = nuevaTarjeta;
        en.NumeroTarjeta = nuevoNumero;

        _IPedidoCAD.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
