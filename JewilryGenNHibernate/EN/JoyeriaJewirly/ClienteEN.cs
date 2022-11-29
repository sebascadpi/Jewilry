
using System;
// Definición clase ClienteEN
namespace JewilryGenNHibernate.EN.JoyeriaJewirly
{
public partial class ClienteEN
{
/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo genero
 */
private JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum genero;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion;



/**
 *	Atributo listaDeseos
 */
private JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN listaDeseos;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido;






public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}



public virtual System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public ClienteEN()
{
        valoracion = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN>();
        pedido = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN>();
}



public ClienteEN(int id, String pass, string nombre, string apellidos, string email, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum genero, int telefono, string direccion, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion, JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN listaDeseos, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido
                 )
{
        this.init (Id, pass, nombre, apellidos, email, genero, telefono, direccion, valoracion, listaDeseos, pedido);
}


public ClienteEN(ClienteEN cliente)
{
        this.init (Id, cliente.Pass, cliente.Nombre, cliente.Apellidos, cliente.Email, cliente.Genero, cliente.Telefono, cliente.Direccion, cliente.Valoracion, cliente.ListaDeseos, cliente.Pedido);
}

private void init (int id
                   , String pass, string nombre, string apellidos, string email, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum genero, int telefono, string direccion, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ValoracionEN> valoracion, JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN listaDeseos, System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> pedido)
{
        this.Id = id;


        this.Pass = pass;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;

        this.Genero = genero;

        this.Telefono = telefono;

        this.Direccion = direccion;

        this.Valoracion = valoracion;

        this.ListaDeseos = listaDeseos;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClienteEN t = obj as ClienteEN;
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
