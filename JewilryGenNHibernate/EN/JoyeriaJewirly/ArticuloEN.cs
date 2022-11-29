
using System;
// Definición clase ArticuloEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class ArticuloEN
{
/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo material
 */
private string material;



/**
 *	Atributo marca
 */
private string marca;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido;



/**
 *	Atributo listaDeseos
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN> listaDeseos;



/**
 *	Atributo categoria
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria;



/**
 *	Atributo tallas
 */
private string tallas;



/**
 *	Atributo valoracionMedia
 */
private float valoracionMedia;






public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Material {
        get { return material; } set { material = value;  }
}



public virtual string Marca {
        get { return marca; } set { marca = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN> ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual string Tallas {
        get { return tallas; } set { tallas = value;  }
}



public virtual float ValoracionMedia {
        get { return valoracionMedia; } set { valoracionMedia = value;  }
}





public ArticuloEN()
{
        valoracion = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN>();
        lineaPedido = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN>();
        listaDeseos = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN>();
}



public ArticuloEN(int id, float precio, string nombre, string descripcion, string material, string marca, int stock, string foto, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN> listaDeseos, JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria, string tallas, float valoracionMedia
                  )
{
        this.init (Id, precio, nombre, descripcion, material, marca, stock, foto, valoracion, lineaPedido, listaDeseos, categoria, tallas, valoracionMedia);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (Id, articulo.Precio, articulo.Nombre, articulo.Descripcion, articulo.Material, articulo.Marca, articulo.Stock, articulo.Foto, articulo.Valoracion, articulo.LineaPedido, articulo.ListaDeseos, articulo.Categoria, articulo.Tallas, articulo.ValoracionMedia);
}

private void init (int id
                   , float precio, string nombre, string descripcion, string material, string marca, int stock, string foto, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> lineaPedido, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN> listaDeseos, JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoria, string tallas, float valoracionMedia)
{
        this.Id = id;


        this.Precio = precio;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Material = material;

        this.Marca = marca;

        this.Stock = stock;

        this.Foto = foto;

        this.Valoracion = valoracion;

        this.LineaPedido = lineaPedido;

        this.ListaDeseos = listaDeseos;

        this.Categoria = categoria;

        this.Tallas = tallas;

        this.ValoracionMedia = valoracionMedia;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
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
