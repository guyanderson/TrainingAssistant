USE [master]
GO
/****** Object:  Database [TrainingHelper]    Script Date: 8/29/2017 1:15:05 PM ******/
CREATE DATABASE [TrainingHelper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TrainingHelper', FILENAME = N'C:\Users\epicodus\TrainingHelper.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TrainingHelper_log', FILENAME = N'C:\Users\epicodus\TrainingHelper_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/29/2017 1:15:05 PM ******/
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
/****** Object:  Table [dbo].[Areas]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[BayId] [int] NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bays]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bays](
	[BayId] [int] IDENTITY(1,1) NOT NULL,
	[AreaId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TargetTrained] [int] NOT NULL,
 CONSTRAINT [PK_Bays] PRIMARY KEY CLUSTERED 
(
	[BayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Certifications]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Certifications](
	[CertificationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[TargetTrained] [int] NOT NULL,
 CONSTRAINT [PK_Certifications] PRIMARY KEY CLUSTERED 
(
	[CertificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fab]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fab](
	[FabId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Fab] PRIMARY KEY CLUSTERED 
(
	[FabId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Operators]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operators](
	[OperatorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ShiftId] [int] NOT NULL,
 CONSTRAINT [PK_Operators] PRIMARY KEY CLUSTERED 
(
	[OperatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Shifts]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shifts](
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED 
(
	[ShiftId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tools]    Script Date: 8/29/2017 1:15:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tools](
	[ToolId] [int] IDENTITY(1,1) NOT NULL,
	[BayId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tools] PRIMARY KEY CLUSTERED 
(
	[ToolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170828194718_Initial', N'1.0.0-rtm-21431')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170829200932_FabObject', N'1.0.0-rtm-21431')
SET IDENTITY_INSERT [dbo].[Areas] ON 

INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (2, NULL, N'Photo')
INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (3, NULL, N'Plasma Etch')
INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (4, NULL, N'Wet Etch')
INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (5, NULL, N'Implant')
INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (6, NULL, N'Metals')
INSERT [dbo].[Areas] ([AreaId], [BayId], [Name]) VALUES (7, NULL, N'Diffusion')
SET IDENTITY_INSERT [dbo].[Areas] OFF
SET IDENTITY_INSERT [dbo].[Bays] ON 

INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (1, 2, N'Photo Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (2, 2, N'Photo Bay 2', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (3, 2, N'Photo Bay 3', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (6, 3, N'Plasma Etch Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (7, 3, N'Plasma Etch Bay 2', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (8, 4, N'Wet Etch Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (9, 4, N'Wet Etch Bay 2', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (10, 5, N'Implant Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (11, 5, N'Implant Bay 2', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (12, 6, N'Metals Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (13, 6, N'Metals Bay 2', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (14, 7, N'Diffusion Bay 1', 0)
INSERT [dbo].[Bays] ([BayId], [AreaId], [Name], [TargetTrained]) VALUES (15, 7, N'Diffusion Bay 2', 0)
SET IDENTITY_INSERT [dbo].[Bays] OFF
SET IDENTITY_INSERT [dbo].[Certifications] ON 

INSERT [dbo].[Certifications] ([CertificationId], [Name], [TargetTrained]) VALUES (2, N'Ultratech', 0)
SET IDENTITY_INSERT [dbo].[Certifications] OFF
SET IDENTITY_INSERT [dbo].[Operators] ON 

INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (2, N'Guy', 1)
INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (3, N'Bob', 2)
INSERT [dbo].[Operators] ([OperatorId], [Name], [ShiftId]) VALUES (6, N'Joe', 1)
SET IDENTITY_INSERT [dbo].[Operators] OFF
SET IDENTITY_INSERT [dbo].[Tools] ON 

INSERT [dbo].[Tools] ([ToolId], [BayId], [Name]) VALUES (1, 1, N'Photo Tool 1')
INSERT [dbo].[Tools] ([ToolId], [BayId], [Name]) VALUES (2, 2, N'Photo Tool 2')
INSERT [dbo].[Tools] ([ToolId], [BayId], [Name]) VALUES (3, 3, N'Photo Tool 3')
INSERT [dbo].[Tools] ([ToolId], [BayId], [Name]) VALUES (4, 6, N'Plasma Tool 1')
SET IDENTITY_INSERT [dbo].[Tools] OFF
/****** Object:  Index [IX_Areas_BayId]    Script Date: 8/29/2017 1:15:06 PM ******/
CREATE NONCLUSTERED INDEX [IX_Areas_BayId] ON [dbo].[Areas]
(
	[BayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bays] ADD  DEFAULT ((0)) FOR [TargetTrained]
GO
ALTER TABLE [dbo].[Certifications] ADD  DEFAULT ((0)) FOR [TargetTrained]
GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Bays_BayId] FOREIGN KEY([BayId])
REFERENCES [dbo].[Bays] ([BayId])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Bays_BayId]
GO
USE [master]
GO
ALTER DATABASE [TrainingHelper] SET  READ_WRITE 
GO
