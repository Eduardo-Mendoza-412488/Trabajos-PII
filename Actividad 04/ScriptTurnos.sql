USE [master]
GO
/****** Object:  Database [Turnos_Peluqueria]    Script Date: 02/10/2024 22:56:36 ******/
CREATE DATABASE [Turnos_Peluqueria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Turnos_Peluqueria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Turnos_Peluqueria.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Turnos_Peluqueria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS2014\MSSQL\DATA\Turnos_Peluqueria_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Turnos_Peluqueria] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Turnos_Peluqueria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Turnos_Peluqueria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Turnos_Peluqueria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Turnos_Peluqueria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Turnos_Peluqueria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Turnos_Peluqueria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Turnos_Peluqueria] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Turnos_Peluqueria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Turnos_Peluqueria] SET  MULTI_USER 
GO
ALTER DATABASE [Turnos_Peluqueria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Turnos_Peluqueria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Turnos_Peluqueria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Turnos_Peluqueria] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Turnos_Peluqueria] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Turnos_Peluqueria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/10/2024 22:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesTurno]    Script Date: 02/10/2024 22:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesTurno](
	[id_turno] [int] NOT NULL,
	[id_servicio] [int] NOT NULL,
	[observaciones] [varchar](200) NOT NULL,
 CONSTRAINT [PK_DetallesTurno] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC,
	[id_servicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicios]    Script Date: 02/10/2024 22:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicios](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[costo] [int] NOT NULL,
	[Promocion] [bit] NOT NULL,
 CONSTRAINT [PK_Servicios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 02/10/2024 22:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime2](7) NOT NULL,
	[hora] [time](7) NOT NULL,
	[cliente] [varchar](100) NULL,
	[Cancelacion] [bit] NOT NULL,
	[motivo_cancelacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Turnos_Peluqueria] SET  READ_WRITE 
GO
