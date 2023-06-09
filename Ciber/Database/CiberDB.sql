USE MASTER
CREATE DATABASE [CiberDB]
GO
USE [CiberDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/26/2023 1:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](250) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Customer_1] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/26/2023 1:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Order_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NULL,
	[Product_ID] [int] NULL,
	[OrderName] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[Amount] [int] NULL,
	[Status] [int] NULL,
	[OrderDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/26/2023 1:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[ProductCategory_ID] [int] NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
	[Description] [ntext] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 5/26/2023 1:24:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategory_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [ntext] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategory_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Customer_ID], [Name], [Address], [Status]) VALUES (1, N'Customer1', N'Ha Noi', 1)
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Address], [Status]) VALUES (2, N'Customer2', N'Sai Gon', 1)
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Address], [Status]) VALUES (3, N'Customer3', N'Da Nang', 1)
INSERT [dbo].[Customer] ([Customer_ID], [Name], [Address], [Status]) VALUES (4, N'Customer4', N'Hai Phong', 1)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (1, 1, 1, N'Đơn hàng 1', CAST(N'2023-05-25T10:00:00.000' AS DateTime), 1, 1, CAST(N'2023-05-25T10:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (2, 4, 2, N'Đơn hàng 2', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 5, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (3, 2, 3, N'Đơn hàng 3', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 2, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (4, 3, 4, N'Đơn hàng 4', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 6, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (5, 2, 5, N'Đơn hàng 5', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 5, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (6, 4, 6, N'Đơn hàng 6', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 4, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (7, 1, 7, N'Đơn hàng 7', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 7, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (8, 3, 8, N'Đơn hàng 8', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 8, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (9, 3, 1, N'Đơn hàng 9', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 9, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (10, 3, 2, N'Đơn hàng 10', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 8, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (11, 2, 3, N'Đơn hàng 11', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 2, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (12, 4, 4, N'Đơn hàng 12', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 1, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (13, 1, 5, N'Đơn hàng 13', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 2, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (14, 2, 6, N'Đơn hàng 14', CAST(N'2023-05-25T00:00:00.000' AS DateTime), 3, 1, CAST(N'2023-05-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (15, 2, 1, N'Test', CAST(N'2023-05-26T10:27:59.937' AS DateTime), 10, 1, CAST(N'2023-05-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (16, 2, 5, N'Mua hoa quả', CAST(N'2023-05-26T10:36:53.997' AS DateTime), 5, 1, CAST(N'2023-06-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (17, 2, 6, N'Mua hoa quả 1', CAST(N'2023-05-26T11:00:39.950' AS DateTime), 5, 1, CAST(N'2023-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (18, 3, 1, N'Test 2', CAST(N'2023-05-26T11:03:17.687' AS DateTime), 5, 1, CAST(N'2023-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (19, 2, 2, N'Mua hoa quả 11', CAST(N'2023-05-26T11:45:45.473' AS DateTime), 3, 1, CAST(N'2023-06-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (20, 4, 7, N'Mua hoa quả', CAST(N'2023-05-26T11:46:58.993' AS DateTime), 5, 1, CAST(N'2023-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (21, 1, 2, N'3534', CAST(N'2023-05-26T11:48:00.997' AS DateTime), 3, 1, CAST(N'2023-07-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (22, 3, 8, N'AK47', CAST(N'2023-05-26T11:50:25.953' AS DateTime), 4, 1, CAST(N'2023-08-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (23, 4, 3, N'Test 2', CAST(N'2023-05-26T11:52:18.323' AS DateTime), 2, 1, CAST(N'2023-06-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (24, 2, 2, N'kkkk', CAST(N'2023-05-26T11:54:16.000' AS DateTime), 3, 1, CAST(N'2023-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (25, 2, 2, N'Test3', CAST(N'2023-05-26T12:55:47.603' AS DateTime), 2, 1, CAST(N'2023-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (26, 4, 2, N't1', CAST(N'2023-05-26T12:57:27.380' AS DateTime), 2, 1, CAST(N'2023-05-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([Order_ID], [Customer_ID], [Product_ID], [OrderName], [CreateDate], [Amount], [Status], [OrderDate]) VALUES (27, 2, 2, N't43', CAST(N'2023-05-26T12:58:33.260' AS DateTime), 2, 1, CAST(N'2023-05-27T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (1, N'Coca Cola', 1, 20000, 100, N'Nước uống Coca cola', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (2, N'Pepsi', 1, 21000, 200, N'Nước uống Pepsi', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (3, N'Seven Up', 1, 22000, 150, N'Nước uống Pepsi', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (4, N'Sprite', 1, 23000, 120, N'Nước uống Sprite', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (5, N'Cam sành', 2, 15000, 50, N'Canh sành mọng nước', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (6, N'Quýt', 2, 16000, 70, N'Quýt ngọt', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (7, N'Bánh mỳ cay Hải Phòng', 3, 5000, 140, N'Bánh mỳ cay đặc sản Hải Phòng', 1)
INSERT [dbo].[Product] ([Product_ID], [Name], [ProductCategory_ID], [Price], [Quantity], [Description], [Status]) VALUES (8, N'Bánh pate Hà Nội', 3, 60000, 115, N'Bánh pate Hà Nội', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ProductCategory_ID], [Name], [Description], [Status]) VALUES (1, N'Beverage', N'Danh mục nước giải khát', 1)
INSERT [dbo].[ProductCategory] ([ProductCategory_ID], [Name], [Description], [Status]) VALUES (2, N'Fruit', N'Danh mục hoa quả', 1)
INSERT [dbo].[ProductCategory] ([ProductCategory_ID], [Name], [Description], [Status]) VALUES (3, N'Bread', N'Danh mục bánh mỳ', 1)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Customer_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product] FOREIGN KEY([Product_ID])
REFERENCES [dbo].[Product] ([Product_ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductCategory] FOREIGN KEY([ProductCategory_ID])
REFERENCES [dbo].[ProductCategory] ([ProductCategory_ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductCategory]
GO
