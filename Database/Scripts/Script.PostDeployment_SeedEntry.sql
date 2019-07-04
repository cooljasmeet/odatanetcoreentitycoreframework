/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


DECLARE @bookid BIGINT = 1;
DECLARE @ebookid BIGINT = 2;

DECLARE @AmritsarId BIGINT= 1;
DECLARE @WarraichId BIGINT = 2;

SET IDENTITY_INSERT dbo.Category ON BEGIN
MERGE INTO dbo.Category AS Target
USING (VALUES
    (@bookid, N'Book' ),
    (@ebookid, N'Ebook')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET [Name] = Source.[Name]
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, [Name])
VALUES (Id, [Name])
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


SET IDENTITY_INSERT dbo.Category OFF END

SET IDENTITY_INSERT dbo.Press ON BEGIN

MERGE INTO dbo.Press AS Target
USING (VALUES
    (@AmritsarId, N'Penguin Random House India', N'deepak@hike.in' , @bookid),
    (@WarraichId, N'Harper Collins India', N'ankush@rssb.net', @ebookid )
)
AS Source (Id, [Name],Email, CategoryId)
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET [Name] = Source.[Name],
			Email = Source.[Email],
			CategoryId = Source.CategoryId
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, [Name], CategoryId)
VALUES (Id, [Name], CategoryId)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;


SET IDENTITY_INSERT dbo.Press OFF END

SET IDENTITY_INSERT dbo.[Address] ON BEGIN

MERGE INTO dbo.[Address] AS Target
USING (VALUES
    (1, N'Amritsar', N'R 356 Balsrai ' ),
    (2, N'Warraich', N'C 59 Sewa Colony' )
)
AS Source (Id, City, Street)
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET [City] = Source.[City],
			Street = Source.Street
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, City, Street)
VALUES (Id, City, Street)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

SET IDENTITY_INSERT dbo.[Address] OFF END


SET IDENTITY_INSERT dbo.Book ON BEGIN
MERGE INTO dbo.Book AS Target
USING (VALUES
    (1, N'978-0-321-87758-1', N'Essential C#5.0', N'Ankush Sachdeva', 59.99,@bookid ,@AmritsarId ),
    (2, N'063-6-920-02371-5', N'Enterprise Games', N'Sharma Ji', 49.99,@ebookid ,@WarraichId )
)
AS Source (Id, ISBN, Title, Author, Price, AddressId, PressId)
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET ISBN = Source.ISBN,
			Title = Source.Title,
			Author = Source.Author,
			Price = Source.Price, 
			AddressID = Source.AddressId,
			PressId = Source.PressId
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, ISBN, Title, Author, Price, AddressId, PressId)
VALUES (Id, ISBN, Title, Author, Price, AddressId, PressId)
-- delete rows that are in the target but not the source
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

SET IDENTITY_INSERT dbo.Book OFF END