
using System;
using System.Text;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.Exceptions;


/*
 * Clase Cliente:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class ClienteCAD : BasicCAD, IClienteCAD
{
public ClienteCAD() : base ()
{
}

public ClienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ClienteEN ReadOIDDefault (int id
                                 )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClienteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                        else
                                result = session.CreateCriteria (typeof(ClienteEN)).List<ClienteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Id);

                clienteEN.Pass = cliente.Pass;


                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Apellidos = cliente.Apellidos;


                clienteEN.Email = cliente.Email;


                clienteEN.Genero = cliente.Genero;


                clienteEN.Telefono = cliente.Telefono;


                clienteEN.Direccion = cliente.Direccion;




                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearCliente (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (cliente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cliente.Id;
}

public void ModificarCliente (ClienteEN cliente)
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), cliente.Id);

                clienteEN.Pass = cliente.Pass;


                clienteEN.Nombre = cliente.Nombre;


                clienteEN.Apellidos = cliente.Apellidos;


                clienteEN.Email = cliente.Email;


                clienteEN.Genero = cliente.Genero;


                clienteEN.Telefono = cliente.Telefono;


                clienteEN.Direccion = cliente.Direccion;

                session.Update (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarCliente (int id
                           )
{
        try
        {
                SessionInitializeTransaction ();
                ClienteEN clienteEN = (ClienteEN)session.Load (typeof(ClienteEN), id);
                session.Delete (clienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameCliente
//Con e: ClienteEN
public ClienteEN DameCliente (int id
                              )
{
        ClienteEN clienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                clienteEN = (ClienteEN)session.Get (typeof(ClienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> DameClientes (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClienteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClienteEN>();
                else
                        result = session.CreateCriteria (typeof(ClienteEN)).List<ClienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ClienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
