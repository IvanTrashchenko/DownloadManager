CREATE TABLE [dbo].[File]
(
	[FileId] INT NOT NULL IDENTITY, 
    [FileName] NVARCHAR(256) NOT NULL,
	[FileDownloadDirectory] NVARCHAR(MAX) NOT NULL, 
    [FileDownloadMethod] INT NOT NULL, 
    [FileDownloadTime] DATETIME2 NOT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [PK_File] PRIMARY KEY ([FileId]),
	CONSTRAINT [FK_File_User] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
