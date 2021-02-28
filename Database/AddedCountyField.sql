BEGIN TRANSACTION;
GO

EXEC sp_rename N'[AddressBooks].[AddressBookId]', N'AddressId', N'COLUMN';
GO

ALTER TABLE [AddressBooks] ADD [County] nvarchar(50) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210226141014_AddedCountyField', N'5.0.2');
GO

COMMIT;
GO

