/****** Object:  Database [Earth]    Script Date: 2022/3/27 下午 07:03:00 ******/
/*
CREATE DATABASE [Earth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Earth', FILENAME = N'C:\Users\bruce\Earth.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Earth_log', FILENAME = N'C:\Users\bruce\Earth_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Earth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Earth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Earth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Earth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Earth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Earth] SET ARITHABORT OFF 
GO
ALTER DATABASE [Earth] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Earth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Earth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Earth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Earth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Earth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Earth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Earth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Earth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Earth] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Earth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Earth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Earth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Earth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Earth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Earth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Earth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Earth] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Earth] SET  MULTI_USER 
GO
ALTER DATABASE [Earth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Earth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Earth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Earth] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Earth] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Earth] SET QUERY_STORE = OFF
GO
*/
/****** Object:  Table [dbo].[Act]    Script Date: 2022/3/27 下午 07:03:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Act](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DonateId] [varchar](10) NOT NULL,
	[PlanCoin] [decimal](6, 1) NOT NULL,
	[RealCoin] [decimal](6, 1) NOT NULL,
	[PlanUsers] [int] NOT NULL,
	[RealUsers] [int] NOT NULL,
	[FileName] [nvarchar](100) NULL,
	[Note] [nvarchar](max) NULL,
	[Issued] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [varchar](10) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Act] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donate]    Script Date: 2022/3/27 下午 07:03:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donate](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[CorpId] [varchar](10) NOT NULL,
	[DonateCoin] [decimal](9, 1) NOT NULL,
	[RemainCoin] [decimal](9, 1) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Donate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFront]    Script Date: 2022/3/27 下午 07:03:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFront](
	[Id] [varchar](10) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Account] [varchar](30) NULL,
	[Pwd] [varchar](22) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Status] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_UserFront] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Act] ([Id], [Name], [DonateId], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (N'161DHK8GQA', N'活動1', N'D001', CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'cat3.jpg', N'test', 0, 1, N'U001', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
GO
INSERT [dbo].[Donate] ([Id], [Name], [CorpId], [DonateCoin], [RemainCoin], [Created]) VALUES (N'D001', N'D001 name', N'C001', CAST(100.0 AS Decimal(9, 1)), CAST(100.0 AS Decimal(9, 1)), CAST(N'2022-03-01T12:00:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserFront_Email]    Script Date: 2022/3/27 下午 07:03:00 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserFront_Email] ON [dbo].[UserFront]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_AssistId]  DEFAULT ('') FOR [DonateId]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_PlanCoin]  DEFAULT ((0)) FOR [PlanCoin]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_UseCoin]  DEFAULT ((0)) FOR [RealCoin]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_PlanUsers]  DEFAULT ((0)) FOR [PlanUsers]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_RealUsers]  DEFAULT ((0)) FOR [RealUsers]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_Issued]  DEFAULT ((0)) FOR [Issued]
GO
ALTER TABLE [dbo].[Donate] ADD  CONSTRAINT [DF_Donate_DonateCoin]  DEFAULT ((0)) FOR [DonateCoin]
GO
ALTER TABLE [dbo].[Donate] ADD  CONSTRAINT [DF_Donate_RemainCoin]  DEFAULT ((0)) FOR [RemainCoin]
GO
ALTER TABLE [dbo].[UserFront] ADD  CONSTRAINT [DF_UserFront_Pwd]  DEFAULT ('') FOR [Pwd]
GO
--ALTER DATABASE [Earth] SET  READ_WRITE 
--GO
