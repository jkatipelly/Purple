USE [Purple]
GO

/****** Object:  Table [dbo].[tblOffer]    Script Date: 22/04/2016 02:20:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblOffer](
	[OfferID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[BuyerID] [int] NOT NULL,
	[SellerID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
 CONSTRAINT [PK_tblOffer] PRIMARY KEY CLUSTERED 
(
	[OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tblOffer]  WITH CHECK ADD  CONSTRAINT [FK_tblOffer_tblProperties] FOREIGN KEY([PropertyID])
REFERENCES [dbo].[tblProperties] ([PropertyID])
GO

ALTER TABLE [dbo].[tblOffer] CHECK CONSTRAINT [FK_tblOffer_tblProperties]
GO

ALTER TABLE [dbo].[tblOffer]  WITH CHECK ADD  CONSTRAINT [FK_tblOffer_tblStatusLookup] FOREIGN KEY([StatusID])
REFERENCES [dbo].[tblStatusLookup] ([StatusID])
GO

ALTER TABLE [dbo].[tblOffer] CHECK CONSTRAINT [FK_tblOffer_tblStatusLookup]
GO

ALTER TABLE [dbo].[tblOffer]  WITH CHECK ADD  CONSTRAINT [FK_tblOfferBuyyerID_tblUsersUserID] FOREIGN KEY([BuyerID])
REFERENCES [dbo].[tblUsers] ([UserID])
GO

ALTER TABLE [dbo].[tblOffer] CHECK CONSTRAINT [FK_tblOfferBuyyerID_tblUsersUserID]
GO

ALTER TABLE [dbo].[tblOffer]  WITH CHECK ADD  CONSTRAINT [FK_tblOfferSellerID_tblUsersUserID] FOREIGN KEY([SellerID])
REFERENCES [dbo].[tblUsers] ([UserID])
GO

ALTER TABLE [dbo].[tblOffer] CHECK CONSTRAINT [FK_tblOfferSellerID_tblUsersUserID]
GO


