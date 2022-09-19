USE [master]
GO
/****** Object:  Database [PEDIDOS]    Script Date: 19/09/2022 2:26:56 a. m. ******/
CREATE DATABASE [PEDIDOS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PEDIDOS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PEDIDOS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PEDIDOS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PEDIDOS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PEDIDOS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PEDIDOS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PEDIDOS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PEDIDOS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PEDIDOS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PEDIDOS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PEDIDOS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PEDIDOS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PEDIDOS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PEDIDOS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PEDIDOS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PEDIDOS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PEDIDOS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PEDIDOS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PEDIDOS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PEDIDOS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PEDIDOS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PEDIDOS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PEDIDOS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PEDIDOS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PEDIDOS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PEDIDOS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PEDIDOS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PEDIDOS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PEDIDOS] SET RECOVERY FULL 
GO
ALTER DATABASE [PEDIDOS] SET  MULTI_USER 
GO
ALTER DATABASE [PEDIDOS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PEDIDOS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PEDIDOS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PEDIDOS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PEDIDOS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PEDIDOS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PEDIDOS', N'ON'
GO
ALTER DATABASE [PEDIDOS] SET QUERY_STORE = OFF
GO
USE [PEDIDOS]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 19/09/2022 2:26:56 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [int] NOT NULL,
	[idProducto] [int] NULL,
	[idCliente] [int] NULL,
	[observacion] [nchar](300) NULL,
	[direccion] [nchar](100) NULL,
	[cantidad] [int] NULL,
	[estado] [nchar](10) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Pedido] ([idPedido], [idProducto], [idCliente], [observacion], [direccion], [cantidad], [estado]) VALUES (74675968, 12345672, 1234567878, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', N'calle 3 n 3-18                                                                                      ', 1, N'Para envio')
GO
INSERT [dbo].[Pedido] ([idPedido], [idProducto], [idCliente], [observacion], [direccion], [cantidad], [estado]) VALUES (74675968, 0, 1234567878, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', N'calle 3 n 3-18                                                                                      ', 1, N'Para envio')
GO
INSERT [dbo].[Pedido] ([idPedido], [idProducto], [idCliente], [observacion], [direccion], [cantidad], [estado]) VALUES (74675968, 0, 1234567878, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', N'calle 3 n 3-18                                                                                      ', 2, N'Para envio')
GO
USE [master]
GO
ALTER DATABASE [PEDIDOS] SET  READ_WRITE 
GO
