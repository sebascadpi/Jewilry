USE [JoyeriaJewirlyGenNHibernate]
GO
INSERT [dbo].[ListaDeseos] ([idListaDeseos]) VALUES (196608)
INSERT [dbo].[ListaDeseos] ([idListaDeseos]) VALUES (196609)
GO
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (32768, N'Abcdfdd123+', N'Paco', N'Sanchez', N'paco@paco.es', 1, 648558485, N'Su calle', 196608)
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (32769, N'827ccb0eea8a706c4c34a16891f84e7b', N'Javier', N'Sanchez', N'javi@paco.es', 1, 648558485, N'Su calle', 196609)
INSERT [dbo].[Cliente] ([idCliente], [pass], [nombre], [apellidos], [email], [genero], [telefono], [direccion], [FK_idListaDeseos_idListaDeseos]) VALUES (294912, N'2e7db75ad7c3ed07169a708f82a672ca', N'Ignacio', N'Aramendía', N'dalaixgamer@gmail.com', 1, 649220425, N'Avenida Orihuela 27b 1ºiz', NULL)
GO
INSERT [dbo].[Descuento] ([idDescuento], [cupon], [descuento]) VALUES (229376, N'ASD45', 50)
GO
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65536, 2, NULL, NULL, NULL, NULL, NULL, N'Santander', N'MasterCard', 83472923244234, 130, 32768, NULL, NULL)
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65537, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 32768, NULL, NULL)
INSERT [dbo].[Pedido] ([idPedido], [estado], [fecha], [direccion], [localidad], [provincia], [codigoPostal], [tipoPago], [tipoTarjeta], [numeroTarjeta], [total], [FK_idCliente_idCliente], [FK_idDescuento_idDescuento], [FK_idRecibo_idRecibo]) VALUES (65538, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 32768, NULL, NULL)
GO
INSERT [dbo].[Categoria] ([idCategoria], [nombre], [FK_idCategoria_idCategoria]) VALUES (98304, N'anillos', NULL)
GO
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131072, 10, N'Anillo Corazón de Madre en Pavé', N'Eleva el tono de tu look diario con el Collar Doble Halo Brillante. Acabado a mano en plata de primera ley, este diseño incluye un colgante con una gran gema central elevada rodeada por dos halos brillantes. El halo exterior se sitúa lig', N'oro', N'Pandora', 12, N'131072.jpg', N'5', 2.5, 98304)
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131073, 20, N'Collar en plata de ley Corazones de Pandora', N'Eleva el tono de tu look diario con el Collar Doble Halo Brillante. Acabado a mano en plata de primera ley, este diseño incluye un colgante con una gran gema central elevada rodeada por dos halos brillantes. El halo exterior se sitúa lig', N'oro', N'Pandora', 10, N'131073.jpg', N'5', 3.5, 98304)
INSERT [dbo].[Articulo] ([idArticulo], [precio], [nombre], [descripcion], [material], [marca], [stock], [foto], [tallas], [valoracionMedia], [FK_idCategoria_idCategoria]) VALUES (131074, 15, N'Reloj Viceroy Dress
', N'Reloj Cronógrafo Viceroy para Caballero de Acero Bicolor con Armis de Malla Milanesa de Calibre 22mm. Esfera Negra con Números Palos. Bisel Liso Pavonado Gun Metal. Sumergible 100 metros. Caja de 43 mm.', N'oro', N'Pandora', 50, N'131074.jpg', N'5', 10, 98304)
GO
INSERT [dbo].[Valoracion] ([idValoracion], [comentario], [valor], [FK_idArticulo_idArticulo], [FK_idCliente_idCliente]) VALUES (163840, N'Muy buen producto', 5, 131072, 32768)
INSERT [dbo].[Valoracion] ([idValoracion], [comentario], [valor], [FK_idArticulo_idArticulo], [FK_idCliente_idCliente]) VALUES (163841, N'No me ha gustado nada la calidad', 0, 131072, 32769)
GO
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131072, 196608)
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131073, 196608)
INSERT [dbo].[listaDeseos_articulo] ([FK_idArticulo_idArticulo], [FK_idListaDeseos_idListaDeseos]) VALUES (131072, 196609)
GO
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262144, 2, 20, 131072, 65536)
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262145, 4, 25, 131073, 65536)
INSERT [dbo].[LineaPedido] ([idLineaPedido], [unidades], [precio], [FK_idArticulo_idArticulo], [FK_idPedido_idPedido]) VALUES (262146, 2, 15, 131074, 65536)
GO
INSERT [dbo].[hibernate_unique_key] ([next_hi]) VALUES (10)
GO
