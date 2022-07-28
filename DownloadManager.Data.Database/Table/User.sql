CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL IDENTITY, 
    [Username] NVARCHAR(256) NOT NULL, 
	[PasswordHash] VARCHAR(MAX) NOT NULL,
	[PasswordSalt] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId]),
    CONSTRAINT UC_Username UNIQUE ([Username])
)
