/****** Object:  Database [Earth]    Script Date: 2022/4/25 下午 03:13:21 ******/
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
/****** Object:  Table [dbo].[Act]    Script Date: 2022/4/25 下午 03:13:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Act](
	[Sn] [int] IDENTITY(1,1) NOT NULL,
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DonateId] [varchar](10) NOT NULL,
	[Caption] [nvarchar](100) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[PlanCoin] [decimal](6, 1) NOT NULL,
	[RealCoin] [decimal](6, 1) NOT NULL,
	[PlanUsers] [int] NOT NULL,
	[RealUsers] [int] NOT NULL,
	[FileName] [nvarchar](100) NULL,
	[Note] [nvarchar](max) NULL,
	[Issued] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
	[Creator] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Revised] [datetime] NULL,
 CONSTRAINT [PK_Act_1] PRIMARY KEY CLUSTERED 
(
	[Sn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donate]    Script Date: 2022/4/25 下午 03:13:21 ******/
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
/****** Object:  Table [dbo].[UserFront]    Script Date: 2022/4/25 下午 03:13:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFront](
	[Sn] [int] IDENTITY(1,1) NOT NULL,
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Account] [varchar](30) NULL,
	[Pwd] [varchar](22) NULL,
	[Phone] [varchar](15) NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [nvarchar](255) NULL,
	[Status] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_UserFront_1] PRIMARY KEY CLUSTERED 
(
	[Sn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Act] ON 

INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (1, N'2e67010c-dbdf-4f4b-955b-d9c882a0385e', N'活動1', N'D001', N'有您與全球理念相同的支持者 我們在這條守護自然之路並肩同行', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p1.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (2, N'457e13f8-9824-48a3-a0e2-affac7d5b194', N'活動2', N'D001', N'氣候、海洋、塑膠等環保議題連署行動 推動環境保護的改變,需要你的協助', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p2.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (3, N'30b13387-65af-4620-9f64-2d6840943699', N'活動3', N'D001', N'梅雨季已演變成不是乾旱就是淹水 氣候變遷影響,可能每年持續上演', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p3.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (4, N'37b445a7-5db3-47ba-8724-bee5b766c169', N'活動4', N'D001', N'環境成就，脆弱的地球需要改變及行動 結合您的力量，為環境成就更多', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p4.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (5, N'4cf8521a-c29c-437c-aeff-c41d34e7fa84', N'活動5', N'D001', N'更多詭怪離奇的垃圾，來淨灘親眼見證吧！', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p5.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (6, N'47835ab0-bc3e-4466-9965-4f2be53004a0', N'活動6', N'D001', N'一種象徵自己注重環保的行動表現。尤其在熱辣仲夏', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p6.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (7, N'fc18dc88-9da0-4a9d-8076-741f931be918', N'活動7', N'D001', N'海洋的呼喊終究無法傳遞到遙遠的島國人耳裡', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p7.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (8, N'8ce6bf3d-2d3d-4cc8-8e8e-9e4e6b6816e8', N'活動8', N'D001', N'做好回收、不亂丟垃圾並不能解決海岸垃圾的問題', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p8.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (9, N'86aaa8ac-fdcd-4d8d-acee-e07a7094f9e0', N'活動9', N'D001', N'解說員帶領民眾實際清撿海灘上的垃圾', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p9.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (10, N'66321546-ac00-4cd2-8c00-69ae1f294fd5', N'活動10', N'D001', N'沿著海岸線雙手張開排列成行，. 象徵以實際行動守護海洋', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p10.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (11, N'a464589c-9398-4321-8832-f8aecaa10cdf', N'活動11', N'D001', N'淨灘撿的不只是沙灘上的垃圾，更是清理人類心中的垃圾', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p11.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
INSERT [dbo].[Act] ([Sn], [Id], [Name], [DonateId], [Caption], [StartTime], [EndTime], [PlanCoin], [RealCoin], [PlanUsers], [RealUsers], [FileName], [Note], [Issued], [Status], [Creator], [Created], [Revised]) VALUES (12, N'6364d489-f3ba-40bf-87b0-81d3aed815bc', N'活動12', N'D001', N'淨灘紀錄表 · 世界清潔日，我們一起去海邊！', CAST(N'2022-05-01T14:00:00.000' AS DateTime), CAST(N'2022-05-01T17:00:00.000' AS DateTime), CAST(10.0 AS Decimal(6, 1)), CAST(0.0 AS Decimal(6, 1)), 0, 0, N'p12.jpg', N'test', 0, 1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', CAST(N'2022-03-19T18:49:41.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Act] OFF
GO
INSERT [dbo].[Donate] ([Id], [Name], [CorpId], [DonateCoin], [RemainCoin], [Created]) VALUES (N'D001', N'D001 name', N'C001', CAST(100.0 AS Decimal(9, 1)), CAST(100.0 AS Decimal(9, 1)), CAST(N'2022-03-01T12:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserFront] ON 

INSERT [dbo].[UserFront] ([Sn], [Id], [Name], [Account], [Pwd], [Phone], [Email], [Address], [Status], [Created]) VALUES (1, N'2b00e2a5-ae30-45dd-b0ba-4d786a9c440e', N'Alex Chen', N'aa', N'QSS8CpM1wn8IbyS6IHpJEg', NULL, N'bruce66tw@gmail.com', NULL, 1, CAST(N'2022-03-01T12:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserFront] OFF
GO
/****** Object:  Index [Act_Id]    Script Date: 2022/4/25 下午 03:13:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Act_Id] ON [dbo].[Act]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserFront_Email]    Script Date: 2022/4/25 下午 03:13:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserFront_Email] ON [dbo].[UserFront]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Act] ADD  CONSTRAINT [DF_Act_Id]  DEFAULT (newid()) FOR [Id]
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
ALTER TABLE [dbo].[UserFront] ADD  CONSTRAINT [DF_UserFront_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[UserFront] ADD  CONSTRAINT [DF_UserFront_Pwd]  DEFAULT ('') FOR [Pwd]
GO
--ALTER DATABASE [Earth] SET  READ_WRITE 
--GO
