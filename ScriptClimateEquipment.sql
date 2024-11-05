USE [master]
GO

/****** Object:  Database [климатическое_оборудование]    Script Date: 05.11.2024 13:20:17 ******/
CREATE DATABASE [климатическое_оборудование]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'климатическое_оборудование', FILENAME = N'D:\MSSQL14.SQLSERVER\MSSQL\DATA\климатическое_оборудование.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'климатическое_оборудование_log', FILENAME = N'D:\MSSQL14.SQLSERVER\MSSQL\DATA\климатическое_оборудование_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [климатическое_оборудование].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [климатическое_оборудование] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET ARITHABORT OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [климатическое_оборудование] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [климатическое_оборудование] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET  DISABLE_BROKER 
GO

ALTER DATABASE [климатическое_оборудование] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [климатическое_оборудование] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [климатическое_оборудование] SET  MULTI_USER 
GO

ALTER DATABASE [климатическое_оборудование] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [климатическое_оборудование] SET DB_CHAINING OFF 
GO

ALTER DATABASE [климатическое_оборудование] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [климатическое_оборудование] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [климатическое_оборудование] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [климатическое_оборудование] SET QUERY_STORE = OFF
GO

ALTER DATABASE [климатическое_оборудование] SET  READ_WRITE 
GO

