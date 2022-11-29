
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
 * Clase Categoria:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class CategoriaCAD : BasicCAD, ICategoriaCAD
{
public CategoriaCAD() : base ()
{
}

public CategoriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public CategoriaEN ReadOIDDefault (int id
                                   )
{
        CategoriaEN categoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Get (typeof(CategoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id);

                categoriaEN.Nombre = categoria.Nombre;




                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearCategoria (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (categoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoria.Id;
}

public void ModificarCategoria (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), categoria.Id);

                categoriaEN.Nombre = categoria.Nombre;

                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarCategoria (int id
                             )
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaEN categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), id);
                session.Delete (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameCategoria
//Con e: CategoriaEN
public CategoriaEN DameCategoria (int id
                                  )
{
        CategoriaEN categoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Get (typeof(CategoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> DameCategorias (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaEN)).List<CategoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnadirSuperCategoria (int p_Categoria_OID, int p_categoria_OID)
{
        JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), p_Categoria_OID);
                categoriaEN.Categoria = (JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN), p_categoria_OID);

                categoriaEN.Categoria.Subcategoria.Add (categoriaEN);



                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarSuperCategoria (int p_Categoria_OID, int p_categoria_OID)
{
        JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN categoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Load (typeof(CategoriaEN), p_Categoria_OID);
                categoriaEN.Categoria = (JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN), p_categoria_OID);

                categoriaEN.Categoria.Subcategoria.Add (categoriaEN);



                session.Update (categoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in CategoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
