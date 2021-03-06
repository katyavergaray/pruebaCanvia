USE [BD_Canvia]
GO
/****** Object:  Table [dbo].[T_Categoria]    Script Date: 2/03/2022 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Categoria](
	[idCategoria] [bigint] IDENTITY(1,1) NOT NULL,
	[nombreCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Detalle_Pedido]    Script Date: 2/03/2022 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Detalle_Pedido](
	[idDetallePedido] [bigint] IDENTITY(1,1) NOT NULL,
	[idPedido] [bigint] NOT NULL,
	[idProducto] [bigint] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioUnitario] [decimal](18, 2) NOT NULL,
	[subTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_T_Detalle_Pedido] PRIMARY KEY CLUSTERED 
(
	[idDetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Estado_Pedido]    Script Date: 2/03/2022 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Estado_Pedido](
	[idEstadoPedido] [bigint] IDENTITY(1,1) NOT NULL,
	[estadoPedido] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Estado_Pedido] PRIMARY KEY CLUSTERED 
(
	[idEstadoPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Pedido]    Script Date: 2/03/2022 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Pedido](
	[idPedido] [bigint] IDENTITY(1,1) NOT NULL,
	[fechaEmision] [date] NOT NULL,
	[total] [decimal](18, 2) NOT NULL,
	[observaciones] [varchar](max) NOT NULL,
	[codigo]  AS ('PE_'+right('0000'+CONVERT([varchar],[idPedido]),(5))),
	[idEstadoPedido] [bigint] NULL,
 CONSTRAINT [PK_T_Pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Producto]    Script Date: 2/03/2022 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Producto](
	[idProducto] [bigint] IDENTITY(1,1) NOT NULL,
	[nombreProducto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[precio] [decimal](18, 2) NOT NULL,
	[idCategoria] [bigint] NOT NULL,
 CONSTRAINT [PK_T_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[T_Categoria] ON 

INSERT [dbo].[T_Categoria] ([idCategoria], [nombreCategoria]) VALUES (1, N'Abarrotes')
INSERT [dbo].[T_Categoria] ([idCategoria], [nombreCategoria]) VALUES (2, N'Dulces')
INSERT [dbo].[T_Categoria] ([idCategoria], [nombreCategoria]) VALUES (3, N'Conservas')
INSERT [dbo].[T_Categoria] ([idCategoria], [nombreCategoria]) VALUES (4, N'Lacteos')
INSERT [dbo].[T_Categoria] ([idCategoria], [nombreCategoria]) VALUES (5, N'Aceites')
SET IDENTITY_INSERT [dbo].[T_Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Detalle_Pedido] ON 

INSERT [dbo].[T_Detalle_Pedido] ([idDetallePedido], [idPedido], [idProducto], [cantidad], [precioUnitario], [subTotal]) VALUES (2, 4, 1, 25, CAST(2.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[T_Detalle_Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Estado_Pedido] ON 

INSERT [dbo].[T_Estado_Pedido] ([idEstadoPedido], [estadoPedido]) VALUES (1, N'Disponible')
INSERT [dbo].[T_Estado_Pedido] ([idEstadoPedido], [estadoPedido]) VALUES (2, N'No disponible')
SET IDENTITY_INSERT [dbo].[T_Estado_Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Pedido] ON 

INSERT [dbo].[T_Pedido] ([idPedido], [fechaEmision], [total], [observaciones], [idEstadoPedido]) VALUES (4, CAST(N'2022-03-02' AS Date), CAST(50.00 AS Decimal(18, 2)), N'Enpaquetado', 1)
SET IDENTITY_INSERT [dbo].[T_Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[T_Producto] ON 

INSERT [dbo].[T_Producto] ([idProducto], [nombreProducto], [stock], [precio], [idCategoria]) VALUES (1, N'Leche Gloria', 60, CAST(3.80 AS Decimal(18, 2)), 4)
INSERT [dbo].[T_Producto] ([idProducto], [nombreProducto], [stock], [precio], [idCategoria]) VALUES (3, N'Aceite Girasol 1L', 15, CAST(8.90 AS Decimal(18, 2)), 1)
INSERT [dbo].[T_Producto] ([idProducto], [nombreProducto], [stock], [precio], [idCategoria]) VALUES (4, N'Aceite Girasol 1L', 20, CAST(9.00 AS Decimal(18, 2)), 5)
SET IDENTITY_INSERT [dbo].[T_Producto] OFF
GO
ALTER TABLE [dbo].[T_Detalle_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalle_Pedido_T_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[T_Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[T_Detalle_Pedido] CHECK CONSTRAINT [FK_T_Detalle_Pedido_T_Pedido]
GO
ALTER TABLE [dbo].[T_Detalle_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Detalle_Pedido_T_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[T_Producto] ([idProducto])
GO
ALTER TABLE [dbo].[T_Detalle_Pedido] CHECK CONSTRAINT [FK_T_Detalle_Pedido_T_Producto]
GO
ALTER TABLE [dbo].[T_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_T_Pedido_T_Estado_Pedido] FOREIGN KEY([idEstadoPedido])
REFERENCES [dbo].[T_Estado_Pedido] ([idEstadoPedido])
GO
ALTER TABLE [dbo].[T_Pedido] CHECK CONSTRAINT [FK_T_Pedido_T_Estado_Pedido]
GO
ALTER TABLE [dbo].[T_Producto]  WITH CHECK ADD  CONSTRAINT [FK_T_Producto_T_Categoria] FOREIGN KEY([idCategoria])
REFERENCES [dbo].[T_Categoria] ([idCategoria])
GO
ALTER TABLE [dbo].[T_Producto] CHECK CONSTRAINT [FK_T_Producto_T_Categoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_producto]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_delete_producto]
@idProducto bigint
AS
BEGIN
	DELETE  FROM T_Detalle_Pedido
	WHERE idProducto = @idProducto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_detalle_pedido_id]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_detalle_pedido_id]
(	
	@idPedido bigint
)
AS
BEGIN 
SELECT idDetallePedido,idPedido, p.nombreProducto, cantidad, precioUnitario, subTotal 
FROM T_Detalle_Pedido dp
INNER JOIN T_Producto p ON dp.idProducto = p.idProducto
WHERE idPedido=@idPedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_detalle_pedido_page]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_detalle_pedido_page]
(	
	@pageNo INT,
	@idPedido bigint
)
AS
BEGIN 
DECLARE @AUX INT

SELECT idDetallePedido,idPedido, p.nombreProducto, cantidad, precioUnitario, subTotal 
INTO #DetallePedido
FROM T_Detalle_Pedido dp
INNER JOIN T_Producto p ON dp.idProducto = p.idProducto
WHERE idPedido=@idPedido

SET @AUX= @pageNo * 10
SELECT * FROM #DetallePedido ORDER BY idDetallePedido
OFFSET @AUX ROWS FETCH NEXT 10 ROWS ONLY

DELETE  #DetallePedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_pedido]

AS
BEGIN 

SELECT idPedido, codigo, fechaEmision, total,observaciones 
FROM T_Pedido p INNER JOIN T_Estado_Pedido ep ON p.idEstadoPedido = ep.idEstadoPedido
ORDER BY fechaEmision
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_pedido_id]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_pedido_id]
@idPedido bigint
AS
BEGIN 

SELECT idPedido, codigo, fechaEmision, total,observaciones 
FROM T_Pedido p INNER JOIN T_Estado_Pedido ep ON p.idEstadoPedido = ep.idEstadoPedido
WHERE idPedido =@idPedido

END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_pedido_page]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_pedido_page]
(	
	@pageNo INT
)
AS
BEGIN 
DECLARE @AUX INT

SELECT idPedido, codigo, fechaEmision, total,observaciones 
INTO #Pedido
FROM T_Pedido p INNER JOIN T_Estado_Pedido ep ON p.idEstadoPedido = ep.idEstadoPedido


SET @AUX= @pageNo * 10
SELECT * FROM #Pedido ORDER BY fechaEmision
OFFSET @AUX ROWS FETCH NEXT 10 ROWS ONLY

DELETE  #Pedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_producto]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_producto]

AS
BEGIN 


SELECT idProducto,nombreProducto,precio, stock,nombreCategoria  
FROM T_Producto p 
INNER JOIN T_Categoria c ON p.idCategoria= c.idCategoria

END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_producto_id]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_producto_id]
(
	@idProducto bigint
)
AS
BEGIN 


SELECT idProducto,nombreProducto,precio, stock,nombreCategoria  
FROM T_Producto p 
INNER JOIN T_Categoria c ON p.idCategoria= c.idCategoria
WHERE idProducto=@idProducto 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_get_producto_page]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_get_producto_page]
(	
	@pageNo INT
)
AS
BEGIN 
DECLARE @AUX INT

SELECT idProducto,nombreProducto,precio, stock,nombreCategoria  
INTO #Producto
FROM T_Producto p 
INNER JOIN T_Categoria c ON p.idCategoria= c.idCategoria



SET @AUX= @pageNo * 10
SELECT * FROM #Producto ORDER BY idProducto
OFFSET @AUX ROWS FETCH NEXT 10 ROWS ONLY

DELETE  #Producto
END
GO
/****** Object:  StoredProcedure [dbo].[sp_post_detalle_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_post_detalle_pedido]
@idPedido bigint,
@idProducto bigint,
@cantidad int,
@precioUnitario decimal(18, 2),
@subTotal decimal(18, 2)
AS
BEGIN
INSERT INTO T_Detalle_Pedido(idPedido, idProducto, cantidad, precioUnitario, subTotal)
VALUES  (@idPedido, @idProducto, @cantidad, CAST (@precioUnitario AS decimal(18,2)), CAST (@subTotal AS decimal(18,2)))
END
GO
/****** Object:  StoredProcedure [dbo].[sp_post_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_post_pedido]
@total decimal(18, 2),
@observaciones nvarchar(MAX),
@idEstadoPedido bigint
AS
BEGIN
INSERT INTO T_Pedido(fechaEmision, total, observaciones,idEstadoPedido)
VALUES ( GETDATE(), CAST(@total AS decimal(18, 2)), @observaciones,@idEstadoPedido)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_post_producto]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_post_producto]
@nombre nvarchar(50),
@precio decimal(18,2),
@stock int,
@idCategoria bigint
AS
BEGIN
INSERT INTO T_Producto(nombreProducto,precio,stock,idCategoria) 
VALUES(@nombre,CAST(@precio AS Decimal(18, 0)),@stock, @idCategoria)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_put_detalle_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_put_detalle_pedido]
@idPedido bigint,
@cantidad int,
@precioUnitario decimal(18, 2),
@subTotal decimal(18, 2)
AS
BEGIN
UPDATE T_Detalle_Pedido SET 
		cantidad=@cantidad, 
		precioUnitario=CAST (@precioUnitario AS decimal(18,2)), 
		subTotal = CAST (@subTotal AS decimal(18,2))
 WHERE idPedido = @idPedido

UPDATE T_Pedido SET
	total = (SELECT SUM(subTotal) FROM T_Detalle_Pedido WHERE idPedido = @idPedido) WHERE idPedido = @idPedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_put_estado_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_put_estado_pedido]
@idPedido bigint,
@idEstadoPedido bigint
AS
BEGIN

UPDATE T_Pedido SET
idEstadoPedido = @idEstadoPedido
WHERE idPedido=@idPedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_put_pedido]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_put_pedido]
@idPedido bigint,
@observaciones nvarchar(MAX)
AS
BEGIN

UPDATE T_Pedido SET
observaciones = @observaciones
WHERE idPedido=@idPedido
END
GO
/****** Object:  StoredProcedure [dbo].[sp_put_producto]    Script Date: 2/03/2022 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_put_producto]
@idProducto bigint,
@nombre nvarchar(50),
@precio decimal(18,2),
@stock int,
@idCategoria bigint

AS
BEGIN
	UPDATE T_Producto SET
	nombreProducto = @nombre, 
	precio = @precio, 
	stock = @stock,
	idCategoria = @idCategoria
	WHERE idProducto = @idProducto
END
GO
