USE [master]
GO
/****** Object:  Database [Nissi]    Script Date: 9/9/2022 7:48:52 PM ******/
CREATE DATABASE [Nissi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Nissi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Nissi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Nissi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Nissi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Nissi] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Nissi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Nissi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Nissi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Nissi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Nissi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Nissi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Nissi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Nissi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Nissi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Nissi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Nissi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Nissi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Nissi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Nissi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Nissi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Nissi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Nissi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Nissi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Nissi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Nissi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Nissi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Nissi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Nissi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Nissi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Nissi] SET  MULTI_USER 
GO
ALTER DATABASE [Nissi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Nissi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Nissi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Nissi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Nissi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Nissi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Nissi] SET QUERY_STORE = OFF
GO
USE [Nissi]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[cl_tipoDoc] [nchar](10) NOT NULL,
	[cl_numDoc] [nchar](10) NOT NULL,
	[cl_nombre] [nvarchar](50) NOT NULL,
	[cl_direccion] [nvarchar](50) NULL,
	[cl_ciudad] [nvarchar](20) NULL,
	[cl_tel] [nvarchar](20) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detallePedido]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detallePedido](
	[id_detallePedido] [int] IDENTITY(1,1) NOT NULL,
	[ped_numPedido] [int] NOT NULL,
	[p_idItem] [int] NOT NULL,
	[cantidad] [int] NULL,
	[subtotal] [float] NULL,
	[descuento] [float] NULL,
	[total] [float] NULL,
 CONSTRAINT [PK_detallePedido] PRIMARY KEY CLUSTERED 
(
	[id_detallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventario]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventario](
	[id] [int] NOT NULL,
	[produc_idItem] [int] NOT NULL,
	[cantidadInicial] [int] NULL,
	[cantidadActual] [int] NULL,
	[cantidadVendida] [int] NULL,
	[valorTotalVendido] [float] NULL,
	[ganancia] [float] NULL,
 CONSTRAINT [PK_inventario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pedidos]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pedidos](
	[numPedido] [int] IDENTITY(101,1) NOT NULL,
	[fechaSolicitud] [date] NOT NULL,
	[cl_idCliente] [int] NOT NULL,
 CONSTRAINT [PK_pedidos] PRIMARY KEY CLUSTERED 
(
	[numPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[idItem] [int] NOT NULL,
	[p_nombre] [nvarchar](45) NOT NULL,
	[p_descripcion] [nvarchar](60) NULL,
	[talla] [nchar](5) NULL,
	[unidades] [int] NULL,
	[valorUnidadNeto] [float] NULL,
	[valorUnidadPublico] [float] NULL,
	[prov_idProveedor] [int] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[idItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedores](
	[idProv] [int] IDENTITY(1,1) NOT NULL,
	[prov_tipoDoc] [nchar](5) NOT NULL,
	[prov_numDoc] [int] NOT NULL,
	[prov_nombre] [nvarchar](50) NOT NULL,
	[prov_direccion] [nvarchar](50) NULL,
	[prov_ciudad] [nvarchar](20) NULL,
	[prov_tel] [int] NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[idProv] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id_rol] [int] NOT NULL,
	[descripcion] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 9/9/2022 7:48:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[estado] [bit] NOT NULL,
	[id_rol] [int] NOT NULL,
	[identificacion] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[avatar] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[roles] ([id_rol], [descripcion]) VALUES (1, N'Administrador')
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [nombre], [usuario], [contraseña], [estado], [id_rol], [identificacion], [telefono], [email], [apellido], [avatar]) VALUES (2003, N'Cristian', N'cristian', N'12345', 1, 1, N'10968754422', N'3134576922', N'cristian@gmail.com', N'Hernandez', N'avatar-male.png')
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [usuario], [contraseña], [estado], [id_rol], [identificacion], [telefono], [email], [apellido], [avatar]) VALUES (2004, N'Sara', N'sara', N'12345', 1, 1, N'1025978563', N'36054879652', N'sara@gmail.com', N'Giraldo', N'avatar-female.png')
INSERT [dbo].[Usuario] ([id_usuario], [nombre], [usuario], [contraseña], [estado], [id_rol], [identificacion], [telefono], [email], [apellido], [avatar]) VALUES (10, N'Angie Tatiana', N'tatiana', N'12345', 1, 1, N'1036672250', N'3229479796', N'tatianacaicedo26@gmail.com', N'Hernandez Caicedo', N'avatar-female.png')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[detallePedido]  WITH CHECK ADD FOREIGN KEY([p_idItem])
REFERENCES [dbo].[productos] ([idItem])
GO
ALTER TABLE [dbo].[detallePedido]  WITH CHECK ADD FOREIGN KEY([ped_numPedido])
REFERENCES [dbo].[pedidos] ([numPedido])
GO
ALTER TABLE [dbo].[inventario]  WITH CHECK ADD FOREIGN KEY([produc_idItem])
REFERENCES [dbo].[productos] ([idItem])
GO
ALTER TABLE [dbo].[pedidos]  WITH CHECK ADD FOREIGN KEY([cl_idCliente])
REFERENCES [dbo].[clientes] ([idCliente])
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD FOREIGN KEY([prov_idProveedor])
REFERENCES [dbo].[proveedores] ([idProv])
GO
USE [master]
GO
ALTER DATABASE [Nissi] SET  READ_WRITE 
GO
