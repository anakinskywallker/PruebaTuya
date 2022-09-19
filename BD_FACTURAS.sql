USE [master]
GO
/****** Object:  Database [FACTURAS_TUYA]    Script Date: 19/09/2022 2:30:29 a. m. ******/
CREATE DATABASE [FACTURAS_TUYA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FACTURAS_TUYA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FACTURAS_TUYA.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FACTURAS_TUYA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\FACTURAS_TUYA_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [FACTURAS_TUYA] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FACTURAS_TUYA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FACTURAS_TUYA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ARITHABORT OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FACTURAS_TUYA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FACTURAS_TUYA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FACTURAS_TUYA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FACTURAS_TUYA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET RECOVERY FULL 
GO
ALTER DATABASE [FACTURAS_TUYA] SET  MULTI_USER 
GO
ALTER DATABASE [FACTURAS_TUYA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FACTURAS_TUYA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FACTURAS_TUYA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FACTURAS_TUYA] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FACTURAS_TUYA] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FACTURAS_TUYA] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'FACTURAS_TUYA', N'ON'
GO
ALTER DATABASE [FACTURAS_TUYA] SET QUERY_STORE = OFF
GO
USE [FACTURAS_TUYA]
GO
/****** Object:  Table [dbo].[Facturas]    Script Date: 19/09/2022 2:30:29 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturas](
	[IdFactura] [int] NOT NULL,
	[Observacion ] [nchar](300) NULL,
	[Subtotal] [decimal](18, 0) NULL,
	[Impuesto] [int] NULL,
	[Total] [decimal](18, 0) NULL,
	[Fecha] [nchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (1, N'Prueba                                                                                                                                                                                                                                                                                                      ', CAST(100000 AS Decimal(18, 0)), 19, CAST(100000 AS Decimal(18, 0)), N'18/09/2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (2, N'Prueba                                                                                                                                                                                                                                                                                                      ', CAST(100000 AS Decimal(18, 0)), 19, CAST(100000 AS Decimal(18, 0)), N'18/09/2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (4702352, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (20537636, NULL, CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (21014512, N'Prueba                                                                                                                                                                                                                                                                                                      ', CAST(100000 AS Decimal(18, 0)), 19, CAST(100000 AS Decimal(18, 0)), N'18/09/2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (35759472, NULL, CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (43988918, N'Esta es una factura                                                                                                                                                                                                                                                                                         ', CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (73733625, NULL, CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (74675968, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (76116620, NULL, CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
INSERT [dbo].[Facturas] ([IdFactura], [Observacion ], [Subtotal], [Impuesto], [Total], [Fecha]) VALUES (92166618, N'calle 3 n 3-18                                                                                                                                                                                                                                                                                              ', CAST(38000 AS Decimal(18, 0)), 7220, CAST(30780 AS Decimal(18, 0)), N'18-09-2022          ')
GO
USE [master]
GO
ALTER DATABASE [FACTURAS_TUYA] SET  READ_WRITE 
GO
