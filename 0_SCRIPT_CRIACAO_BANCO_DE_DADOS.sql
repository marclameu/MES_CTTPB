USE [master]
GO

/****** Object:  Database [CTTPB]    Script Date: 06/09/2019 13:02:24 ******/
CREATE DATABASE [CTTPB] ON  PRIMARY 
( NAME = N'CTTPB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CTTPB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CTTPB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\CTTPB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [CTTPB] SET COMPATIBILITY_LEVEL = 100
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CTTPB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CTTPB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CTTPB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CTTPB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CTTPB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CTTPB] SET ARITHABORT OFF 
GO

ALTER DATABASE [CTTPB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CTTPB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CTTPB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CTTPB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CTTPB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CTTPB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CTTPB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CTTPB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CTTPB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CTTPB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CTTPB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CTTPB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CTTPB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CTTPB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CTTPB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CTTPB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CTTPB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CTTPB] SET RECOVERY FULL 
GO

ALTER DATABASE [CTTPB] SET  MULTI_USER 
GO

ALTER DATABASE [CTTPB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CTTPB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CTTPB] SET  READ_WRITE 
GO


