CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Salt] [nvarchar](255) NOT NULL,
	[Role] INT NOT NULL,
	[IsLockedOut] [bit] NOT NULL DEFAULT(0),
	[IsPublished] [bit] NOT NULL DEFAULT(1),
	[SystemUserId] [uniqueidentifier] NOT NULL
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [ix_users_email]    Script Date: 25/10/2021 20:34:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [ix_users_email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

/****** Object:  Index [ix_users_username]    Script Date: 25/10/2021 20:35:08 ******/
CREATE NONCLUSTERED INDEX [ix_users_username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
CREATE TRIGGER [dbo].[tr_UserUpdate] ON [dbo].[Users]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE U
	SET IsPublished = 0
	FROM 
	[dbo].Users U 
	JOIN deleted ON deleted.Id = U.Id
	WHERE NOT EXISTS(SELECT
						U.Username
						,U.Email
						,U.Password
						,U.Salt
						,U.Role
						,U.IsLockedOut
						,U.SystemUserId
					INTERSECT 
					SELECT
						deleted.Username
						,deleted.Email
						,deleted.Password
						,deleted.Salt
						,deleted.Role
						,deleted.IsLockedOut
						,deleted.SystemUserId
					
					)
END
GO
CREATE TRIGGER [dbo].[tr_UserInsert] ON [dbo].[Users]
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE U
	SET IsPublished = 0
	FROM 
	[dbo].Users U 
	JOIN inserted ON inserted.Id = U.Id	
END
GO