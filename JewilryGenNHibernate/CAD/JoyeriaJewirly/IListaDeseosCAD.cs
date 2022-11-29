
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IListaDeseosCAD
{
ListaDeseosEN ReadOIDDefault (int id
                              );

void ModifyDefault (ListaDeseosEN listaDeseos);

System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size);



int CrearLista (ListaDeseosEN listaDeseos);

void ModificarLista (ListaDeseosEN listaDeseos);


void BorrarLista (int id
                  );


ListaDeseosEN DameLista (int id
                         );


System.Collections.Generic.IList<ListaDeseosEN> DameListas (int first, int size);


void AnadirArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs);

void QuitarArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs);
}
}
