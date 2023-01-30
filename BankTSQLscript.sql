USE [master]
GO
/****** Object:  Database [BankApplication]    Script Date: 31/01/2023 00:02:31 ******/
CREATE DATABASE [BankApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankApplication', FILENAME = N'C:\Users\Jacob\BankApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankApplication_log', FILENAME = N'C:\Users\Jacob\BankApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BankApplication] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BankApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BankApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BankApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BankApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BankApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [BankApplication] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BankApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BankApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BankApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BankApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BankApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BankApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BankApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BankApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BankApplication] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BankApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BankApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BankApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BankApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BankApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BankApplication] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BankApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BankApplication] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BankApplication] SET  MULTI_USER 
GO
ALTER DATABASE [BankApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BankApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BankApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BankApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BankApplication] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BankApplication] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BankApplication] SET QUERY_STORE = OFF
GO
USE [BankApplication]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 31/01/2023 00:02:31 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[Discriminator] [nvarchar](max) NOT NULL,
	[IDnumber] [nvarchar](10) NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[BirthDate] [datetime2](7) NULL,
	[Phone] [nvarchar](max) NULL,
	[City] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Street] [nvarchar](max) NULL,
	[ApartmentNumber] [nvarchar](10) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DollarAccountHistory]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DollarAccountHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[BeneficiaryAccount] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[BeneficiaryName] [nvarchar](max) NOT NULL,
	[DollarAccountFK] [nvarchar](450) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[FromAccount] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DollarAccountHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DollarAccounts]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DollarAccounts](
	[AccountNumber] [nvarchar](450) NOT NULL,
	[Funds] [float] NOT NULL,
	[ClientFK] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_DollarAccounts] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EuroAccountHistory]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EuroAccountHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[BeneficiaryName] [nvarchar](max) NOT NULL,
	[BeneficiaryAccount] [nvarchar](max) NOT NULL,
	[EuroAccountFK] [nvarchar](450) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[FromAccount] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_EuroAccountHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EuroAccounts]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EuroAccounts](
	[AccountNumber] [nvarchar](450) NOT NULL,
	[Funds] [float] NOT NULL,
	[ClientFK] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_EuroAccounts] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanApplications]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanApplications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Currency] [int] NOT NULL,
	[MonthsToPayOff] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[IDnumber] [nvarchar](max) NOT NULL,
	[ClientFK] [nvarchar](450) NOT NULL,
	[EmploymentType] [nvarchar](max) NOT NULL,
	[MonthlyIncome] [float] NOT NULL,
	[Status] [char](10) NOT NULL,
 CONSTRAINT [PK_LoanApplications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PoundAccountHistory]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoundAccountHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[BeneficiaryAccount] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[BeneficiaryName] [nvarchar](max) NOT NULL,
	[PoundAccountFK] [nvarchar](450) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[FromAccount] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PoundAccountHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PoundAccounts]    Script Date: 31/01/2023 00:02:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PoundAccounts](
	[AccountNumber] [nvarchar](450) NOT NULL,
	[Funds] [float] NOT NULL,
	[ClientFK] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_PoundAccounts] PRIMARY KEY CLUSTERED 
