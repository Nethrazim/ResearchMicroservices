﻿CREATE TABLE [dbo].[Teacher]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[InstitutionId] INT   NOT  NULL,
	[FirstName] VARCHAR(255)   NOT NULL,
	[MiddleName] VARCHAR(255)  NULL,
	[LastName] VARCHAR(255)    NOT NULL,
	[Gender] BIT NOT NULL,
)
GO;
