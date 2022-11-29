
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Cliente_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class ClienteCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Cliente_login) ENABLED START*/
        string result = null;
        IList<ClienteEN> listaEn = DameClientePorEmail (p_email);

        if(listaEn.Count > 0)
        {
            ClienteEN en = listaEn[0];
            if (en.Pass.Equals(Utils.Util.GetEncondeMD5(p_pass)))
                result = this.GetToken(en.Id);
        }

       

        return result;
        /*PROTECTED REGION END*/
}
}
}
