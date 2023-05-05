USE [master]
GO
/****** Object:  Database [BeautyAndCosmetics_RM]    Script Date: 26/03/2022 20:38:58 ******/
CREATE DATABASE [BeautyAndCosmetics_RM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BeautyAndCosmetics', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BeautyAndCosmetics.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BeautyAndCosmetics_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BeautyAndCosmetics_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BeautyAndCosmetics_RM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ARITHABORT OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET RECOVERY FULL 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET  MULTI_USER 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BeautyAndCosmetics_RM', N'ON'
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET QUERY_STORE = OFF
GO
USE [BeautyAndCosmetics_RM]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingNumber] [int] IDENTITY(1,1) NOT NULL,
	[BookingCode]  AS ('BC'+right('00'+CONVERT([nvarchar](5),[BookingNumber]),(6))) PERSISTED,
	[BookingDate] [date] NULL,
	[RoomNo] [int] NULL,
	[CustomerNumber] [int] NULL,
	[SlotsNumber] [int] NULL,
	[ProductNumber] [int] NULL,
	[StaffNumber] [int] NULL,
	[BookingPrice] [nvarchar](20) NULL,
	[Treatment] [nvarchar](35) NULL,
	[Paid] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingProduct]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingProduct](
	[BookingNo] [int] NULL,
	[ProductNo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingSlots]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingSlots](
	[BookingNo] [int] NULL,
	[SlotsNo] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerNumber] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode]  AS ('C'+right('000'+CONVERT([varchar](10),[CustomerNumber]),(3))) PERSISTED,
	[CustomerForename] [nvarchar](25) NULL,
	[CustomerSurname] [nvarchar](25) NULL,
	[CustomerEmail] [nvarchar](35) NULL,
	[CustomerPhone] [nvarchar](11) NULL,
	[CustomerNameSurname]  AS (([CustomerForename]+' ')+[CustomerSurname]),
