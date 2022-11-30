using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using Jewilry.Models;

namespace Jewilry.Assemblers
{
    public class ValoracionAssembler
    {
        public ValoracionViewModel ConvertENToModelUI(ValoracionEN en)
        {
            ValoracionViewModel art = new ValoracionViewModel();
            art.Id = en.Id;
            art.Comentario = en.Comentario;
            art.Valor = en.Valor;
            art.Articulo = en.Articulo;
            art.Cliente = en.Cliente;




            return art;
        }

        public IList<ValoracionViewModel> ConvertListENToModel(IList<ValoracionEN> ens)
        {
            IList<ValoracionViewModel> arts = new List<ValoracionViewModel>();

            foreach(ValoracionEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}