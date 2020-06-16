Use [ACME];

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


INSERT INTO dbo.Country (CountryName, CountryCode) Values('Australia', 'AU');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('New Zealand', 'NZ');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Antarctica', 'AQ');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Argentina', 'AR');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Brazil', 'BR');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Australia', 'AU');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('New Zeland', 'NZ');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Antarticia', 'AQ');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Argentina', 'AR');
INSERT INTO dbo.Country (CountryName, CountryCode) Values('Brazil', 'BR');

SET IDENTITY_INSERT dbo.Postcodes ON;

INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(50, 822, 'ACACIA HILLS', 'NT', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(3802, 2601, 'ACTON', 'ACT', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(5172, 2850, 'AARONS PASS', 'NSW', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(7795, 3737, 'ABBEYARD', 'VIC', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(10354, 4613, 'ABBEYWOOD', 'QLD', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(12392, 5159, 'ABERFOYLE PARK', 'SA', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(14504, 6280, 'ABBA RIVER', 'WA', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(16305, 7306, 'ACACIA HILLS', 'TAS', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(16361, 7315, 'ABBOTSHAM', 'TAS', '', '', '', '', '', '', 'Delivery Area');
INSERT INTO Postcodes (ID, Pcode, Locality, [State], Comments, DeliveryOffice, PreSortIndicator, ParcelZone, BSPnumber, BSPname, Category) Values(16389, 7320, 'ACTON', 'TAS', 'BURNIE', '', '', '', '', '', 'Delivery Area');

SET IDENTITY_INSERT dbo.Postcodes OFF;

Update Postcodes Set Comments = NULL Where Comments = '';
Update Postcodes Set DeliveryOffice = NULL Where DeliveryOffice = '';
Update Postcodes Set PreSortIndicator = NULL Where PreSortIndicator = '';
Update Postcodes Set ParcelZone = NULL Where ParcelZone = '';
Update Postcodes Set BSPnumber = NULL Where BSPnumber = '';
Update Postcodes Set BSPname = NULL Where BSPname = '';

SELECT * FROM dbo.Postcodes;
SELECT * FROM dbo.Country;