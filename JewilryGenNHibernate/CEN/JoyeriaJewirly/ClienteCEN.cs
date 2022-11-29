

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;

using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
/*
 *      Definition of the class ClienteCEN
 *
 */
public partial class ClienteCEN
{
private IClienteCAD _IClienteCAD;

public ClienteCEN()
{
        this._IClienteCAD = new ClienteCAD ();
}

public ClienteCEN(IClienteCAD _IClienteCAD)
{
        this._IClienteCAD = _IClienteCAD;
}

public IClienteCAD get_IClienteCAD ()
{
        return this._IClienteCAD;
}

public int CrearCliente (String p_pass, string p_nombre, string p_apellidos, string p_email, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum p_genero, int p_telefono, string p_direccion)
{
        ClienteEN clienteEN = null;
        int oid;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        clienteEN.Nombre = p_nombre;

        clienteEN.Apellidos = p_apellidos;

        clienteEN.Email = p_email;

        clienteEN.Genero = p_genero;

        clienteEN.Telefono = p_telefono;

        clienteEN.Direccion = p_direccion;

        //Call to ClienteCAD

        oid = _IClienteCAD.CrearCliente (clienteEN);
        return oid;
}

public void ModificarCliente (int p_Cliente_OID, String p_pass, string p_nombre, string p_apellidos, string p_email, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.GeneroEnum p_genero, int p_telefono, string p_direccion)
{
        ClienteEN clienteEN = null;

        //Initialized ClienteEN
        clienteEN = new ClienteEN ();
        clienteEN.Id = p_Cliente_OID;
        clienteEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        clienteEN.Nombre = p_nombre;
        clienteEN.Apellidos = p_apellidos;
        clienteEN.Email = p_email;
        clienteEN.Genero = p_genero;
        clienteEN.Telefono = p_telefono;
        clienteEN.Direccion = p_direccion;
        //Call to ClienteCAD

        _IClienteCAD.ModificarCliente (clienteEN);
}

public void BorrarCliente (int id
                           )
{
        _IClienteCAD.BorrarCliente (id);
}

public string Login (int p_Cliente_OID, string p_pass)
{
        string result = null;
        ClienteEN en = _IClienteCAD.ReadOIDDefault (p_Cliente_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public ClienteEN DameCliente (int id
                              )
{
        ClienteEN clienteEN = null;

        clienteEN = _IClienteCAD.DameCliente (id);
        return clienteEN;
}

public System.Collections.Generic.IList<ClienteEN> DameClientes (int first, int size)
{
        System.Collections.Generic.IList<ClienteEN> list = null;

        list = _IClienteCAD.DameClientes (first, size);
        return list;
}



private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        ClienteEN en = _IClienteCAD.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                ClienteEN en = _IClienteCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
