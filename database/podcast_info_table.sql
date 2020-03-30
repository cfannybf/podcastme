USE [podcast_me]
GO

/****** Object:  Table [dbo].[PodcastInfo]    Script Date: 30.03.2020 14:03:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PodcastInfo](
	[PodcastId] [nvarchar](36) NOT NULL,
	[PodcastName] [nvarchar](50) NOT NULL,
	[PodcastAuthor] [nvarchar](50) NOT NULL,
	[UploadedOn] [datetime] NOT NULL,
	[Length] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PodcastInfo] PRIMARY KEY CLUSTERED 
(
	[PodcastId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

