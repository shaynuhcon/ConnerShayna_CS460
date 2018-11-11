CREATE TABLE [dbo].[RequestLog](
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
	[DateInserted] [datetime] NOT NULL,
	[RequestUrl] [nvarchar](max) NOT NULL,
	[RequestType] [nvarchar](50) NOT NULL,
	[Word] [nvarchar](max) NULL,
	[IP] [nvarchar](50) NOT NULL,
	[Browser] [nvarchar](max) NOT NULL)
GO