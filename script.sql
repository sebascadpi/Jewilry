USE [master]
GO
/****** Object:  Database [JoyeriaJewirlyGenNHibernate]    Script Date: 30/11/2022 11:50:26 ******/
CREATE DATABASE [JoyeriaJewirlyGenNHibernate]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JoyeriaJewirlyGenNHibernate', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JoyeriaJewirlyGenNHibernate.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JoyeriaJewirlyGenNHibernate_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\JoyeriaJewirlyGenNHibernate_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JoyeriaJewirlyGenNHibernate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ARITHABORT OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET  MULTI_USER 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET QUERY_STORE = OFF
GO
USE [JoyeriaJewirlyGenNHibernate]
GO
/****** Object:  User [nhibernateUser]    Script Date: 30/11/2022 11:50:27 ******/
CREATE USER [nhibernateUser] FOR LOGIN [nhibernateUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [nhibernateUser]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[idArticulo] [int] NOT NULL,
	[precio] [real] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL,
	[material] [nvarchar](255) NOT NULL,
	[marca] [nvarchar](255) NOT NULL,
	[stock] [int] NOT NULL,
	[foto] [nvarchar](255) NOT NULL,
	[tallas] [nvarchar](255) NOT NULL,
	[valoracionMedia] [real] NOT NULL,
	[FK_idCategoria_idCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[idCategoria] [int] NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[FK_idCategoria_idCategoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] NOT NULL,
	[pass] [nvarchar](255) NOT NULL,
	[nombre] [nvarchar](255) NOT NULL,
	[apellidos] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[genero] [int] NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [nvarchar](255) NOT NULL,
	[FK_idListaDeseos_idListaDeseos] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Descuento]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Descuento](
	[idDescuento] [int] NOT NULL,
	[cupon] [nvarchar](255) NOT NULL,
	[descuento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDescuento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hibernate_unique_key]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hibernate_unique_key](
	[next_hi] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineaPedido]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaPedido](
	[idLineaPedido] [int] NOT NULL,
	[unidades] [int] NOT NULL,
	[precio] [int] NOT NULL,
	[FK_idArticulo_idArticulo] [int] NULL,
	[FK_idPedido_idPedido] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idLineaPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListaDeseos]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListaDeseos](
	[idListaDeseos] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idListaDeseos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[listaDeseos_articulo]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[listaDeseos_articulo](
	[FK_idArticulo_idArticulo] [int] NOT NULL,
	[FK_idListaDeseos_idListaDeseos] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [int] NOT NULL,
	[estado] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[direccion] [nvarchar](255) NULL,
	[localidad] [nvarchar](255) NULL,
	[provincia] [nvarchar](255) NULL,
	[codigoPostal] [nvarchar](255) NULL,
	[tipoPago] [nvarchar](255) NULL,
	[tipoTarjeta] [nvarchar](255) NULL,
	[numeroTarjeta] [bigint] NULL,
	[total] [real] NULL,
	[FK_idCliente_idCliente] [int] NULL,
	[FK_idDescuento_idDescuento] [int] NULL,
	[FK_idRecibo_idRecibo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo](
	[idRecibo] [int] NOT NULL,
	[descripcion] [nvarchar](255) NOT NULL,
	[codigo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRecibo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valoracion]    Script Date: 30/11/2022 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valoracion](
	[idValoracion] [int] NOT NULL,
	[comentario] [nvarchar](255) NOT NULL,
	[valor] [int] NOT NULL,
	[FK_idArticulo_idArticulo] [int] NULL,
	[FK_idCliente_idCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idValoracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131072, 10, N'Anillo Corazón de Madre en Pavé', N'Eleva el tono de tu look diario con el Collar Doble Halo Brillante. Acabado a mano en plata de primera ley, este diseño incluye un colgante con una gran gema central elevada rodeada por dos halos brillantes. El halo exterior se sitúa lig', N'oro', N'Pandora', 12, N'131072.jpg', N'5', 2.5, 98304)
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131073, 20, N'Collar en plata de ley Corazones de Pandora', N'Eleva el tono de tu look diario con el Collar Doble Halo Brillante. Acabado a mano en plata de primera ley, este diseño incluye un colgante con una gran gema central elevada rodeada por dos halos brillantes. El halo exterior se sitúa lig', N'oro', N'Pandora', 10, N'131073.jpg', N'5', 3.5, 98304)
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131074, 15, N'Reloj Viceroy Dress
', N'Reloj Cronógrafo Viceroy para Caballero de Acero Bicolor con Armis de Malla Milanesa de Calibre 22mm. Esfera Negra con Números Palos. Bisel Liso Pavonado Gun Metal. Sumergible 100 metros. Caja de 43 mm.', N'oro', N'Pandora', 50, N'131074.jpg', N'5', 10, 98304)
GO
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [FK_idCategoria_idCategoria]) VALUES (98304, N'anillos', NULL)
GO
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (32768, N'Abcdfdd123+', N'Paco', N'Sanchez', N'paco@paco.es', 1, 648558485, N'Su calle', 196608)
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (32769, N'827ccb0eea8a706c4c34a16891f84e7b', N'Javier', N'Sanchez', N'javi@paco.es', 1, 648558485, N'Su calle', 196609)
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (294912, N'2e7db75ad7c3ed07169a708f82a672ca', N'Ignacio', N'Aramendía', N'dalaixgamer@gmail.com', 1, 649220425, N'Avenida Orihuela 27b 1ºiz', NULL)
GO
INSERT [dbo].[Descuento] ([idDescuento], [cupon], [descuento]) VALUES (229376, N'ASD45', 50)
GO
INSERT [dbo].[hibernate_unique_key] ([next_hi]) VALUES (10)
GO
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262144, 2, 20, 131072, 65536)
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262145, 4, 25, 131073, 65536)
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262146, 2, 15, 131074, 65536)
GO
INSERT [dbo].[ListaDeseos] ([idListaDeseos]) VALUES (196608)
INSERT [dbo].[ListaDeseos] ([idListaDeseos]) VALUES (196609)
GO
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131072, 196608)
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131073, 196608)
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131072, 196609)
GO
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65536, 2, NULL, NULL, NULL, NULL, NULL, N'Santander', N'MasterCard', 83472923244234, 130, 32768, NULL, NULL)
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65537, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 32768, NULL, NULL)
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65538, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 32768, NULL, NULL)
GO
INSERT [dbo].[Valoracion] ([idValoracion], [comentario], [valor], [FK_idArticulo_idArticulo], [FK_idCliente_idCliente]) VALUES (163840, N'Muy buen producto', 5, 131072, 32768)
INSERT [dbo].[Valoracion] ([idValoracion], [comentario], [valor], [FK_idArticulo_idArticulo], [FK_idCliente_idCliente]) VALUES (163841, N'No me ha gustado nada la calidad', 0, 131072, 32769)
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD  CONSTRAINT [FK1F853538B7AE4C69] FOREIGN KEY([FK_idCategoria_idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Articulo] CHECK CONSTRAINT [FK1F853538B7AE4C69]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK9AE67672B7AE4C69] FOREIGN KEY([FK_idCategoria_idCategoria])
REFERENCES [dbo].[Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK9AE67672B7AE4C69]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FKE156C0F99DE799F6] FOREIGN KEY([FK_idListaDeseos_idListaDeseos])
REFERENCES [dbo].[ListaDeseos] ([idListaDeseos])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FKE156C0F99DE799F6]
GO
ALTER TABLE [dbo].[LineaPedido]  WITH CHECK ADD  CONSTRAINT [FK70D5164C550FDE3B] FOREIGN KEY([FK_idArticulo_idArticulo])
REFERENCES [dbo].[Articulo] ([idArticulo])
GO
ALTER TABLE [dbo].[LineaPedido] CHECK CONSTRAINT [FK70D5164C550FDE3B]
GO
ALTER TABLE [dbo].[LineaPedido]  WITH CHECK ADD  CONSTRAINT [FK70D5164C60649D1C] FOREIGN KEY([FK_idPedido_idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[LineaPedido] CHECK CONSTRAINT [FK70D5164C60649D1C]
GO
ALTER TABLE [dbo].[listaDeseos_articulo]  WITH CHECK ADD  CONSTRAINT [FKC2A1FEF8550FDE3B] FOREIGN KEY([FK_idArticulo_idArticulo])
REFERENCES [dbo].[Articulo] ([idArticulo])
GO
ALTER TABLE [dbo].[listaDeseos_articulo] CHECK CONSTRAINT [FKC2A1FEF8550FDE3B]
GO
ALTER TABLE [dbo].[listaDeseos_articulo]  WITH CHECK ADD  CONSTRAINT [FKC2A1FEF89DE799F6] FOREIGN KEY([FK_idListaDeseos_idListaDeseos])
REFERENCES [dbo].[ListaDeseos] ([idListaDeseos])
GO
ALTER TABLE [dbo].[listaDeseos_articulo] CHECK CONSTRAINT [FKC2A1FEF89DE799F6]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FKB7BD0B981367E6B2] FOREIGN KEY([FK_idCliente_idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FKB7BD0B981367E6B2]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FKB7BD0B9855E9F953] FOREIGN KEY([FK_idRecibo_idRecibo])
REFERENCES [dbo].[Recibo] ([idRecibo])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FKB7BD0B9855E9F953]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FKB7BD0B988A39D61B] FOREIGN KEY([FK_idDescuento_idDescuento])
REFERENCES [dbo].[Descuento] ([idDescuento])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FKB7BD0B988A39D61B]
GO
ALTER TABLE [dbo].[Valoracion]  WITH CHECK ADD  CONSTRAINT [FK43F7BE571367E6B2] FOREIGN KEY([FK_idCliente_idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Valoracion] CHECK CONSTRAINT [FK43F7BE571367E6B2]
GO
ALTER TABLE [dbo].[Valoracion]  WITH CHECK ADD  CONSTRAINT [FK43F7BE57550FDE3B] FOREIGN KEY([FK_idArticulo_idArticulo])
REFERENCES [dbo].[Articulo] ([idArticulo])
GO
ALTER TABLE [dbo].[Valoracion] CHECK CONSTRAINT [FK43F7BE57550FDE3B]
GO
USE [master]
GO
ALTER DATABASE [JoyeriaJewirlyGenNHibernate] SET  READ_WRITE 
GO
