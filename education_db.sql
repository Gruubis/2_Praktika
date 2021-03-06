USE [master]
GO
/****** Object:  Database [education_db]    Script Date: 2020-12-17 3:49:03 PM ******/
CREATE DATABASE [education_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'education_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\education_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'education_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\education_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [education_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [education_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [education_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [education_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [education_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [education_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [education_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [education_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [education_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [education_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [education_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [education_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [education_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [education_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [education_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [education_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [education_db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [education_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [education_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [education_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [education_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [education_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [education_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [education_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [education_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [education_db] SET  MULTI_USER 
GO
ALTER DATABASE [education_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [education_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [education_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [education_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [education_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [education_db] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [education_db] SET QUERY_STORE = OFF
GO
USE [education_db]
GO
/****** Object:  Table [dbo].[grade]    Script Date: 2020-12-17 3:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[value] [int] NOT NULL,
	[subject_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[teacher_id] [int] NULL,
	[Date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 2020-12-17 3:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[subject_id] [int] NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 2020-12-17 3:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[teacher_id] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020-12-17 3:49:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[surname] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[GRUPE] [nvarchar](50) NULL,
	[subject_id] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Subject] FOREIGN KEY([id])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Subject]
GO
USE [master]
GO
ALTER DATABASE [education_db] SET  READ_WRITE 
GO