(
	[AccountNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 31/01/2023 00:02:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 31/01/2023 00:02:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DollarAccountHistory_DollarAccountFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_DollarAccountHistory_DollarAccountFK] ON [dbo].[DollarAccountHistory]
(
	[DollarAccountFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DollarAccounts_ClientFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DollarAccounts_ClientFK] ON [dbo].[DollarAccounts]
(
	[ClientFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EuroAccountHistory_EuroAccountFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_EuroAccountHistory_EuroAccountFK] ON [dbo].[EuroAccountHistory]
(
	[EuroAccountFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_EuroAccounts_ClientFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_EuroAccounts_ClientFK] ON [dbo].[EuroAccounts]
(
	[ClientFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_LoanApplications_ClientFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_LoanApplications_ClientFK] ON [dbo].[LoanApplications]
(
	[ClientFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PoundAccountHistory_PoundAccountFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE NONCLUSTERED INDEX [IX_PoundAccountHistory_PoundAccountFK] ON [dbo].[PoundAccountHistory]
(
	[PoundAccountFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_PoundAccounts_ClientFK]    Script Date: 31/01/2023 00:02:31 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PoundAccounts_ClientFK] ON [dbo].[PoundAccounts]
(
	[ClientFK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DollarAccountHistory] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[DollarAccountHistory] ADD  DEFAULT (N'') FOR [FromAccount]
GO
ALTER TABLE [dbo].[EuroAccountHistory] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[EuroAccountHistory] ADD  DEFAULT (N'') FOR [FromAccount]
GO
ALTER TABLE [dbo].[LoanApplications] ADD  DEFAULT (N'') FOR [EmploymentType]
GO
ALTER TABLE [dbo].[LoanApplications] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [MonthlyIncome]
GO
ALTER TABLE [dbo].[LoanApplications] ADD  DEFAULT ('') FOR [Status]
GO
ALTER TABLE [dbo].[PoundAccountHistory] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Date]
GO
ALTER TABLE [dbo].[PoundAccountHistory] ADD  DEFAULT (N'') FOR [FromAccount]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DollarAccountHistory]  WITH CHECK ADD  CONSTRAINT [FK_DollarAccountHistory_DollarAccounts_DollarAccountFK] FOREIGN KEY([DollarAccountFK])
REFERENCES [dbo].[DollarAccounts] ([AccountNumber])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DollarAccountHistory] CHECK CONSTRAINT [FK_DollarAccountHistory_DollarAccounts_DollarAccountFK]
GO
ALTER TABLE [dbo].[DollarAccounts]  WITH CHECK ADD  CONSTRAINT [FK_DollarAccounts_AspNetUsers_ClientFK] FOREIGN KEY([ClientFK])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[DollarAccounts] CHECK CONSTRAINT [FK_DollarAccounts_AspNetUsers_ClientFK]
GO
ALTER TABLE [dbo].[EuroAccountHistory]  WITH CHECK ADD  CONSTRAINT [FK_EuroAccountHistory_EuroAccounts_EuroAccountFK] FOREIGN KEY([EuroAccountFK])
REFERENCES [dbo].[EuroAccounts] ([AccountNumber])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EuroAccountHistory] CHECK CONSTRAINT [FK_EuroAccountHistory_EuroAccounts_EuroAccountFK]
GO
ALTER TABLE [dbo].[EuroAccounts]  WITH CHECK ADD  CONSTRAINT [FK_EuroAccounts_AspNetUsers_ClientFK] FOREIGN KEY([ClientFK])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[EuroAccounts] CHECK CONSTRAINT [FK_EuroAccounts_AspNetUsers_ClientFK]
GO
ALTER TABLE [dbo].[LoanApplications]  WITH CHECK ADD  CONSTRAINT [FK_LoanApplications_AspNetUsers_ClientFK] FOREIGN KEY([ClientFK])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[LoanApplications] CHECK CONSTRAINT [FK_LoanApplications_AspNetUsers_ClientFK]
GO
ALTER TABLE [dbo].[PoundAccountHistory]  WITH CHECK ADD  CONSTRAINT [FK_PoundAccountHistory_PoundAccounts_PoundAccountFK] FOREIGN KEY([PoundAccountFK])
REFERENCES [dbo].[PoundAccounts] ([AccountNumber])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PoundAccountHistory] CHECK CONSTRAINT [FK_PoundAccountHistory_PoundAccounts_PoundAccountFK]
GO
ALTER TABLE [dbo].[PoundAccounts]  WITH CHECK ADD  CONSTRAINT [FK_PoundAccounts_AspNetUsers_ClientFK] FOREIGN KEY([ClientFK])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[PoundAccounts] CHECK CONSTRAINT [FK_PoundAccounts_AspNetUsers_ClientFK]
GO
USE [master]
GO
ALTER DATABASE [BankApplication] SET  READ_WRITE 
GO
