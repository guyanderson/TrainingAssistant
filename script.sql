USE [master]
GO
/****** Object:  Database [TrainingHelper]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE DATABASE [TrainingHelper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainingHelper', FILENAME = N'C:\Users\Guy\TrainingHelper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainingHelper_log', FILENAME = N'C:\Users\Guy\TrainingHelper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TrainingHelper] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TrainingHelper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TrainingHelper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TrainingHelper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TrainingHelper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TrainingHelper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TrainingHelper] SET ARITHABORT OFF 
GO
ALTER DATABASE [TrainingHelper] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TrainingHelper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TrainingHelper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TrainingHelper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TrainingHelper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TrainingHelper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TrainingHelper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TrainingHelper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TrainingHelper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TrainingHelper] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TrainingHelper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TrainingHelper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TrainingHelper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TrainingHelper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TrainingHelper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TrainingHelper] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TrainingHelper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TrainingHelper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TrainingHelper] SET  MULTI_USER 
GO
ALTER DATABASE [TrainingHelper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TrainingHelper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TrainingHelper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TrainingHelper] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TrainingHelper] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TrainingHelper] SET QUERY_STORE = OFF
GO
USE [TrainingHelper]
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
USE [TrainingHelper]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/19/2017 3:36:44 PM ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[FabId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bays]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bays](
	[BayId] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TargetTrained] [int] NOT NULL,
 CONSTRAINT [PK_Bays] PRIMARY KEY CLUSTERED 
(
	[BayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Certifications]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certifications](
	[CertificationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[TargetTrained] [int] NOT NULL,
 CONSTRAINT [PK_Certifications] PRIMARY KEY CLUSTERED 
(
	[CertificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fab]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fab](
	[FabId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Fab] PRIMARY KEY CLUSTERED 
(
	[FabId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperatorCertifications]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatorCertifications](
	[OperatorCertificationsId] [int] IDENTITY(1,1) NOT NULL,
	[CertificationId] [int] NULL,
	[OperatorCertificationsId1] [int] NULL,
	[OperatorId] [int] NULL,
	[ShiftId] [int] NULL,
 CONSTRAINT [PK_OperatorCertifications] PRIMARY KEY CLUSTERED 
(
	[OperatorCertificationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Operators]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operators](
	[OperatorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ShiftId] [int] NOT NULL,
 CONSTRAINT [PK_Operators] PRIMARY KEY CLUSTERED 
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[FabId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tools]    Script Date: 9/19/2017 3:36:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tools](
	[ToolId] [int] IDENTITY(1,1) NOT NULL,
	[BayId] [int] NOT NULL,
	[CertificationId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tools] PRIMARY KEY CLUSTERED 
(
	[ToolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170916003357_initial', N'1.0.0-rtm-21431')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170916004955_FabName', N'1.0.0-rtm-21431')
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([AreaId], [FabId], [Name]) VALUES (1, 1, N'Photo')
INSERT [dbo].[Areas] ([AreaId], [FabId], [Name]) VALUES (2, 1, N'Plasma Etch')
INSERT [dbo].[Areas] ([AreaId], [FabId], [Name]) VALUES (3, 1, N'Wet Etch')
INSERT [dbo].[Areas] ([AreaId], [FabId], [Name]) VALUES (4, 1, N'Metals')
INSERT [dbo].[Areas] ([AreaId], [FabId], [Name]) VALUES (6, 1, N'zxcv')
SET IDENTITY_INSERT [dbo].[Areas] OFF
SET IDENTITY_INSERT [dbo].[Bays] ON 

INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (1, 1, N'Photo Bay 1', 3)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (3, 1, N'Photo Bay 2', 3)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (5, 3, N'Wet Etch Bay 1', 3)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (9, 6, N'xzvc', 5)
SET IDENTITY_INSERT [dbo].[Bays] OFF
SET IDENTITY_INSERT [dbo].[Certifications] ON 

INSERT [dbo].[Certifications] ([CertificationId], [Name], [TargetTrained]) VALUES (1, N'Ultratech', 2)
INSERT [dbo].[Certifications] ([CertificationId], [Name], [TargetTrained]) VALUES (2, N'ASML', 3)
INSERT [dbo].[Certifications] ([CertificationId], [Name], [TargetTrained]) VALUES (3, N'Tel', 0)
SET IDENTITY_INSERT [dbo].[Certifications] OFF
SET IDENTITY_INSERT [dbo].[Fab] ON 

INSERT [dbo].[Fab] ([FabId], [Name]) VALUES (1, N'Fab')
SET IDENTITY_INSERT [dbo].[Fab] OFF
SET IDENTITY_INSERT [dbo].[Operators] ON 

INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (1, N'Guyzer', 1)
INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (2, N'Bob', 1)
INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (4, N'Joe', 1)
INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (6, N'sdgf', 4)
SET IDENTITY_INSERT [dbo].[Operators] OFF
SET IDENTITY_INSERT [dbo].[Shifts] ON 

INSERT [dbo].[Shifts] ([ShiftId], [FabId], [Name]) VALUES (1, 1, N'Day 1')
INSERT [dbo].[Shifts] ([ShiftId], [FabId], [Name]) VALUES (4, 1, N'D2')
INSERT [dbo].[Shifts] ([ShiftId], [FabId], [Name]) VALUES (6, 1, N'sdfg')
SET IDENTITY_INSERT [dbo].[Shifts] OFF
SET IDENTITY_INSERT [dbo].[Tools] ON 

INSERT [dbo].[Tools] ([ToolId], [BayId], [CertificationId], [Name]) VALUES (1, 1, 1, N'Ultratech 1')
INSERT [dbo].[Tools] ([ToolId], [BayId], [CertificationId], [Name]) VALUES (3, 3, 2, N'ASML 1')
INSERT [dbo].[Tools] ([ToolId], [BayId], [CertificationId], [Name]) VALUES (4, 3, 2, N'ASML 2')
INSERT [dbo].[Tools] ([ToolId], [BayId], [CertificationId], [Name]) VALUES (6, 9, 3, N'afa')
SET IDENTITY_INSERT [dbo].[Tools] OFF
/****** Object:  Index [IX_Areas_FabId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Areas_FabId] ON [dbo].[Areas]
(
	[FabId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Bays_AreaId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bays_AreaId] ON [dbo].[Bays]
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OperatorCertifications_CertificationId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_OperatorCertifications_CertificationId] ON [dbo].[OperatorCertifications]
(
	[CertificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OperatorCertifications_OperatorCertificationsId1]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_OperatorCertifications_OperatorCertificationsId1] ON [dbo].[OperatorCertifications]
(
	[OperatorCertificationsId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OperatorCertifications_OperatorId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_OperatorCertifications_OperatorId] ON [dbo].[OperatorCertifications]
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OperatorCertifications_ShiftId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_OperatorCertifications_ShiftId] ON [dbo].[OperatorCertifications]
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Operators_ShiftId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Operators_ShiftId] ON [dbo].[Operators]
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Shifts_FabId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Shifts_FabId] ON [dbo].[Shifts]
(
	[FabId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tools_BayId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tools_BayId] ON [dbo].[Tools]
(
	[BayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tools_CertificationId]    Script Date: 9/19/2017 3:36:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tools_CertificationId] ON [dbo].[Tools]
(
	[CertificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Fab_FabId] FOREIGN KEY([FabId])
REFERENCES [dbo].[Fab] ([FabId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Fab_FabId]
GO
ALTER TABLE [dbo].[Bays]  WITH CHECK ADD  CONSTRAINT [FK_Bays_Areas_AreaId] FOREIGN KEY([AreaId])
REFERENCES [dbo].[Areas] ([AreaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bays] CHECK CONSTRAINT [FK_Bays_Areas_AreaId]
GO
ALTER TABLE [dbo].[OperatorCertifications]  WITH CHECK ADD  CONSTRAINT [FK_OperatorCertifications_Certifications_CertificationId] FOREIGN KEY([CertificationId])
REFERENCES [dbo].[Certifications] ([CertificationId])
GO
ALTER TABLE [dbo].[OperatorCertifications] CHECK CONSTRAINT [FK_OperatorCertifications_Certifications_CertificationId]
GO
ALTER TABLE [dbo].[OperatorCertifications]  WITH CHECK ADD  CONSTRAINT [FK_OperatorCertifications_OperatorCertifications_OperatorCertificationsId1] FOREIGN KEY([OperatorCertificationsId1])
REFERENCES [dbo].[OperatorCertifications] ([OperatorCertificationsId])
GO
ALTER TABLE [dbo].[OperatorCertifications] CHECK CONSTRAINT [FK_OperatorCertifications_OperatorCertifications_OperatorCertificationsId1]
GO
ALTER TABLE [dbo].[OperatorCertifications]  WITH CHECK ADD  CONSTRAINT [FK_OperatorCertifications_Operators_OperatorId] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operators] ([OperatorId])
GO
ALTER TABLE [dbo].[OperatorCertifications] CHECK CONSTRAINT [FK_OperatorCertifications_Operators_OperatorId]
GO
ALTER TABLE [dbo].[OperatorCertifications]  WITH CHECK ADD  CONSTRAINT [FK_OperatorCertifications_Shifts_ShiftId] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shifts] ([ShiftId])
GO
ALTER TABLE [dbo].[OperatorCertifications] CHECK CONSTRAINT [FK_OperatorCertifications_Shifts_ShiftId]
GO
ALTER TABLE [dbo].[Operators]  WITH CHECK ADD  CONSTRAINT [FK_Operators_Shifts_ShiftId] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[Shifts] ([ShiftId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Operators] CHECK CONSTRAINT [FK_Operators_Shifts_ShiftId]
GO
ALTER TABLE [dbo].[Shifts]  WITH CHECK ADD  CONSTRAINT [FK_Shifts_Fab_FabId] FOREIGN KEY([FabId])
REFERENCES [dbo].[Fab] ([FabId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shifts] CHECK CONSTRAINT [FK_Shifts_Fab_FabId]
GO
ALTER TABLE [dbo].[Tools]  WITH CHECK ADD  CONSTRAINT [FK_Tools_Bays_BayId] FOREIGN KEY([BayId])
REFERENCES [dbo].[Bays] ([BayId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tools] CHECK CONSTRAINT [FK_Tools_Bays_BayId]
GO
ALTER TABLE [dbo].[Tools]  WITH CHECK ADD  CONSTRAINT [FK_Tools_Certifications_CertificationId] FOREIGN KEY([CertificationId])
REFERENCES [dbo].[Certifications] ([CertificationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tools] CHECK CONSTRAINT [FK_Tools_Certifications_CertificationId]
GO
USE [master]
GO
ALTER DATABASE [TrainingHelper] SET  READ_WRITE 
GO
