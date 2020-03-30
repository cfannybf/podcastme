USE [podcast_me]
GO

/****** Object:  Table [dbo].[Profile]    Script Date: 30.03.2020 14:04:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Profile](
	[ProfileId] [nvarchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ProfilePhoto] [nvarchar](50) NULL,
	[Bio] [nvarchar](50) NULL,
	[JoinedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

