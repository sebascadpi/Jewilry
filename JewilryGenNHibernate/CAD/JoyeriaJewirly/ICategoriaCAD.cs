
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface ICategoriaCAD
{
CategoriaEN ReadOIDDefault (int id
                            );

void ModifyDefault (CategoriaEN categoria);

System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size);



int CrearCategoria (CategoriaEN categoria);

void ModificarCategoria (CategoriaEN categoria);


void BorrarCategoria (int id
                      );


CategoriaEN DameCategoria (int id
                           );


System.Collections.Generic.IList<CategoriaEN> DameCategorias (int first, int size);


void AnadirSuperCategoria (int p_Categoria_OID, int p_categoria_OID);

void QuitarSuperCategoria (int p_Categoria_OID, int p_categoria_OID);
}
}
