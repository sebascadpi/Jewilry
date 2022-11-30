
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Articulo_cambiarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class ArticuloCEN
{
public void CambiarMedia (int p_oid, float p_cantidad)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Articulo_cambiarStock) ENABLED START*/

        ArticuloEN en = _IArticuloCAD.DameArticulo (p_oid);

        

        en.ValoracionMedia = p_cantidad;

        _IArticuloCAD.ModificarArticulo (en);

        /*PROTECTED REGION END*/
}
}
}
