USE [podcast_me]
GO

/****** Object:  Table [dbo].[IdentityInformation]    Script Date: 31.03.2020 15:27:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[IdentityInformation](
	[ProfileId] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO


