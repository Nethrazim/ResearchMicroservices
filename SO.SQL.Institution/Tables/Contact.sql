CREATE TABLE [dbo].[Contact]
(
	[InstitutionId] INT NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR(255) NOT NULL,
	[MiddleName] VARCHAR(255) NOT NULL,
	[LastName] VARCHAR(255) NOT NULL,
	[Email] VARCHAR(255) NOT NULL,
	[Phone] VARCHAR(15) NOT NULL,
);
GO;
ALTER TABLE [dbo].[Contact] WITH CHECK ADD CONSTRAINT[FK_ContactInstitution_InstitutionId]
FOREIGN KEY([InstitutionId]) REFERENCES [dbo].[Institution] (Id)
GO


