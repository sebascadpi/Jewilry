
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IDescuentoCAD
{
DescuentoEN ReadOIDDefault (int id
                            );

void ModifyDefault (DescuentoEN descuento);

System.Collections.Generic.IList<DescuentoEN> ReadAllDefault (int first, int size);



int CrearDescuento (DescuentoEN descuento);

void ModificarDescuento (DescuentoEN descuento);


void BorrarDescuento (int id
                      );


DescuentoEN DameDescuento (int id
                           );


System.Collections.Generic.IList<DescuentoEN> DameDescuentos (int first, int size);
}
}
