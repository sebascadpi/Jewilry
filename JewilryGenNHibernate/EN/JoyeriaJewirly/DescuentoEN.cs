
using System;
// Definición clase DescuentoEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class DescuentoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cupon
 */
private string cupon;



/**
 *	Atributo descuento
 */
private int descuento;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Cupon {
        get { return cupon; } set { cupon = value;  }
}



public virtual int Descuento {
        get { return descuento; } set { descuento = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public DescuentoEN()
{
        pedido = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN>();
}



public DescuentoEN(int id, string cupon, int descuento, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido
                   )
{
        this.init (Id, cupon, descuento, pedido);
}


public DescuentoEN(DescuentoEN descuento)
{
        this.init (Id, descuento.Cupon, descuento.Descuento, descuento.Pedido);
}

private void init (int id
                   , string cupon, int descuento, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido)
{
        this.Id = id;


        this.Cupon = cupon;

        this.Descuento = descuento;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DescuentoEN t = obj as DescuentoEN;
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
