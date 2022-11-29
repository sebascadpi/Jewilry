
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IValoracionCAD
{
ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int CrearValoracion (ValoracionEN valoracion);

void ModificarValoracion (ValoracionEN valoracion);


void BorrarValoracion (int id
                       );


ValoracionEN DameValoracion (int id
                             );


System.Collections.Generic.IList<ValoracionEN> DameValoraciones (int first, int size);


double CalcularMedia (int p_idArticulo);
}
}
