
-- Install-Package Bricelam.EntityFrameworkCore.Pluralizer
-- Scaffold-DbContext "Server=.\sqlexpress;Database=MyDeliveryApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context "DataContext"


USE [QuoteCalculator]
GO
/****** Object:  Table [dbo].[BlackListedEmail]    Script Date: 17 Oct 2021 7:01:01 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackListedEmail](
	[BlackListedEmailId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_BlackListedEmail] PRIMARY KEY CLUSTERED 
(
	[BlackListedEmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlackListedMobile]    Script Date: 17 Oct 2021 7:01:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackListedMobile](
	[BlackListedMobileId] [int] IDENTITY(1,1) NOT NULL,
	[MobileNumber] [nvarchar](11) NOT NULL,
 CONSTRAINT [PK_BlackListedMobile] PRIMARY KEY CLUSTERED 
(
	[BlackListedMobileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 17 Oct 2021 7:01:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](5) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[Mobile] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[LoanId] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 17 Oct 2021 7:01:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[LoanId] [int] IDENTITY(1,1) NOT NULL,
	[AmountRequired] [money] NOT NULL,
	[TotalInterest] [money] NULL,
	[RepaymentAmount] [money] NOT NULL,
	[EstablishmentFee] [money] NOT NULL,
	[Frequency] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[LoanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 17 Oct 2021 7:01:03 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](10) NOT NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[HasInterest] [bit] NOT NULL,
	[Duration] [nvarchar](20) NULL,
	[FreeMonthInterest] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductDescription], [HasInterest], [Duration], [FreeMonthInterest]) VALUES (1, N'ProductA', N'the loan is interest-free', 0, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductDescription], [HasInterest], [Duration], [FreeMonthInterest]) VALUES (2, N'ProductB', N'the first 2 months are interest-free', 1, N'6 months', 2)
GO
INSERT [dbo].[Product] ([ProductId], [ProductName], [ProductDescription], [HasInterest], [Duration], [FreeMonthInterest]) VALUES (3, N'ProductC', N'no interest free', 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO

