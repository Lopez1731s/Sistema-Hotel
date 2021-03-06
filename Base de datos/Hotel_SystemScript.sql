USE [master]
GO
/****** Object:  Database [proyecto]    Script Date: 01/11/2019 21:48:30 ******/
CREATE DATABASE [proyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyecto', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\proyecto.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'proyecto_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\proyecto_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [proyecto] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [proyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [proyecto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyecto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyecto] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyecto] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [proyecto] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyecto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyecto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyecto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyecto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyecto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyecto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [proyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyecto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [proyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [proyecto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [proyecto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [proyecto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [proyecto] SET  MULTI_USER 
GO
ALTER DATABASE [proyecto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [proyecto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [proyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [proyecto] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [proyecto]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[DUI] [int] NULL,
	[Pasaporte] [int] NULL,
	[Genero] [varchar](50) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Nacionalidad] [varchar](50) NOT NULL,
	[Pais] [varchar](50) NOT NULL,
	[Fecha_Nacimiento] [date] NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Telefono] [int] NOT NULL,
	[Estado] [int] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Habitaciones]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Habitaciones](
	[ID_Habitacion] [int] IDENTITY(1,1) NOT NULL,
	[Numero_Habitacion] [int] NOT NULL,
	[Disponibilidad] [varchar](50) NOT NULL,
	[TIpo] [varchar](50) NOT NULL,
	[Numero_Camas] [int] NOT NULL,
	[precio] [float] NULL,
 CONSTRAINT [PK_Habitaciones] PRIMARY KEY CLUSTERED 
(
	[ID_Habitacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Historial_Habitaciones]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial_Habitaciones](
	[id_Historial] [int] IDENTITY(1,1) NOT NULL,
	[id_Relacion] [int] NULL,
	[ID_Habitacion] [int] NULL,
	[ID] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Fecha_Salida] [date] NULL,
	[Estadia] [int] NULL,
	[Total_Pagar] [int] NULL,
	[Precio] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Historial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[R_Habitacion]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[R_Habitacion](
	[id_Relacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Habitacion] [int] NULL,
	[ID] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Fecha_Salida] [date] NULL,
	[Estadia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Relacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicios](
	[Servicios_ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Servicio] [varchar](50) NOT NULL,
	[Descripcion_Servicio] [varchar](255) NOT NULL,
	[Costo_Servicio] [money] NOT NULL,
	[ID_Habitacion] [int] NOT NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[Servicios_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 01/11/2019 21:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [varchar](50) NOT NULL,
	[Apellidos_Usuario] [varchar](50) NOT NULL,
	[Cargo_Usuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([ID], [Nombres], [Apellidos], [DUI], [Pasaporte], [Genero], [Direccion], [Nacionalidad], [Pais], [Fecha_Nacimiento], [Correo], [Telefono], [Estado]) VALUES (1, N'Jonathan Nahun', N'Lopez Arias', 13645481, NULL, N'Hombre', N'Calle 412', N'Salvadoreño', N'El Salvador', CAST(0x9E240B00 AS Date), N'nahun2000@gmail.com', 78986514, 1)
INSERT [dbo].[Clientes] ([ID], [Nombres], [Apellidos], [DUI], [Pasaporte], [Genero], [Direccion], [Nacionalidad], [Pais], [Fecha_Nacimiento], [Correo], [Telefono], [Estado]) VALUES (2, N'Margarita', N'Perez Lopez', NULL, 98985634, N'Mujer', N'Avenida 2312 Calle 413', N'Hondureña', N'Honduras', CAST(0x1F150B00 AS Date), N'mar@gmail.com', 8984562, 1)
INSERT [dbo].[Clientes] ([ID], [Nombres], [Apellidos], [DUI], [Pasaporte], [Genero], [Direccion], [Nacionalidad], [Pais], [Fecha_Nacimiento], [Correo], [Telefono], [Estado]) VALUES (3, N'Carlos Antonio', N'Lopez Calderon', NULL, 8765231, N'Hombre', N'Calle 312', N'Nicaraguense', N'Nicaragua', CAST(0x27240B00 AS Date), N'Jperez@gmail.com', 87841248, 1)
INSERT [dbo].[Clientes] ([ID], [Nombres], [Apellidos], [DUI], [Pasaporte], [Genero], [Direccion], [Nacionalidad], [Pais], [Fecha_Nacimiento], [Correo], [Telefono], [Estado]) VALUES (4, N'Juana del Carmen', N'Perez', 878452120, NULL, N'Hombre', N'Calle 4432', N'Salvadoreña', N'El Salvador', CAST(0x53400B00 AS Date), N'Juana@gmail.com', 78745212, 1)
INSERT [dbo].[Clientes] ([ID], [Nombres], [Apellidos], [DUI], [Pasaporte], [Genero], [Direccion], [Nacionalidad], [Pais], [Fecha_Nacimiento], [Correo], [Telefono], [Estado]) VALUES (5, N'Jose Carlos', N'Lopes', NULL, 87978745, N'Hombre', N'Calle 4232', N'Hondureño', N'El Salvador', CAST(0x60140B00 AS Date), N'JL@gmail.com', 78986500, 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Habitaciones] ON 

INSERT [dbo].[Habitaciones] ([ID_Habitacion], [Numero_Habitacion], [Disponibilidad], [TIpo], [Numero_Camas], [precio]) VALUES (1, 1, N'Ocupado', N'Individual', 1, 60)
SET IDENTITY_INSERT [dbo].[Habitaciones] OFF
SET IDENTITY_INSERT [dbo].[Historial_Habitaciones] ON 

INSERT [dbo].[Historial_Habitaciones] ([id_Historial], [id_Relacion], [ID_Habitacion], [ID], [Fecha_Ingreso], [Fecha_Salida], [Estadia], [Total_Pagar], [Precio]) VALUES (1, 1, 1, 1, CAST(0x53400B00 AS Date), CAST(0x55400B00 AS Date), 2, 120, 60)
INSERT [dbo].[Historial_Habitaciones] ([id_Historial], [id_Relacion], [ID_Habitacion], [ID], [Fecha_Ingreso], [Fecha_Salida], [Estadia], [Total_Pagar], [Precio]) VALUES (2, 2, 1, 2, CAST(0x53400B00 AS Date), CAST(0x53400B00 AS Date), 0, 0, 60)
INSERT [dbo].[Historial_Habitaciones] ([id_Historial], [id_Relacion], [ID_Habitacion], [ID], [Fecha_Ingreso], [Fecha_Salida], [Estadia], [Total_Pagar], [Precio]) VALUES (3, 3, 1, 1, CAST(0x53400B00 AS Date), CAST(0x53400B00 AS Date), 0, 0, 60)
SET IDENTITY_INSERT [dbo].[Historial_Habitaciones] OFF
SET IDENTITY_INSERT [dbo].[R_Habitacion] ON 

INSERT [dbo].[R_Habitacion] ([id_Relacion], [ID_Habitacion], [ID], [Fecha_Ingreso], [Fecha_Salida], [Estadia]) VALUES (4, 1, 4, CAST(0x53400B00 AS Date), CAST(0x53400B00 AS Date), 0)
SET IDENTITY_INSERT [dbo].[R_Habitacion] OFF
ALTER TABLE [dbo].[R_Habitacion]  WITH CHECK ADD FOREIGN KEY([ID_Habitacion])
REFERENCES [dbo].[Habitaciones] ([ID_Habitacion])
GO
ALTER TABLE [dbo].[R_Habitacion]  WITH CHECK ADD FOREIGN KEY([ID])
REFERENCES [dbo].[Clientes] ([ID])
GO
USE [master]
GO
ALTER DATABASE [proyecto] SET  READ_WRITE 
GO
