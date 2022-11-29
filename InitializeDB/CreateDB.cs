
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.Enumerated.JoyeriaJewirly;
using JewilryGenNHibernate.CP.JoyeriaJewirly;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");

                ClienteCEN cliCEN = new ClienteCEN ();
                int idCliente = cliCEN.CrearCliente ("12345", "Paco", "Sanchez", "paco@paco.es", GeneroEnum.hombre, 648558485, "Su calle");
                int idCliente2 = cliCEN.CrearCliente ("12345", "Javier", "Sanchez", "paco@paco.es", GeneroEnum.hombre, 648558485, "Su calle");

                if (cliCEN.Login (idCliente, "12345") != null)
                        Console.WriteLine ("El login es correcto");

                PedidoCEN pedCEN = new PedidoCEN ();
                int idPedido = pedCEN.CrearPedido (idCliente);
                int idPedido2 = pedCEN.CrearPedido (idCliente);
                int idPedido3 = pedCEN.CrearPedido (idCliente);


                PedidoEN pedEN = new PedidoCAD ().ReadOIDDefault (idPedido);
                Console.WriteLine ("Estado del pedido " + pedEN.Estado);


                pedCEN.RealizarPedido (idPedido);
                pedCEN.RealizarPedido (idPedido2);

                PedidoEN pedEN2 = new PedidoCAD ().ReadOIDDefault (idPedido);
                Console.WriteLine ("Estado del pedido " + pedEN2.Estado);

                //pedCEN.CancelarPedido (idPedido);

                //PedidoEN pedEN3 = new PedidoCAD ().ReadOIDDefault (idPedido);
                //Console.WriteLine ("Estado del pedido " + pedEN3.Estado);

                CategoriaCEN catCEN = new CategoriaCEN ();
                int idCat1 = catCEN.CrearCategoria ("anillos");

                ArticuloCEN artCEN = new ArticuloCEN ();
                int idArt1 = artCEN.CrearArticulo (10, "anillo", "Esto es un anillo", "oro", "Pandora", 12, "su foto", idCat1, "5", 5);
                int idArt2 = artCEN.CrearArticulo (20, "collar", "Esto es un anillo", "oro", "Pandora", 10, "su foto", idCat1, "5", 5);
                int idArt3 = artCEN.CrearArticulo (15, "reloj", "Esto es un anillo", "oro", "Pandora", 50, "su foto", idCat1, "5", 5);



                ValoracionCEN valCEN = new ValoracionCEN ();
                int idVal1 = valCEN.CrearValoracion ("buena cosa", 10, idArt1, idCliente);
                int idVal2 = valCEN.CrearValoracion ("buena cosa", 0, idArt1, idCliente);

                IList<PedidoEN> listaPedidos = pedCEN.PedidosCliente (idCliente);

                foreach (PedidoEN ped in listaPedidos) {
                        Console.WriteLine ("Pedido " + ped.Estado);
                }

                ListaDeseosCEN listaCEN = new ListaDeseosCEN ();
                int idLista1 = listaCEN.CrearLista (idCliente);
                int idLista2 = listaCEN.CrearLista (idCliente2);

                listaCEN.AnadirArticulo (idLista1, new List<int> { idArt1 });
                listaCEN.AnadirArticulo (idLista1, new List<int> { idArt2 });

                listaCEN.AnadirArticulo (idLista2, new List<int> { idArt1 });



                ClienteEN cliEN = new ClienteCAD ().ReadOIDDefault (idCliente);
                ClienteEN cliEN2 = new ClienteCAD ().ReadOIDDefault (idCliente2);

                IList<ArticuloEN> listaDeseos1 = artCEN.ArticuloLista (idCliente);

                Console.WriteLine ("Lista deseos de  " + cliEN.Nombre);
                foreach (ArticuloEN art in listaDeseos1) {
                        Console.WriteLine ("Articulo " + art.Nombre);
                }

                IList<ArticuloEN> listaDeseos2 = artCEN.ArticuloLista (idCliente2);

                Console.WriteLine ("Lista deseos de " + cliEN2.Nombre);
                foreach (ArticuloEN art in listaDeseos2) {
                        Console.WriteLine ("Articulo " + art.Nombre);
                }


                double media = valCEN.CalcularMedia (idArt1);
                Console.WriteLine ("Media " + media);


                //Cambiar contrasena
                cliCEN.CambiarContrasena (idCliente, "Abcdfdd123+");
                //Al no saltar ninguna excepcion sabemos que se ha cambiado la pass aunque salga cifrada en consola
                Console.WriteLine ("Cliente pass:" + cliEN.Pass);

                //Aplicacion descuento
                DescuentoCEN desCEN = new DescuentoCEN ();
                int idDes1 = desCEN.CrearDescuento ("ASD45", 50);


                //Cambio de pago
                pedCEN.CambiarPago (idPedido, "Santander", "MasterCard", 83472923244234);
                pedEN = pedCEN.DamePedido (idPedido);
                Console.WriteLine ("Metodo pago: " + pedEN.TipoPago + " " + pedEN.TipoTarjeta + " " + pedEN.NumeroTarjeta);

                //Calcular total
                LineaPedidoCP linCP = new LineaPedidoCP ();
                LineaPedidoCEN lineaCEN = new LineaPedidoCEN ();

                linCP.CrearLinea (idArt1, idPedido, 2, 20);

                //LineaPedidoEN linEN = lineaCEN.DameLinea (idLinea);
                pedEN = pedCEN.DamePedido (idPedido);
                Console.WriteLine ("El pedido 1 tiene el total: " + pedEN.Total);

                linCP.CrearLinea (idArt2, idPedido, 4, 25);
                pedEN = pedCEN.DamePedido (idPedido);
                Console.WriteLine ("El pedido 1 tiene el total: " + pedEN.Total);

                linCP.CrearLinea (idArt3, idPedido, 2, 15);
                pedEN = pedCEN.DamePedido (idPedido);
                Console.WriteLine ("El pedido 1 tiene el total: " + pedEN.Total);

                //lineas pedido mostrar
                IList<ArticuloEN> lineaarticulos = artCEN.ArticuloPedido (idPedido);

                Console.WriteLine ("Articulos del pedido " + pedEN.Id);
                foreach (ArticuloEN art in lineaarticulos) {
                        Console.WriteLine ("Articulo " + art.Nombre);
                }
                //imprimir recibo

                //cambiar stock

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
