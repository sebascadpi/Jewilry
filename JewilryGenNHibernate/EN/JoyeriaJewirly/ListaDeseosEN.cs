
using System;
// Definición clase ListaDeseosEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class ListaDeseosEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo;



/**
 *	Atributo cliente
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}





public ListaDeseosEN()
{
        articulo = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
}



public ListaDeseosEN(int id, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente
                     )
{
        this.init (Id, articulo, cliente);
}


public ListaDeseosEN(ListaDeseosEN listaDeseos)
{
        this.init (Id, listaDeseos.Articulo, listaDeseos.Cliente);
}

private void init (int id
                   , System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente)
{
        this.Id = id;


        this.Articulo = articulo;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaDeseosEN t = obj as ListaDeseosEN;
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
