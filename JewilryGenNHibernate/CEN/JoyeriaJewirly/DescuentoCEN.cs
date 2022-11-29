

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;

using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
/*
 *      Definition of the class DescuentoCEN
 *
 */
public partial class DescuentoCEN
{
private IDescuentoCAD _IDescuentoCAD;

public DescuentoCEN()
{
        this._IDescuentoCAD = new DescuentoCAD ();
}

public DescuentoCEN(IDescuentoCAD _IDescuentoCAD)
{
        this._IDescuentoCAD = _IDescuentoCAD;
}

public IDescuentoCAD get_IDescuentoCAD ()
{
        return this._IDescuentoCAD;
}

public int CrearDescuento (string p_cupon, int p_descuento)
{
        DescuentoEN descuentoEN = null;
        int oid;

        //Initialized DescuentoEN
        descuentoEN = new DescuentoEN ();
        descuentoEN.Cupon = p_cupon;

        descuentoEN.Descuento = p_descuento;

        //Call to DescuentoCAD

        oid = _IDescuentoCAD.CrearDescuento (descuentoEN);
        return oid;
}

public void ModificarDescuento (int p_Descuento_OID, string p_cupon, int p_descuento)
{
        DescuentoEN descuentoEN = null;

        //Initialized DescuentoEN
        descuentoEN = new DescuentoEN ();
        descuentoEN.Id = p_Descuento_OID;
        descuentoEN.Cupon = p_cupon;
        descuentoEN.Descuento = p_descuento;
        //Call to DescuentoCAD

        _IDescuentoCAD.ModificarDescuento (descuentoEN);
}

public void BorrarDescuento (int id
                             )
{
        _IDescuentoCAD.BorrarDescuento (id);
}

public DescuentoEN DameDescuento (int id
                                  )
{
        DescuentoEN descuentoEN = null;

        descuentoEN = _IDescuentoCAD.DameDescuento (id);
        return descuentoEN;
}

public System.Collections.Generic.IList<DescuentoEN> DameDescuentos (int first, int size)
{
        System.Collections.Generic.IList<DescuentoEN> list = null;

        list = _IDescuentoCAD.DameDescuentos (first, size);
        return list;
}
}
}
