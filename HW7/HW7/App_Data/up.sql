CREATE DATABASE [Logging]
GO

USE [Logging]
GO

CREATE TABLE [dbo].[RequestLog](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[DateInserted] [datetime] NOT NULL,
	[RequestUrl] [nvarchar](max) NOT NULL,
	[RequestType] [nvarchar](50) NOT NULL,
	[Word] [nvarchar](max) NULL,
	[IP] [nvarchar](50) NOT NULL,
	[Browser] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_RequestLog] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


