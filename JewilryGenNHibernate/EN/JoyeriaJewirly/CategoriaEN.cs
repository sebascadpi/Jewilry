
using System;
// Definición clase CategoriaEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class CategoriaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo articulo
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo;



/**
 *	Atributo subcategoria
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN> subcategoria;



/**
 *	Atributo categoria
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN> Subcategoria {
        get { return subcategoria; } set { subcategoria = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN Categoria {
        get { return categoria; } set { categoria = value;  }
}





public CategoriaEN()
{
        articulo = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
        subcategoria = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN>();
}



public CategoriaEN(int id, string nombre, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN> subcategoria, JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria
                   )
{
        this.init (Id, nombre, articulo, subcategoria, categoria);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (Id, categoria.Nombre, categoria.Articulo, categoria.Subcategoria, categoria.Categoria);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> articulo, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN> subcategoria, JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Articulo = articulo;

        this.Subcategoria = subcategoria;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
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
