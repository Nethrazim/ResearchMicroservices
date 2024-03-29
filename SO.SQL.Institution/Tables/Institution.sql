﻿CREATE TABLE [dbo].[Institution]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(256) NOT NULL,
	[AdminId] UNIQUEIDENTIFIER NOT NULL,
	[IsActive] BIT NOT NULL DEFAULT(1),
	[CreatedDate] DATETIME NOT NULL,
	[UpdatedDate] DATETIME NOT NULL
);
GO

CREATE UNIQUE NONCLUSTERED INDEX [ix_institution_name] ON [dbo].[Institution]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO