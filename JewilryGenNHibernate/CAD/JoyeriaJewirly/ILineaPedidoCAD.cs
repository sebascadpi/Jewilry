
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface ILineaPedidoCAD
{
LineaPedidoEN ReadOIDDefault (int id
                              );

void ModifyDefault (LineaPedidoEN lineaPedido);

System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size);



int CrearLinea (LineaPedidoEN lineaPedido);

void ModificarLinea (LineaPedidoEN lineaPedido);


void BorrarLinea (int id
                  );


LineaPedidoEN DameLinea (int id
                         );


System.Collections.Generic.IList<LineaPedidoEN> DameLineas (int first, int size);


System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> LineasPedido (int p_idPedido);
}
}
