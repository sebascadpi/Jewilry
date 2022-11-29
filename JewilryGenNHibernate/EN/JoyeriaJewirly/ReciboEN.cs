
using System;
// Definición clase ReciboEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class ReciboEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo codigo
 */
private int codigo;



/**
 *	Atributo pedido
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Codigo {
        get { return codigo; } set { codigo = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public ReciboEN()
{
}



public ReciboEN(int id, string descripcion, int codigo, JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido
                )
{
        this.init (Id, descripcion, codigo, pedido);
}


public ReciboEN(ReciboEN recibo)
{
        this.init (Id, recibo.Descripcion, recibo.Codigo, recibo.Pedido);
}

private void init (int id
                   , string descripcion, int codigo, JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedido)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Codigo = codigo;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReciboEN t = obj as ReciboEN;
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
