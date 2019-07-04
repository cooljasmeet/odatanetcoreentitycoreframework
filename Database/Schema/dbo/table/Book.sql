CREATE TABLE [dbo].[Book]
(
    [Id] BIGINT IDENTITY (1, 1) NOT NULL,
	[ISBN] NVARCHAR (100)  NULL,
	[Title] NVARCHAR (100)  ,
	[Author] NVARCHAR (100)  NULL,
	[Price]  INT NULL,
	[AddressId] BIGINT NULL,
	[PressId] BIGINT NULL,
	CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Book_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
)
