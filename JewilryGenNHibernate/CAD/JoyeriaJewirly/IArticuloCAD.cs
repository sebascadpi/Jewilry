
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IArticuloCAD
{
ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);

System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size);



int CrearArticulo (ArticuloEN articulo);

void ModificarArticulo (ArticuloEN articulo);


void BorrarArticulo (int id
                     );


ArticuloEN DameArticulo (int id
                         );


System.Collections.Generic.IList<ArticuloEN> DameArticulos (int first, int size);


void AsignarCategoria (int p_Articulo_OID, int p_categoria_OID);

void DesasignarCategoria (int p_Articulo_OID, int p_categoria_OID);

System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloLista (int p_idLista);



System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloPedido (int p_idPedido);
System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloCategoria(int p_idPedido);

}
}
