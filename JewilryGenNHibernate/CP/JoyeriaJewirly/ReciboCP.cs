
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using JewilryGenNHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;



namespace JewilryGenNHibernate.CP.JoyeriaJewirly
{
public partial class ReciboCP : BasicCP
{
public ReciboCP() : base ()
{
}

public ReciboCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
