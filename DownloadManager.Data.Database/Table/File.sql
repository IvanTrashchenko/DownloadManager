CREATE TABLE [dbo].[File]
(
	[FileId] INT NOT NULL IDENTITY, 
    [FileName] NVARCHAR(256) NOT NULL,
	[FileDownloadDirectory] NVARCHAR(MAX) NOT NULL, 
    [FileDownloadMethod] INT NOT NULL, 
    [FileDownloadTime] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_File] PRIMARY KEY ([FileId])
)
