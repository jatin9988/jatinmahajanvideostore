USE [master]
GO
/****** Object:  Database [VSR_System]    Script Date: 12/21/2018 4:53:11 AM ******/
CREATE DATABASE [VSR_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VSR_System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VSR_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VSR_System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VSR_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VSR_System] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VSR_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VSR_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VSR_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VSR_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VSR_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VSR_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VSR_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VSR_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VSR_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VSR_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VSR_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VSR_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VSR_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VSR_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VSR_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VSR_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VSR_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VSR_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VSR_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VSR_System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VSR_System] SET  MULTI_USER 
GO
ALTER DATABASE [VSR_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VSR_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VSR_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VSR_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VSR_System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VSR_System] SET QUERY_STORE = OFF
GO
USE [VSR_System]
GO
/****** Object:  Table [dbo].[Coustmer]    Script Date: 12/21/2018 4:53:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coustmer](
	[CustID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 12/21/2018 4:53:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Year] [nvarchar](50) NULL,
	[Rental_Cost] [money] NULL,
	[Plot] [ntext] NULL,
	[Genre] [nchar](10) NULL,
	[copies] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentedMovies]    Script Date: 12/21/2018 4:53:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentedMovies](
	[RMID] [int] IDENTITY(1,1) NOT NULL,
	[MovieIDFK] [int] NULL,
	[CustIDFK] [int] NULL,
	[DateRented] [datetime] NULL,
	[DateReturned] [datetime] NULL,
	[isout] [int] NULL,
 CONSTRAINT [PK_RentedMovie] PRIMARY KEY CLUSTERED 
(
	[RMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userdata]    Script Date: 12/21/2018 4:53:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userdata](
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coustmer] ON 

INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (1, N'jhon', N'macvire', N'henderson', N'0228394738')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (3, N'Jatin', N'brar', N'21a holly ford', N'5685677')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (4, N'mohit', N'dheer', N'palrat nagar', N'9176553')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (5, N'loveleen', N'bhati', N'3a policelin', N'9815233648')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (6, N'Muskan', N'Katria', N'grren', N'928384782')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (7, N'narinder', N'Kaur', N'214 fateghar road', N'927382734')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (9, N'Surbhi', N'Sharma', N'325,Vigay Nagar', N'96547875')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (11, N'kanika ', N'Bakshi', N'2 shankr gali ramnagar', N'8699722739')
INSERT [dbo].[Coustmer] ([CustID], [FirstName], [LastName], [Address], [Phone]) VALUES (12, N'Vedka ', N'Sharma ', N'72, genn', N'93846372')
SET IDENTITY_INSERT [dbo].[Coustmer] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (2, N'2', N'hellkong', N'2012', 2.0000, N'1', N'horroe    ', 21)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (3, N'5', N'James Bond', N'2012', 2.0000, N'agent', N'action    ', 5)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (4, N'5', N'twilight', N'2017', 5.0000, N'Vampire', N'Romantic  ', 3)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (5, N'3', N'two and half men', N'2016', 5.0000, N'funny', N'comedyy   ', 8)
INSERT [dbo].[Movies] ([MovieID], [Rating], [Title], [Year], [Rental_Cost], [Plot], [Genre], [copies]) VALUES (6, N'4', N'The 300', N'2015', 5.0000, N'spartan', N'action    ', 12)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[RentedMovies] ON 

INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (1, 2, 1, CAST(N'2018-12-20T02:05:54.137' AS DateTime), CAST(N'2018-12-20T02:37:42.000' AS DateTime), NULL)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (2, 5, 4, CAST(N'2018-12-21T01:55:53.430' AS DateTime), CAST(N'2018-12-21T01:56:17.000' AS DateTime), 1)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (3, 5, 7, CAST(N'2018-12-21T01:56:01.637' AS DateTime), NULL, 1)
INSERT [dbo].[RentedMovies] ([RMID], [MovieIDFK], [CustIDFK], [DateRented], [DateReturned], [isout]) VALUES (4, 5, 11, CAST(N'2018-12-21T01:56:09.043' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[RentedMovies] OFF
INSERT [dbo].[userdata] ([UserName], [Password]) VALUES (N'1', N'1')
USE [master]
GO
ALTER DATABASE [VSR_System] SET  READ_WRITE 
GO
