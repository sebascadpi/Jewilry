
using System;
// Definición clase LineaPedidoEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class LineaPedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo;



/**
 *	Atributo pedido
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido;



/**
 *	Atributo unidades
 */
private int unidades;



/**
 *	Atributo precio
 */
private int precio;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Unidades {
        get { return unidades; } set { unidades = value;  }
}



public virtual int Precio {
        get { return precio; } set { precio = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido, int unidades, int precio
                     )
{
        this.init (Id, articulo, pedido, unidades, precio);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Articulo, lineaPedido.Pedido, lineaPedido.Unidades, lineaPedido.Precio);
}

private void init (int id
                   , JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido, int unidades, int precio)
{
        this.Id = id;


        this.Articulo = articulo;

        this.Pedido = pedido;

        this.Unidades = unidades;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
