CREATE TABLE [dbo].[Address]
(
	[InstitutionId] INT NOT NULL PRIMARY KEY,
	[Address] VARCHAR(255) NOT NULL,
	[Address2] VARCHAR(255) NOT NULL,
	[City] VARCHAR(255) NOT NULL,
	[State] VARCHAR(255) NOT NULL,
	[Zip] VARCHAR(10) NOT NULL
);
GO;
ALTER TABLE [dbo].[Address] WITH CHECK ADD CONSTRAINT[FK_AddressInstitution_InstitutionId]
FOREIGN KEY([InstitutionId]) REFERENCES [dbo].[Institution] (Id)
GO


