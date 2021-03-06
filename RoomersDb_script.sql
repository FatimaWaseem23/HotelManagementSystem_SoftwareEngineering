USE [master]
GO
/****** Object:  Database [RoomersDB]    Script Date: 10/26/2021 12:29:18 AM ******/
CREATE DATABASE [RoomersDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RoomersDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RoomersDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RoomersDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\RoomersDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RoomersDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RoomersDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RoomersDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RoomersDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RoomersDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RoomersDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RoomersDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RoomersDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RoomersDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RoomersDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RoomersDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RoomersDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RoomersDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RoomersDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RoomersDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RoomersDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RoomersDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RoomersDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RoomersDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RoomersDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RoomersDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RoomersDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RoomersDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RoomersDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RoomersDB] SET RECOVERY FULL 
GO
ALTER DATABASE [RoomersDB] SET  MULTI_USER 
GO
ALTER DATABASE [RoomersDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RoomersDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RoomersDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RoomersDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RoomersDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RoomersDB', N'ON'
GO
ALTER DATABASE [RoomersDB] SET QUERY_STORE = OFF
GO
USE [RoomersDB]
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
USE [RoomersDB]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[BookingDetailID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RoomID] [int] NULL,
	[Status] [nvarchar](100) NULL,
	[BookingByUserID] [int] NULL,
	[BookingDate] [datetime] NULL,
 CONSTRAINT [PK_BookingDetails] PRIMARY KEY CLUSTERED 
(
	[BookingDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nvarchar](50) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomServices]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomServices](
	[RoomServiceID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[ServiceID] [int] NULL,
 CONSTRAINT [PK_RoomServices] PRIMARY KEY CLUSTERED 
(
	[RoomServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserFullName] [varchar](200) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[Creation_date] [datetime] NOT NULL,
	[UserType] [nvarchar](20) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [UserFullName], [Email], [Password], [Status], [Creation_date], [UserType]) VALUES (1, N'superadmin', N'Super Admin', N'-', N'12345', N'Active', CAST(N'2021-10-24T20:50:13.063' AS DateTime), N'SuperAdmin')
INSERT [dbo].[Users] ([UserID], [UserName], [UserFullName], [Email], [Password], [Status], [Creation_date], [UserType]) VALUES (2, N'alpha.one', N'Alpha One', N'alpha@gmail.com', N'12345', N'Active', CAST(N'2021-10-25T20:45:20.450' AS DateTime), N'Customer')
INSERT [dbo].[Users] ([UserID], [UserName], [UserFullName], [Email], [Password], [Status], [Creation_date], [UserType]) VALUES (3, N'beta.two', N'Beta Two', N'beta@gmail.com', N'12345', N'Active', CAST(N'2021-10-26T00:22:16.583' AS DateTime), N'Receptioni')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  StoredProcedure [dbo].[AuthenticateUserCredentials]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AuthenticateUserCredentials]     
 @LoginID nvarchar(100),    
 @Password nvarchar(100)    
AS    
BEGIN    
    
 Select * From Users    
 Where UserName = @LoginID    
  And [Password] = @Password  
  And Status = 'Active'
    
END 
GO
/****** Object:  StoredProcedure [dbo].[Get_AllUser]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_AllUser]
AS    
BEGIN    
    
 Select * From Users
 where usertype != 'SuperAdmin';
    
END 
GO
/****** Object:  StoredProcedure [dbo].[Get_ListOfUsers]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[Get_ListOfUsers]   
AS  
BEGIN  
  
 Select * From Users;  
  
END  
GO
/****** Object:  StoredProcedure [dbo].[Insert_NewUser]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================      
-- Author:  <Author,,Name>      
-- Create date: <Create Date,,>      
-- Description: <Description,,>      
-- =============================================      
CREATE PROCEDURE [dbo].[Insert_NewUser]      
 @LoginID nvarchar(200)      
 ,@UserFullName nvarchar(100)      
 ,@Email nvarchar(100)      
 ,@Password nvarchar(50)
 ,@UserType nvarchar(10)      
 ,@LoggedInUser nvarchar(100)    
AS      
BEGIN      
      
 Declare @ifUserExist int = (Select Count(1) From Users Where UserName = @LoginID)      
      
 If(@ifUserExist = 0)      
 Begin      
   Insert Into Users      
   Select @LoginID,@UserFullName,@Email,@Password,'Active',GetDate(), @UserType      
      
   Select 'Added'      
      
   Execute Get_ListOfUsers      
 End      
 Else      
 Begin      
   Select 'AlreadyExist'      
 End      
      
      
END 
GO
/****** Object:  StoredProcedure [dbo].[Update_ExistingUser]    Script Date: 10/26/2021 12:29:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================          
-- Author:  <Author,,Name>          
-- Create date: <Create Date,,>          
-- Description: <Description,,>          
-- =============================================          
CREATE PROCEDURE [dbo].[Update_ExistingUser]          
 @UserID int          
 ,@UserFullName nvarchar(100)          
 ,@Email nvarchar(100)          
 ,@Password nvarchar(50) 
 ,@UserType nvarchar(10)    
 ,@LoggedInUser nvarchar(100)          
AS          
BEGIN          
      
   
If(@Password  = '')  
 Set @Password = (Select Top 1 Password From Users Where UserID = @UserID)  
       
Update Users    
Set UserFullName = @UserFullName,    
Email = @Email,    
Password = @Password, 
UserType = @UserType    
Where UserID = @UserID    
    
Select 'Updated'          
          
END 
GO
USE [master]
GO
ALTER DATABASE [RoomersDB] SET  READ_WRITE 
GO
