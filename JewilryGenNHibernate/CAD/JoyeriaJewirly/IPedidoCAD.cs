
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int CrearPedido (PedidoEN pedido);

void ModificarPedido (PedidoEN pedido);


void BorrarPedido (int id
                   );


PedidoEN DamePedido (int id
                     );


System.Collections.Generic.IList<PedidoEN> DamePedidos (int first, int size);





void TotalDescuento (int p_Pedido_OID, int p_descuento_OID);


System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> PedidosCliente (int p_idCliente);


}
}
