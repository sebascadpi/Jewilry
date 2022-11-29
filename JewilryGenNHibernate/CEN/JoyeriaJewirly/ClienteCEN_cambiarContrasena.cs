
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Cliente_cambiarContrasena) ENABLED START*/
using System.Linq;
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class ClienteCEN
{
public void CambiarContrasena (int p_oid, string cambio)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Cliente_cambiarContrasena) ENABLED START*/

        ClienteEN en = _IClienteCAD.DameCliente (p_oid);

        //Condiciones genericas
        if (cambio.Equals (en.Pass))
                throw new ModelException ("La contraseña nueva es igual a la anterior.");

        if (String.IsNullOrEmpty (cambio))
                throw new ModelException ("No se ha encontrado la nueva contraseña.");


        //Condiciones propuestas por nosotros para la contrase�a
        if (cambio.Length > 16 || cambio.Length < 8)
                throw new ModelException ("La contraseña tiene un formato erróneo (mínimo 8 caracteres y máximo 16)");

        if (cambio.Any (char.IsUpper) == false)
                throw new ModelException ("La contraseña necesita al menos una mayúscula");

        if (cambio.Any (char.IsLower) == false)
                throw new ModelException ("La contraseña necesita al menos una minúscula");

        if (cambio.Any (char.IsDigit) == false)
                throw new ModelException ("La contraseña necesita al menos un dígito");

        if (cambio.Any (char.IsSymbol) == false)
                throw new ModelException ("La contraseña necesita al menos un símbolo de la tabla ASCII");


        en.Pass = cambio;

        _IClienteCAD.ModificarCliente (en);

        /*PROTECTED REGION END*/
}
}
}
