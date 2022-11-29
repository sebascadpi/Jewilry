
using System;
using JewilryGenNHibernate.EN.JoyeriaJewirly;

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial interface IClienteCAD
{
ClienteEN ReadOIDDefault (int id
                          );

void ModifyDefault (ClienteEN cliente);

System.Collections.Generic.IList<ClienteEN> ReadAllDefault (int first, int size);



int CrearCliente (ClienteEN cliente);

void ModificarCliente (ClienteEN cliente);


void BorrarCliente (int id
                    );



ClienteEN DameCliente (int id
                       );


System.Collections.Generic.IList<ClienteEN> DameClientes (int first, int size);
}
}
