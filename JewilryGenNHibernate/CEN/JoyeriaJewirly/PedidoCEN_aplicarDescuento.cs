
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_aplicarDescuento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class PedidoCEN
{
public void AplicarDescuento (int p_oid, JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN descuento)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_aplicarDescuento) ENABLED START*/

        PedidoEN en = _IPedidoCAD.DamePedido (p_oid);

        //el int pasado por parametro lo consideramos porcentaje
        if (descuento.Descuento > 0 && descuento.Descuento < 100) {
                en.Total = en.Total - en.Total * (descuento.Descuento / 100);
        }
        else{
                throw new ModelException ("El cupón no es válido");
        }

        _IPedidoCAD.ModificarPedido (en);
        /*PROTECTED REGION END*/
}
}
}