PRIMARY KEY CLUSTERED 
(
	[CustomerNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginDetail]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginDetail](
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductNumber] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode]  AS ('P'+right('00'+CONVERT([varchar](6),[ProductNumber]),(6))) PERSISTED,
	[ProductName] [nvarchar](25) NULL,
	[ProductPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomNo] [int] IDENTITY(1,1) NOT NULL,
	[RoomCode]  AS ('R'+right('00'+CONVERT([varchar](5),[RoomNo]),(6))) PERSISTED,
	[RoomDescription] [nvarchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slots]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slots](
	[SlotsNumber] [int] IDENTITY(1,1) NOT NULL,
	[SlotsCode]  AS ('S'+right('00'+CONVERT([varchar](6),[SlotsNumber]),(7))) PERSISTED,
	[SlotTime] [nvarchar](25) NULL,
	[AvailableSlots] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SlotsNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffNumber] [int] IDENTITY(1,1) NOT NULL,
	[StaffCode]  AS ('C'+right('00'+CONVERT([varchar](5),[StaffNumber]),(6))) PERSISTED,
	[StaffForename] [nvarchar](25) NULL,
	[StaffSurname] [nvarchar](25) NULL,
	[StaffContract] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[StaffNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (33, CAST(N'2021-12-24' AS Date), 3, 1, 17, 1, 4, N'£20', N'Laser Hair Removal', N'No')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (36, CAST(N'2021-12-25' AS Date), 4, 1, 1, NULL, 3, N'£25', N'Dip Powder', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (37, CAST(N'2022-01-19' AS Date), 2, 1, 12, NULL, 1, N'£30', N'Make Up', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (42, CAST(N'2022-09-24' AS Date), 3, 1, 1, NULL, 3, N'£50', N'Lashlift and Tint', N'No')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (44, CAST(N'2022-03-05' AS Date), 3, 1, 1, NULL, 1, N'£20', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (46, CAST(N'2022-03-26' AS Date), 4, 1, 8, NULL, 2, N'£10', N'Basic Polish', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (52, CAST(N'2022-02-24' AS Date), 3, 7, 5, NULL, NULL, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (53, CAST(N'2022-02-19' AS Date), 1, 1, 1, NULL, NULL, N'£50', N'Laser Hair Removal', N'No')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (55, CAST(N'2022-01-22' AS Date), 1, 1, 12, NULL, NULL, N'15', N'Eyebrows', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (56, CAST(N'2022-02-12' AS Date), 3, 1, 13, NULL, NULL, N'£30', N'Make Up', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (57, CAST(N'2022-02-04' AS Date), 3, 11, 3, NULL, NULL, N'£25', N'Tan', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (59, CAST(N'2022-03-24' AS Date), 1, 1, 19, NULL, NULL, N'£30', N'Make Up', N'No')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (60, CAST(N'2022-03-25' AS Date), 2, 11, 18, NULL, 1, N'£25', N'Make Up', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (61, CAST(N'2022-03-26' AS Date), 2, 6, 10, NULL, 1, N'£50', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (63, CAST(N'2022-03-19' AS Date), 2, 11, 4, NULL, 4, N'£25', N'Tan', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (64, CAST(N'2022-03-18' AS Date), 3, 7, 7, NULL, 1, N'£25', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (65, CAST(N'2022-03-18' AS Date), 1, 6, 5, NULL, 4, N'£25', N'Tan', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (66, CAST(N'2022-03-11' AS Date), 3, 1, 19, NULL, 1, N'£50', N'Laser Hair Removal', N'No')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (1058, CAST(N'2022-03-19' AS Date), 1, 7, 5, NULL, 3, N'£25', N'Tan', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (1059, CAST(N'2022-03-05' AS Date), 2, 7, 5, NULL, 3, N'£30', N'Make Up', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (1060, CAST(N'2022-03-25' AS Date), 2, 1, 1, NULL, 1, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (1061, CAST(N'2022-03-11' AS Date), 2, 1, 1, NULL, 1, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (1062, CAST(N'2022-03-10' AS Date), 1, 6, 1, NULL, 1, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (2060, CAST(N'2022-03-12' AS Date), 1, 1, 21, NULL, 3, N'£50', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (2061, CAST(N'2022-03-26' AS Date), 2, 6, 4, NULL, 2, N'£30', N'Make Up', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (2062, CAST(N'2022-03-31' AS Date), 2, 6, 3, NULL, 3, N'£25', N'Tan', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (2063, CAST(N'2022-03-31' AS Date), 4, 1, 1, NULL, 2, N'£10', N'Basic Polish', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (3061, CAST(N'2022-03-15' AS Date), 2, 6, 6, NULL, 3, N'£50', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (3062, CAST(N'2022-03-15' AS Date), 2, 11, 4, NULL, 2, N'£15', N'Eyebrows', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (3063, CAST(N'2022-03-19' AS Date), 2, 6, 7, NULL, 2, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (4064, CAST(N'2022-03-20' AS Date), 2, 1, 3, NULL, 1, N'£10', N'Lashlift and Tint', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (6063, CAST(N'2022-03-25' AS Date), 1, 1, 21, NULL, 1, N'£50', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (6064, CAST(N'2022-03-20' AS Date), 3, 1, 1, NULL, 3, N'£30', N'Laser Hair Removal', N'Yes')
INSERT [dbo].[Booking] ([BookingNumber], [BookingDate], [RoomNo], [CustomerNumber], [SlotsNumber], [ProductNumber], [StaffNumber], [BookingPrice], [Treatment], [Paid]) VALUES (6065, CAST(N'2022-03-26' AS Date), 2, 1, 2, NULL, 3, N'£30', N'Make Up', N'Yes')
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerNumber], [CustomerForename], [CustomerSurname], [CustomerEmail], [CustomerPhone]) VALUES (1, N'Ryan', N'Murray', N'RyanJM1@sky.com', N'11122212343')
INSERT [dbo].[Customer] ([CustomerNumber], [CustomerForename], [CustomerSurname], [CustomerEmail], [CustomerPhone]) VALUES (6, N'Jenshue', N'Genius', N'ryanj@sky.com', N'11111111111')
INSERT [dbo].[Customer] ([CustomerNumber], [CustomerForename], [CustomerSurname], [CustomerEmail], [CustomerPhone]) VALUES (7, N'Shanice', N'Ferrerah', N'ShaniceF@hotmail.com', N'11111111111')
INSERT [dbo].[Customer] ([CustomerNumber], [CustomerForename], [CustomerSurname], [CustomerEmail], [CustomerPhone]) VALUES (11, N'Jermain', N'Wanis', N'JW@sky.com', N'11111111111')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[LoginDetail] ([Username], [Password]) VALUES (N'Username1212', N'Password1212')
INSERT [dbo].[LoginDetail] ([Username], [Password]) VALUES (N'Username1', N'Password1')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductNumber], [ProductName], [ProductPrice]) VALUES (1, N'Hair Gel', 13)
INSERT [dbo].[Product] ([ProductNumber], [ProductName], [ProductPrice]) VALUES (3, N'Shampoo', 11)
INSERT [dbo].[Product] ([ProductNumber], [ProductName], [ProductPrice]) VALUES (5, N'Make Up', 12.99)
INSERT [dbo].[Product] ([ProductNumber], [ProductName], [ProductPrice]) VALUES (6, N'Shampoo', 12)
INSERT [dbo].[Product] ([ProductNumber], [ProductName], [ProductPrice]) VALUES (7, N'Make Up', 20.99)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomNo], [RoomDescription]) VALUES (1, N'Treatment Room 1')
INSERT [dbo].[Room] ([RoomNo], [RoomDescription]) VALUES (2, N'Treatment Room 2')
INSERT [dbo].[Room] ([RoomNo], [RoomDescription]) VALUES (3, N'Treatment Room 3')
INSERT [dbo].[Room] ([RoomNo], [RoomDescription]) VALUES (4, N'Nail Bar')
SET IDENTITY_INSERT [dbo].[Room] OFF
GO
SET IDENTITY_INSERT [dbo].[Slots] ON 

INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (1, N'9:00 - 10:00', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (2, N'9:30 - 10:30', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (3, N'10:00 - 11:00', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (4, N'10:30 - 11:30', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (5, N'11:00 - 12:00', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (6, N'12:30 - 13:30', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (7, N'13:00 - 14:00', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (8, N'13:30 - 14:30', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (9, N'14:00 - 15:00', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (10, N'14:30 - 15:30', 4)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (11, N'15:00 - 16:00', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (12, N'15:30 - 16:30', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (13, N'16:00 - 17:00', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (14, N'16:30 - 17:30', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (15, N'17:00 - 18:00', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (16, N'17:30 - 18:30', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (17, N'18:00 - 19:00', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (18, N'18:30 - 19:30', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (19, N'19:00 - 20:00', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (20, N'19:30 - 20:30', 2)
INSERT [dbo].[Slots] ([SlotsNumber], [SlotTime], [AvailableSlots]) VALUES (21, N'20:00 - 21:00', 2)
SET IDENTITY_INSERT [dbo].[Slots] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([StaffNumber], [StaffForename], [StaffSurname], [StaffContract]) VALUES (1, N'Ryan', N'Murray', N'FULL TIME')
INSERT [dbo].[Staff] ([StaffNumber], [StaffForename], [StaffSurname], [StaffContract]) VALUES (2, N'James', N'Eto', N'PART TIME')
INSERT [dbo].[Staff] ([StaffNumber], [StaffForename], [StaffSurname], [StaffContract]) VALUES (3, N'Anderisa', N'Manderson', N'PART TIME')
INSERT [dbo].[Staff] ([StaffNumber], [StaffForename], [StaffSurname], [StaffContract]) VALUES (4, N'Janelle', N'Hertines', N'FULL TIME')
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustomerNumber])
REFERENCES [dbo].[Customer] ([CustomerNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([CustomerNumber])
REFERENCES [dbo].[Customer] ([CustomerNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([ProductNumber])
REFERENCES [dbo].[Product] ([ProductNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([ProductNumber])
REFERENCES [dbo].[Product] ([ProductNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([RoomNo])
REFERENCES [dbo].[Room] ([RoomNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([RoomNo])
REFERENCES [dbo].[Room] ([RoomNo])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([SlotsNumber])
REFERENCES [dbo].[Slots] ([SlotsNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([SlotsNumber])
REFERENCES [dbo].[Slots] ([SlotsNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNumber])
REFERENCES [dbo].[Staff] ([StaffNumber])
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD FOREIGN KEY([StaffNumber])
REFERENCES [dbo].[Staff] ([StaffNumber])
GO
ALTER TABLE [dbo].[BookingProduct]  WITH CHECK ADD FOREIGN KEY([BookingNo])
REFERENCES [dbo].[Booking] ([BookingNumber])
GO
ALTER TABLE [dbo].[BookingProduct]  WITH CHECK ADD FOREIGN KEY([ProductNo])
REFERENCES [dbo].[Product] ([ProductNumber])
GO
ALTER TABLE [dbo].[BookingSlots]  WITH CHECK ADD FOREIGN KEY([BookingNo])
REFERENCES [dbo].[Booking] ([BookingNumber])
GO
ALTER TABLE [dbo].[BookingSlots]  WITH CHECK ADD FOREIGN KEY([SlotsNo])
REFERENCES [dbo].[Slots] ([SlotsNumber])
GO
/****** Object:  StoredProcedure [dbo].[AddBookingSlot]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBookingSlot] @BookingDate date, @SlotsNumber int, @CustomerNumber int, @RoomNumber int, @BookingPrice nvarchar (35), @Treatment nvarchar (35), @Paid nvarchar (5), @staffNo int
AS
INSERT INTO Booking(BookingDate,SlotsNumber,CustomerNumber, RoomNo, BookingPrice,StaffNumber, Treatment, Paid)
VALUES (@BookingDate, @SlotsNumber, @CustomerNumber, @RoomNumber, @BookingPrice,@staffNo, @Treatment, @Paid );
GO
/****** Object:  StoredProcedure [dbo].[AddCustomerBeauty]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCustomerBeauty] @CustomerForename nvarchar (25), @CustomerSurname nvarchar(25),@CustomerEmail nvarchar(35),@CustomerPhone nvarchar(11)
AS
INSERT INTO Customer
VALUES (@CustomerForename,@CustomerSurname,@CustomerEmail,@CustomerPhone);
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddProduct] @ProductName nvarchar (25), @ProductPrice nvarchar(25)
AS
INSERT INTO Product
VALUES (@ProductName,@ProductPrice);
GO
/****** Object:  StoredProcedure [dbo].[AddRoom]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddRoom] @RoomDescription nvarchar (25)
AS
INSERT INTO Room
VALUES (@RoomDescription);
GO
/****** Object:  StoredProcedure [dbo].[AddSlots]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddSlots] @BookingSlot nvarchar (25)
AS
INSERT INTO Slots
VALUES (@BookingSlot);
GO
/****** Object:  StoredProcedure [dbo].[AddStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddStaff] @StaffForename nvarchar (25), @StaffSurname nvarchar(25),@StaffContract nvarchar(10)
AS
INSERT INTO Staff
VALUES (@StaffForename,@StaffSurname,@StaffContract);
GO
/****** Object:  StoredProcedure [dbo].[BookingShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BookingShow]
AS
SELECT Customer.CustomerCode,customer.CustomerForename,Customer.CustomerSurname,Booking.BookingDate,Slots.SlotTime,Room.RoomDescription FROM Booking
INNER JOIN Customer ON Booking.CustomerNumber = Customer.CustomerNumber
INNER JOIN Slots ON Booking.SlotsNumber = Slots.SlotsNumber
INNER JOIN Room ON Booking.RoomNo = Room.RoomNo


GO
/****** Object:  StoredProcedure [dbo].[bookingShow1]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bookingShow1]
as
SELECT Booking.BookingCode,Booking.BookingDate, Customer.CustomerCode, Customer.CustomerForename,CustomerSurname, Staff.StaffSurname, SlotsCode,Slots.SlotTime,Room.RoomDescription, Booking.Treatment, Booking.Paid
from Booking
INNER JOIN Slots ON  Booking.SlotsNumber = Slots.SlotsNumber
INNER JOIN Customer ON Booking.CustomerNumber = Customer.CustomerNumber
INNER JOIN Staff ON Booking.StaffNumber = Staff.StaffNumber
INNER JOIN Room ON Booking.RoomNo = Room.RoomNo;

 
GO
/****** Object:  StoredProcedure [dbo].[checkCustomer]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[checkCustomer] @bd date, @s int
as
SELECT Booking.CustomerNumber
FROM Booking
WHERE @bd = BookingDate and SlotsNumber=@s;
GO
/****** Object:  StoredProcedure [dbo].[CheckingStaffBooked]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckingStaffBooked] @BookingDate Date, @SlotsNumber int
AS
SELECT StaffNumber 
FROM Booking
WHERE BookingDate = @BookingDate And SlotsNumber = @SlotsNumber
GO
/****** Object:  StoredProcedure [dbo].[checkStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[checkStaff] @bd date, @s int
as
SELECT Booking.StaffNumber, Staff.StaffForename
FROM Booking
INNER JOIN Staff ON Booking.StaffNumber=Staff.StaffNumber
WHERE @bd = BookingDate and SlotsNumber=@s;
GO
/****** Object:  StoredProcedure [dbo].[checkStaffNext]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[checkStaffNext] @d int
AS
SELECT StaffNumber, StaffForename 
FROM Staff
WHERE StaffNumber != @d 
GO
/****** Object:  StoredProcedure [dbo].[CustomerShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerShow]
AS
SELECT CustomerCode,CustomerForename,CustomerSurname,CustomerEmail,CustomerPhone FROM Customer
GO
/****** Object:  StoredProcedure [dbo].[CustomersNotPaid]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomersNotPaid]
AS
SELECT Booking.BookingCode, CustomerNameSurname, Booking.Treatment, Booking.BookingDate
FROM Booking
INNER JOIN Customer on Booking.CustomerNumber = Customer.CustomerNumber
WHERE Booking.Paid = 'No'
GO
/****** Object:  StoredProcedure [dbo].[DateGreater]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DateGreater]
AS
SELECT BookingDate
FROM Booking 
WHERE BookingDate >= getdate() 
AND BookingDate <= dateadd(day, 1000, getdate())
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllBooking]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAllBooking] @CustomerNumber int
AS
DELETE FROM Booking
WHERE CustomerNumber = (@CustomerNumber)
GO
/****** Object:  StoredProcedure [dbo].[DeleteBooking]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBooking] @BookingCode nvarchar(10)
AS
DELETE FROM Booking
WHERE BookingCode = @BookingCode
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer3]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCustomer3] @CustomerCode nvarchar(6)
AS
DELETE FROM Customer
WHERE CustomerCode = @CustomerCode
GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteProduct] @ProductCode nvarchar(10)
AS
DELETE FROM Product
WHERE ProductCode = @ProductCode
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoom]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRoom] @RoomCode nvarchar(6)
AS
DELETE FROM Room
WHERE RoomCode = @RoomCode
GO
/****** Object:  StoredProcedure [dbo].[DeleteSlots]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSlots] @SlotsCode nvarchar(10)
AS
DELETE FROM Slots
WHERE SlotsCode = @SlotsCode
GO
/****** Object:  StoredProcedure [dbo].[DeleteStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStaff] @StaffCode nvarchar(6)
AS
DELETE FROM Staff
WHERE StaffCode = @StaffCode
GO
/****** Object:  StoredProcedure [dbo].[FIND]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FIND] @s nvarchar null
AS
SELECT Customer.CustomerSurname, Customer.CustomerCode
FROM Customer
WHERE CustomerForename = @s
GO
/****** Object:  StoredProcedure [dbo].[FullTimeStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullTimeStaff]
AS
SELECT StaffSurname
FROM STAFF
WHERE StaffContract = 'Full time'
GO
/****** Object:  StoredProcedure [dbo].[GetSlotTime]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSlotTime] @time nvarchar(25)
as
SELECT SlotsNumber
FROM Slots
where @time = SlotTime
GO
/****** Object:  StoredProcedure [dbo].[GetStaffNumber]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetStaffNumber] @Staff nvarchar (25)
AS
SELECT StaffNumber
FROM Staff 
WHERE  @Staff = StaffSurname
GO
/****** Object:  StoredProcedure [dbo].[gettingBooking]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gettingBooking] @S date
as
select SlotsNumber from Booking where BookingDate = @S;
GO
/****** Object:  StoredProcedure [dbo].[gettingRoomDescription]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[gettingRoomDescription] 
as
select RoomNo from Room 
GO
/****** Object:  StoredProcedure [dbo].[LoadPartTimeStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LoadPartTimeStaff]
AS
SELECT StaffForename 
FROM Staff
WHERE StaffContract = ('FULL TIME')
GO
/****** Object:  StoredProcedure [dbo].[LOGIN]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGIN]
AS(
SELECT * FROM LoginDetail)
GO
/****** Object:  StoredProcedure [dbo].[PartTimeStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PartTimeStaff]
AS
SELECT STaffSurname
FROM STAFF
WHERE StaffContract = 'Part time'
GO
/****** Object:  StoredProcedure [dbo].[ProductShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProductShow] 
AS
SELECT ProductCode,ProductName,ProductPrice FROM Product
GO
/****** Object:  StoredProcedure [dbo].[RoomShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoomShow]
AS
SELECT RoomCode,RoomDescription FROM Room
GO
/****** Object:  StoredProcedure [dbo].[RptCustomersNotPaid]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RptCustomersNotPaid]
AS
SELECT  CustomerNameSurname, Booking.Treatment, Booking.BookingDate, Slots.SlotTime, datediff(day, Booking.BookingDate, GETDATE()) AS DaysOverdue
FROM Booking
INNER JOIN Customer on Booking.CustomerNumber = Customer.CustomerNumber
INNER JOIN Slots on Booking.SlotsNumber = Slots.SlotsNumber
WHERE Booking.Paid = 'No'
GO
/****** Object:  StoredProcedure [dbo].[rptNextWeek]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptNextWeek]
AS
SELECT Customer.CustomerNameSurname,Booking.BookingDate, Slots.SlotTime, Booking.Treatment
FROM Booking
INNER JOIN Customer on Booking.CustomerNumber = Customer.CustomerNumber
INNER JOIN Slots on Booking.SlotsNumber = Slots.SlotsNumber
WHERE datediff(day, Booking.BookingDate, GETDATE()) <=7
GO
/****** Object:  StoredProcedure [dbo].[rptTotalBookingCustomer]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[rptTotalBookingCustomer]
AS
SELECT Customer.CustomerNameSurname, Count(Treatment) AS 'TotalBookingsfromCustomer'
FROM Booking
INNER JOIN CUSTOMER ON BOOKING.CustomerNumber = Customer.CustomerNumber
GROUP BY Customer.CustomerNameSurname
GO
/****** Object:  StoredProcedure [dbo].[SelectCustomerCode]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCustomerCode] @CustomerNameSurname   NVARCHAR(55)
AS
SELECT Customer.CustomerNumber 
FROM Customer
WHERE CustomerNameSurname = (@CustomerNameSurname)
GO
/****** Object:  StoredProcedure [dbo].[SelectCustomerNumber]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCustomerNumber] @CustomerCode  VARCHAR(4)
AS
SELECT CustomerNumber 
FROM Customer
WHERE CustomerCode = (@CustomerCode)
GO
/****** Object:  StoredProcedure [dbo].[SelectRoomCode]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectRoomCode] @RoomCode   NVARCHAR(55)
AS
SELECT Room.RoomNo 
FROM Room
WHERE RoomDescription = (@RoomCode)
GO
/****** Object:  StoredProcedure [dbo].[SelectStaffName]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectStaffName] @StaffNumber int
AS
SELECT Staff.StaffForename 
FROM Staff
WHERE StaffNumber = (@StaffNumber)
GO
/****** Object:  StoredProcedure [dbo].[SelectTime]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectTime] (@bd date)
AS
SELECT Slots.SlotTime
FROM Booking 
INNER JOIN Slots on Booking.SlotsNumber = Slots.SlotsNumber
WHERE BookingDate = @bd
GO
/****** Object:  StoredProcedure [dbo].[ShowingNameSurname]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowingNameSurname]
AS
SELECT CustomerForename, CustomerSurname
FROM Customer
GO
/****** Object:  StoredProcedure [dbo].[ShowStaffThatsAvailable]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ShowStaffThatsAvailable] @a int
AS
SELECT StaffForename 
FROM Staff
EXCEPT
SELECT StaffForename
FROM Staff
WHERE StaffNumber = @a
GO
/****** Object:  StoredProcedure [dbo].[SlotsShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SlotsShow]
AS
SELECT SlotsCode,SlotTime FROM Slots
GO
/****** Object:  StoredProcedure [dbo].[StaffShow]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StaffShow] 
AS
SELECT StaffCode,StaffForename,StaffSurname,StaffContract FROM Staff
GO
/****** Object:  StoredProcedure [dbo].[TESTING]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TESTING] @A int
AS
SELECT StaffForename FROM Staff
WHERE StaffNumber != @A 
GO
/****** Object:  StoredProcedure [dbo].[UpdateBooking]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBooking] @BD Date, @SN int, @BC nvarchar(15), @BT nvarchar(25), @RN int, @STN int
AS
UPDATE Booking SET BookingDate = @BD, SlotsNumber = @SN, Treatment = @BT, RoomNo = @RN, StaffNumber = @STN
WHERE BookingCode = @BC
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer] @SF VARCHAR(30), @SS VARCHAR (30), @SE NVARCHAR(50), @SP nvarchar(11),@SN nvarchar(6)
AS
UPDATE Customer SET CustomerForename = @SF, CustomerSurname = @SS, CustomerEmail = @SE, CustomerPhone = @SP
WHERE CustomerCode = @SN
GO
/****** Object:  StoredProcedure [dbo].[UpdatePaying]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePaying] @BC nvarchar(15), @P nvarchar (3)
AS
UPDATE Booking SET Paid = @P
WHERE BookingCode = @BC
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct] @PN VARCHAR(30), @PC VARCHAR (30),@SN nvarchar(6)
AS
UPDATE Product SET ProductName = @PN, ProductPrice = @PC
WHERE ProductCode = @SN
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoom]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateRoom] @RD VARCHAR(30), @RC varchar(6)
AS
UPDATE Room SET RoomDescription = @RD
WHERE RoomCode = @RC
GO
/****** Object:  StoredProcedure [dbo].[UpdateSlots]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSlots] @BS VARCHAR(30),@SN nvarchar(6)
AS
UPDATE Slots SET BookingSlot = @BS
WHERE SlotsCode = @SN
GO
/****** Object:  StoredProcedure [dbo].[UpdateStaff]    Script Date: 26/03/2022 20:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateStaff] @SF VARCHAR(30), @SS VARCHAR (30), @SC NVARCHAR(10), @SN nvarchar (6)
AS
UPDATE Staff SET StaffForename = @SF, StaffSurname = @SS, StaffContract = @SC
WHERE StaffCode = @SN
GO
USE [master]
GO
ALTER DATABASE [BeautyAndCosmetics_RM] SET  READ_WRITE 
GO
