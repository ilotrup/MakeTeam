USE [master]
GO
/****** Object:  Database [MakeTeam]    Script Date: 29/11/2019 11:43:11 ******/
CREATE DATABASE [MakeTeam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MakeTeam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MakeTeam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MakeTeam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\MakeTeam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MakeTeam] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MakeTeam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MakeTeam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MakeTeam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MakeTeam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MakeTeam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MakeTeam] SET ARITHABORT OFF 
GO
ALTER DATABASE [MakeTeam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MakeTeam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MakeTeam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MakeTeam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MakeTeam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MakeTeam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MakeTeam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MakeTeam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MakeTeam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MakeTeam] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MakeTeam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MakeTeam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MakeTeam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MakeTeam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MakeTeam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MakeTeam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MakeTeam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MakeTeam] SET RECOVERY FULL 
GO
ALTER DATABASE [MakeTeam] SET  MULTI_USER 
GO
ALTER DATABASE [MakeTeam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MakeTeam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MakeTeam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MakeTeam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MakeTeam] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MakeTeam', N'ON'
GO
ALTER DATABASE [MakeTeam] SET QUERY_STORE = OFF
GO
USE [MakeTeam]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [MakeTeam]
GO
/****** Object:  User [alumno]    Script Date: 29/11/2019 11:43:11 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Desafios]    Script Date: 29/11/2019 11:43:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desafios](
	[IDDesafio] [int] IDENTITY(1,1) NOT NULL,
	[IDEquipo1] [int] NOT NULL,
	[IDEquipo2] [int] NOT NULL,
	[FechaDeEncuentro] [date] NOT NULL,
 CONSTRAINT [PK_Desafios] PRIMARY KEY CLUSTERED 
(
	[IDDesafio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 29/11/2019 11:43:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[IDEquipo] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[IDEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquiposXUsuario]    Script Date: 29/11/2019 11:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquiposXUsuario](
	[IDEquipo] [int] NOT NULL,
	[IDUsuario] [int] NOT NULL,
 CONSTRAINT [PK_EquiposXUsuario] PRIMARY KEY CLUSTERED 
(
	[IDEquipo] ASC,
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 29/11/2019 11:43:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreDeUsuario] [varchar](50) NOT NULL,
	[CorreoElectronico] [varchar](50) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Localidad] [varchar](50) NOT NULL,
	[Sexo] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (1, N'ilucho', N'ilantrup@gmail.com', N'ilocapo', 16, N'Avellaneda', N'Masculino')
INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (2, N'damigluk', N'damian@gmail.com', N'damicapo23', 16, N'Avellaneda', N'Femenino')
INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (3, N'romobrez', N'romo@gmail.com', N'romocapo', 12, N'Avellaneda', N'Masculino')
INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (6, N'fedekozak', N'fede@gmail.com', N'fedecapo', 17, N'Avellaneda', N'Masculino')
INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (7, N'lucalongo', N'luca@gmail.com', N'lucacapo', 16, N'Avellaneda', N'Masculino')
INSERT [dbo].[Usuarios] ([IDUsuario], [NombreDeUsuario], [CorreoElectronico], [Contraseña], [Edad], [Localidad], [Sexo]) VALUES (8, N'alemik', N'ale@gmail.com', N'alecapo', 17, N'Avellaneda', N'Masculino')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
USE [master]
GO
ALTER DATABASE [MakeTeam] SET  READ_WRITE 
GO
