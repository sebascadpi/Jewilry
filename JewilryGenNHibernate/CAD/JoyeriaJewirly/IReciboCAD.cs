
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IReciboCAD
{
ReciboEN ReadOIDDefault (int id
                         );

void ModifyDefault (ReciboEN recibo);

System.Collections.Generic.IList<ReciboEN> ReadAllDefault (int first, int size);



int CrearRecibo (ReciboEN recibo);

void BorrarRecibo (int id
                   );


ReciboEN DameRecibo (int id
                     );


System.Collections.Generic.IList<ReciboEN> DameRecibos (int first, int size);
}
}
