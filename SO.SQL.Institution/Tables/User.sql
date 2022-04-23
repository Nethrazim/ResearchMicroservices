CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Role] INT NOT NULL,
	[SystemUserId] uniqueidentifier NOT NULL 
);
