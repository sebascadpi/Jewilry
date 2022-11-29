
using System;
// Definición clase PedidoEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido;



/**
 *	Atributo cliente
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente;



/**
 *	Atributo estado
 */
private JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum estado;



/**
 *	Atributo descuento
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN descuento;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo codigoPostal
 */
private string codigoPostal;



/**
 *	Atributo tipoPago
 */
private string tipoPago;



/**
 *	Atributo tipoTarjeta
 */
private string tipoTarjeta;



/**
 *	Atributo numeroTarjeta
 */
private long numeroTarjeta;



/**
 *	Atributo recibo
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ReciboEN recibo;



/**
 *	Atributo total
 */
private float total;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}



public virtual JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN Descuento {
        get { return descuento; } set { descuento = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}



public virtual string TipoPago {
        get { return tipoPago; } set { tipoPago = value;  }
}



public virtual string TipoTarjeta {
        get { return tipoTarjeta; } set { tipoTarjeta = value;  }
}



public virtual long NumeroTarjeta {
        get { return numeroTarjeta; } set { numeroTarjeta = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ReciboEN Recibo {
        get { return recibo; } set { recibo = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN>();
}



public PedidoEN(int id, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum estado, JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN descuento, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, string codigoPostal, string tipoPago, string tipoTarjeta, long numeroTarjeta, JewilryGenNHibernate.EN.JoyeriaJewirly.ReciboEN recibo, float total
                )
{
        this.init (Id, lineaPedido, cliente, estado, descuento, fecha, direccion, localidad, provincia, codigoPostal, tipoPago, tipoTarjeta, numeroTarjeta, recibo, total);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.LineaPedido, pedido.Cliente, pedido.Estado, pedido.Descuento, pedido.Fecha, pedido.Direccion, pedido.Localidad, pedido.Provincia, pedido.CodigoPostal, pedido.TipoPago, pedido.TipoTarjeta, pedido.NumeroTarjeta, pedido.Recibo, pedido.Total);
}

private void init (int id
                   , System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum estado, JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN descuento, Nullable<DateTime> fecha, string direccion, string localidad, string provincia, string codigoPostal, string tipoPago, string tipoTarjeta, long numeroTarjeta, JewilryGenNHibernate.EN.JoyeriaJewirly.ReciboEN recibo, float total)
{
        this.Id = id;


        this.LineaPedido = lineaPedido;

        this.Cliente = cliente;

        this.Estado = estado;

        this.Descuento = descuento;

        this.Fecha = fecha;

        this.Direccion = direccion;

        this.Localidad = localidad;

        this.Provincia = provincia;

        this.CodigoPostal = codigoPostal;

        this.TipoPago = tipoPago;

        this.TipoTarjeta = tipoTarjeta;

        this.NumeroTarjeta = numeroTarjeta;

        this.Recibo = recibo;

        this.Total = total;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
