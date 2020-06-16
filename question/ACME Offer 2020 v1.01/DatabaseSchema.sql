/****** Object:  Table [dbo].[Country]    
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
	[CountryCode] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[Postcodes]    
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Postcodes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Pcode] [varchar](50) NULL,
	[Locality] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Comments] [varchar](50) NULL,
	[DeliveryOffice] [varchar](50) NULL,
	[PreSortIndicator] [varchar](50) NULL,
	[ParcelZone] [varchar](50) NULL,
	[BSPnumber] [varchar](50) NULL,
	[BSPname] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
 CONSTRAINT [PK_Postcodes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

