IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    CREATE TABLE [Artist] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [isFeatured] bit NOT NULL,
        CONSTRAINT [PK_Artist] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    CREATE TABLE [Exhibition] (
        [Id] int NOT NULL IDENTITY,
        [StartDate] nvarchar(max) NOT NULL,
        [EndDate] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [currentlyRunning] bit NOT NULL,
        CONSTRAINT [PK_Exhibition] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    CREATE TABLE [ArtWork] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CompletionDate] nvarchar(max) NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        [ArtistId] int NULL,
        [ExhibitionId] int NULL,
        CONSTRAINT [PK_ArtWork] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ArtWork_Artist_ArtistId] FOREIGN KEY ([ArtistId]) REFERENCES [Artist] ([Id]),
        CONSTRAINT [FK_ArtWork_Exhibition_ExhibitionId] FOREIGN KEY ([ExhibitionId]) REFERENCES [Exhibition] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    CREATE INDEX [IX_ArtWork_ArtistId] ON [ArtWork] ([ArtistId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    CREATE INDEX [IX_ArtWork_ExhibitionId] ON [ArtWork] ([ExhibitionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202201041_initdata')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231202201041_initdata', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202233855_updateddata')
BEGIN
    ALTER TABLE [Artist] ADD [ExhibitionId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202233855_updateddata')
BEGIN
    CREATE INDEX [IX_Artist_ExhibitionId] ON [Artist] ([ExhibitionId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202233855_updateddata')
BEGIN
    ALTER TABLE [Artist] ADD CONSTRAINT [FK_Artist_Exhibition_ExhibitionId] FOREIGN KEY ([ExhibitionId]) REFERENCES [Exhibition] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231202233855_updateddata')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231202233855_updateddata', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203031950_exhibitioncreation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203031950_exhibitioncreation', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203053003_updatingtables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203053003_updatingtables', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203195624_mssql.local_migration_157')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203195624_mssql.local_migration_157', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'Title');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [Title] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'Price');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [Price] decimal(18,2) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'ImageUrl');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [ImageUrl] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'Description');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [Description] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'CompletionDate');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [CompletionDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203201350_addingdata')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203201350_addingdata', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [Artist] DROP CONSTRAINT [FK_Artist_Exhibition_ExhibitionId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [ArtWork] DROP CONSTRAINT [FK_ArtWork_Artist_ArtistId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [ArtWork] DROP CONSTRAINT [FK_ArtWork_Exhibition_ExhibitionId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[Exhibition].[Id]', N'ID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[ArtWork].[ExhibitionId]', N'ExhibitionID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[ArtWork].[ArtistId]', N'ArtistID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[ArtWork].[Id]', N'ID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[ArtWork].[IX_ArtWork_ExhibitionId]', N'IX_ArtWork_ExhibitionID', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[ArtWork].[IX_ArtWork_ArtistId]', N'IX_ArtWork_ArtistID', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[Artist].[ExhibitionId]', N'ExhibitionID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[Artist].[Id]', N'ID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    EXEC sp_rename N'[Artist].[IX_Artist_ExhibitionId]', N'IX_Artist_ExhibitionID', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Exhibition]') AND [c].[name] = N'StartDate');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Exhibition] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Exhibition] ALTER COLUMN [StartDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Exhibition]') AND [c].[name] = N'EndDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Exhibition] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Exhibition] ALTER COLUMN [EndDate] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Exhibition]') AND [c].[name] = N'Address');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Exhibition] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Exhibition] ALTER COLUMN [Address] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    DROP INDEX [IX_ArtWork_ExhibitionID] ON [ArtWork];
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'ExhibitionID');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [ExhibitionID] int NOT NULL;
    ALTER TABLE [ArtWork] ADD DEFAULT 0 FOR [ExhibitionID];
    CREATE INDEX [IX_ArtWork_ExhibitionID] ON [ArtWork] ([ExhibitionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    DROP INDEX [IX_Artist_ExhibitionID] ON [Artist];
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Artist]') AND [c].[name] = N'ExhibitionID');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Artist] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Artist] ALTER COLUMN [ExhibitionID] int NOT NULL;
    ALTER TABLE [Artist] ADD DEFAULT 0 FOR [ExhibitionID];
    CREATE INDEX [IX_Artist_ExhibitionID] ON [Artist] ([ExhibitionID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [Artist] ADD CONSTRAINT [FK_Artist_Exhibition_ExhibitionID] FOREIGN KEY ([ExhibitionID]) REFERENCES [Exhibition] ([ID]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [ArtWork] ADD CONSTRAINT [FK_ArtWork_Artist_ArtistID] FOREIGN KEY ([ArtistID]) REFERENCES [Artist] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    ALTER TABLE [ArtWork] ADD CONSTRAINT [FK_ArtWork_Exhibition_ExhibitionID] FOREIGN KEY ([ExhibitionID]) REFERENCES [Exhibition] ([ID]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203212403_relationaldata')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203212403_relationaldata', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    ALTER TABLE [Artist] DROP CONSTRAINT [FK_Artist_Exhibition_ExhibitionID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    ALTER TABLE [ArtWork] DROP CONSTRAINT [FK_ArtWork_Exhibition_ExhibitionID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    ALTER TABLE [Exhibition] ADD [Name] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'ExhibitionID');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [ExhibitionID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Artist]') AND [c].[name] = N'ExhibitionID');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Artist] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Artist] ALTER COLUMN [ExhibitionID] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    ALTER TABLE [Artist] ADD CONSTRAINT [FK_Artist_Exhibition_ExhibitionID] FOREIGN KEY ([ExhibitionID]) REFERENCES [Exhibition] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    ALTER TABLE [ArtWork] ADD CONSTRAINT [FK_ArtWork_Exhibition_ExhibitionID] FOREIGN KEY ([ExhibitionID]) REFERENCES [Exhibition] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203214654_addedNameToExhibition')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203214654_addedNameToExhibition', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203215833_addedNameToExhibitionAGAINNNNN')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Artist]') AND [c].[name] = N'FirstName');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Artist] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Artist] DROP COLUMN [FirstName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203215833_addedNameToExhibitionAGAINNNNN')
BEGIN
    EXEC sp_rename N'[Artist].[LastName]', N'Name', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203215833_addedNameToExhibitionAGAINNNNN')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203215833_addedNameToExhibitionAGAINNNNN', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203222022_makeworksandartistsoptional')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203222022_makeworksandartistsoptional', N'6.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    ALTER TABLE [ArtWork] DROP CONSTRAINT [FK_ArtWork_Artist_ArtistID];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    DROP INDEX [IX_ArtWork_ArtistID] ON [ArtWork];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ArtWork]') AND [c].[name] = N'ArtistID');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [ArtWork] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [ArtWork] ALTER COLUMN [ArtistID] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    ALTER TABLE [ArtWork] ADD [ArtistID1] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    ALTER TABLE [ArtWork] ADD [isFeatured] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    CREATE INDEX [IX_ArtWork_ArtistID1] ON [ArtWork] ([ArtistID1]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    ALTER TABLE [ArtWork] ADD CONSTRAINT [FK_ArtWork_Artist_ArtistID1] FOREIGN KEY ([ArtistID1]) REFERENCES [Artist] ([ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20231203225631_makeworksandartistsoptionalaaaa')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20231203225631_makeworksandartistsoptionalaaaa', N'6.0.25');
END;
GO

COMMIT;
GO

