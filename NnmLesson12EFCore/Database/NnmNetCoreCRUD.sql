IF DB_ID(N'NnmNetCoreCRUD') IS NULL
BEGIN
    CREATE DATABASE [NnmNetCoreCRUD];
END
GO

USE [NnmNetCoreCRUD];
GO

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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    CREATE TABLE [NnmBanner] (
        [Id] int NOT NULL IDENTITY,
        [NnmName] nvarchar(150) NOT NULL,
        [NnmImage] varchar(150) NULL,
        [NnmDescription] nvarchar(1000) NULL,
        [NnmCreatedDate] datetime2 NOT NULL,
        [NnmStatus] tinyint NOT NULL,
        CONSTRAINT [PK_NnmBanner] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    CREATE TABLE [NnmCategory] (
        [Id] int NOT NULL IDENTITY,
        [NnmName] nvarchar(100) NOT NULL,
        [NnmStatus] tinyint NOT NULL,
        [NnmCreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_NnmCategory] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    CREATE TABLE [NnmProduct] (
        [Id] int NOT NULL IDENTITY,
        [NnmName] nvarchar(150) NOT NULL,
        [NnmImage] varchar(150) NULL,
        [NnmPrice] real NOT NULL,
        [NnmSalePrice] real NOT NULL,
        [NnmStatus] tinyint NOT NULL,
        [NnmDescriptions] ntext NULL,
        [NnmCategoryId] int NOT NULL,
        [NnmCreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_NnmProduct] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NnmProduct_NnmCategory_NnmCategoryId] FOREIGN KEY ([NnmCategoryId]) REFERENCES [NnmCategory] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCreatedDate', N'NnmDescription', N'NnmImage', N'NnmName', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmBanner]'))
        SET IDENTITY_INSERT [NnmBanner] ON;
    EXEC(N'INSERT INTO [NnmBanner] ([Id], [NnmCreatedDate], [NnmDescription], [NnmImage], [NnmName], [NnmStatus])
    VALUES (1, ''2026-09-30T08:00:00.0000000'', N''Nguyễn Ngọc Mạnh - 2410900051 - K24-CNT2'', ''lesson12.svg'', N''Chào mừng đến với Lesson12'', CAST(1 AS tinyint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCreatedDate', N'NnmDescription', N'NnmImage', N'NnmName', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmBanner]'))
        SET IDENTITY_INSERT [NnmBanner] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCreatedDate', N'NnmName', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmCategory]'))
        SET IDENTITY_INSERT [NnmCategory] ON;
    EXEC(N'INSERT INTO [NnmCategory] ([Id], [NnmCreatedDate], [NnmName], [NnmStatus])
    VALUES (1, ''2026-09-30T08:00:00.0000000'', N''Sách'', CAST(1 AS tinyint)),
    (2, ''2026-09-30T08:00:00.0000000'', N''Đồ dùng học tập'', CAST(1 AS tinyint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCreatedDate', N'NnmName', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmCategory]'))
        SET IDENTITY_INSERT [NnmCategory] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCategoryId', N'NnmCreatedDate', N'NnmDescriptions', N'NnmImage', N'NnmName', N'NnmPrice', N'NnmSalePrice', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmProduct]'))
        SET IDENTITY_INSERT [NnmProduct] ON;
    EXEC(N'INSERT INTO [NnmProduct] ([Id], [NnmCategoryId], [NnmCreatedDate], [NnmDescriptions], [NnmImage], [NnmName], [NnmPrice], [NnmSalePrice], [NnmStatus])
    VALUES (1, 2, ''2026-09-30T08:00:00.0000000'', N''Sổ tay dùng để ghi chép bài học.'', ''notebook.svg'', N''Sổ tay'', CAST(45000 AS real), CAST(39000 AS real), CAST(1 AS tinyint)),
    (2, 1, ''2026-09-30T08:00:00.0000000'', N''Sách tham khảo lập trình.'', ''book.svg'', N''Sách lập trình'', CAST(150000 AS real), CAST(0 AS real), CAST(1 AS tinyint))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmCategoryId', N'NnmCreatedDate', N'NnmDescriptions', N'NnmImage', N'NnmName', N'NnmPrice', N'NnmSalePrice', N'NnmStatus') AND [object_id] = OBJECT_ID(N'[NnmProduct]'))
        SET IDENTITY_INSERT [NnmProduct] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    CREATE INDEX [IX_NnmProduct_NnmCategoryId] ON [NnmProduct] ([NnmCategoryId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051630_NnmCreateCatalog'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260930051630_NnmCreateCatalog', N'8.0.31');
END;
GO

COMMIT;
GO
