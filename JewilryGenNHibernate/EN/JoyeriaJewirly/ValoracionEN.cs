
using System;
// Definición clase ValoracionEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class ValoracionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo valor
 */
private int valor;



/**
 *	Atributo articulo
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo;



/**
 *	Atributo cliente
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual int Valor {
        get { return valor; } set { valor = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN Cliente {
        get { return cliente; } set { cliente = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, string comentario, int valor, JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente
                    )
{
        this.init (Id, comentario, valor, articulo, cliente);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (Id, valoracion.Comentario, valoracion.Valor, valoracion.Articulo, valoracion.Cliente);
}

private void init (int id
                   , string comentario, int valor, JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articulo, JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN cliente)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Valor = valor;

        this.Articulo = articulo;

        this.Cliente = cliente;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
