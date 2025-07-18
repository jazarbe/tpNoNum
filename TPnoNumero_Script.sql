USE [master]
GO
/****** Object:  Database [Integrantes]    Script Date: 17/7/2025 14:03:46 ******/
CREATE DATABASE [Integrantes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Integrantes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Integrantes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Integrantes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Integrantes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Integrantes] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Integrantes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Integrantes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Integrantes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Integrantes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Integrantes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Integrantes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Integrantes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Integrantes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Integrantes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Integrantes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Integrantes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Integrantes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Integrantes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Integrantes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Integrantes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Integrantes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Integrantes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Integrantes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Integrantes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Integrantes] SET RECOVERY FULL 
GO
ALTER DATABASE [Integrantes] SET  MULTI_USER 
GO
ALTER DATABASE [Integrantes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Integrantes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Integrantes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Integrantes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Integrantes] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Integrantes', N'ON'
GO
ALTER DATABASE [Integrantes] SET QUERY_STORE = OFF
GO
USE [Integrantes]
GO
/****** Object:  User [alumno]    Script Date: 17/7/2025 14:03:46 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[grupo]    Script Date: 17/7/2025 14:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grupo](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_grupo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Integrante]    Script Date: 17/7/2025 14:03:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Integrante](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[contra] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[fechaNac] [datetime] NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[rol] [varchar](50) NOT NULL,
	[foto] [varchar](50) NULL,
	[idGrupo] [int] NOT NULL,
 CONSTRAINT [PK_Integrante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[grupo] ([id], [nombre]) VALUES (1, N'ajjajaja')
INSERT [dbo].[grupo] ([id], [nombre]) VALUES (2, N'blabla')
GO
SET IDENTITY_INSERT [dbo].[Integrante] ON 

INSERT [dbo].[Integrante] ([id], [nombre], [contra], [email], [fechaNac], [telefono], [direccion], [rol], [foto], [idGrupo]) VALUES (1, N'domix', N'choe_reinara', N'domix@peakmail.com', CAST(N'2009-02-01T00:00:00.000' AS DateTime), N'1149190832', N'Isla Balatro', N'iniciador', N'dami.jfif', 1)
INSERT [dbo].[Integrante] ([id], [nombre], [contra], [email], [fechaNac], [telefono], [direccion], [rol], [foto], [idGrupo]) VALUES (4, N'Jonina', N'Johnnon', N'joninator@llimail.com', CAST(N'2002-05-15T00:00:00.000' AS DateTime), N'1149549062', N'Av. De Mi Casa padre', N'duelista', N'jona.jfif', 1)
INSERT [dbo].[Integrante] ([id], [nombre], [contra], [email], [fechaNac], [telefono], [direccion], [rol], [foto], [idGrupo]) VALUES (7, N'jazarbe', N'arbejazzz', N'jaz@jazmail.com', CAST(N'2009-10-05T00:00:00.000' AS DateTime), N'1149308713', N'ORT (casi)', N'sentinela', N'jaz.jfif', 1)
INSERT [dbo].[Integrante] ([id], [nombre], [contra], [email], [fechaNac], [telefono], [direccion], [rol], [foto], [idGrupo]) VALUES (8, N'a', N'a', N'a@mail.com', CAST(N'2000-01-01T00:00:00.000' AS DateTime), N'123', N'a', N'a', N'Captura de pantalla 2025-07-17 140247.png', 2)
SET IDENTITY_INSERT [dbo].[Integrante] OFF
GO
ALTER TABLE [dbo].[Integrante]  WITH CHECK ADD  CONSTRAINT [FK_Integrante_grupo] FOREIGN KEY([idGrupo])
REFERENCES [dbo].[grupo] ([id])
GO
ALTER TABLE [dbo].[Integrante] CHECK CONSTRAINT [FK_Integrante_grupo]
GO
USE [master]
GO
ALTER DATABASE [Integrantes] SET  READ_WRITE 
GO
