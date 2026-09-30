IF DB_ID(N'NnmStudentManager') IS NULL
BEGIN
    CREATE DATABASE [NnmStudentManager];
END
GO

USE [NnmStudentManager];
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
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE TABLE [NnmStdClass] (
        [Id] int NOT NULL IDENTITY,
        [NnmClassName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_NnmStdClass] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE TABLE [NnmSubjects] (
        [Id] int NOT NULL IDENTITY,
        [NnmSubjectName] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_NnmSubjects] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE TABLE [NnmStudent] (
        [Id] int NOT NULL IDENTITY,
        [NnmStudentName] nvarchar(100) NOT NULL,
        [NnmStudentEmail] nvarchar(100) NOT NULL,
        [NnmStudentPhone] nvarchar(50) NOT NULL,
        [NnmStudentAddress] nvarchar(150) NOT NULL,
        [NnmStudentAvatar] nvarchar(100) NOT NULL,
        [NnmStudentBirthday] date NOT NULL,
        [NnmClassId] int NOT NULL,
        CONSTRAINT [PK_NnmStudent] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NnmStudent_NnmStdClass_NnmClassId] FOREIGN KEY ([NnmClassId]) REFERENCES [NnmStdClass] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE TABLE [NnmMarks] (
        [NnmSubjectId] int NOT NULL,
        [NnmStudentId] int NOT NULL,
        [NnmScore] float NOT NULL,
        CONSTRAINT [PK_NnmMarks] PRIMARY KEY ([NnmSubjectId], [NnmStudentId]),
        CONSTRAINT [FK_NnmMarks_NnmStudent_NnmStudentId] FOREIGN KEY ([NnmStudentId]) REFERENCES [NnmStudent] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_NnmMarks_NnmSubjects_NnmSubjectId] FOREIGN KEY ([NnmSubjectId]) REFERENCES [NnmSubjects] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmClassName') AND [object_id] = OBJECT_ID(N'[NnmStdClass]'))
        SET IDENTITY_INSERT [NnmStdClass] ON;
    EXEC(N'INSERT INTO [NnmStdClass] ([Id], [NnmClassName])
    VALUES (1, N''K24-CNT2''),
    (2, N''K24-CNT1'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmClassName') AND [object_id] = OBJECT_ID(N'[NnmStdClass]'))
        SET IDENTITY_INSERT [NnmStdClass] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmSubjectName') AND [object_id] = OBJECT_ID(N'[NnmSubjects]'))
        SET IDENTITY_INSERT [NnmSubjects] ON;
    EXEC(N'INSERT INTO [NnmSubjects] ([Id], [NnmSubjectName])
    VALUES (1, N''ASP.NET Core MVC''),
    (2, N''Cơ sở dữ liệu'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmSubjectName') AND [object_id] = OBJECT_ID(N'[NnmSubjects]'))
        SET IDENTITY_INSERT [NnmSubjects] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmClassId', N'NnmStudentAddress', N'NnmStudentAvatar', N'NnmStudentBirthday', N'NnmStudentEmail', N'NnmStudentName', N'NnmStudentPhone') AND [object_id] = OBJECT_ID(N'[NnmStudent]'))
        SET IDENTITY_INSERT [NnmStudent] ON;
    EXEC(N'INSERT INTO [NnmStudent] ([Id], [NnmClassId], [NnmStudentAddress], [NnmStudentAvatar], [NnmStudentBirthday], [NnmStudentEmail], [NnmStudentName], [NnmStudentPhone])
    VALUES (1, 1, N''Địa chỉ mẫu'', N''student.svg'', ''2006-01-01'', N''sinhviena@example.com'', N''Nguyễn Văn A'', N''0900000001'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'NnmClassId', N'NnmStudentAddress', N'NnmStudentAvatar', N'NnmStudentBirthday', N'NnmStudentEmail', N'NnmStudentName', N'NnmStudentPhone') AND [object_id] = OBJECT_ID(N'[NnmStudent]'))
        SET IDENTITY_INSERT [NnmStudent] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'NnmStudentId', N'NnmSubjectId', N'NnmScore') AND [object_id] = OBJECT_ID(N'[NnmMarks]'))
        SET IDENTITY_INSERT [NnmMarks] ON;
    EXEC(N'INSERT INTO [NnmMarks] ([NnmStudentId], [NnmSubjectId], [NnmScore])
    VALUES (1, 1, 8.0E0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'NnmStudentId', N'NnmSubjectId', N'NnmScore') AND [object_id] = OBJECT_ID(N'[NnmMarks]'))
        SET IDENTITY_INSERT [NnmMarks] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE INDEX [IX_NnmMarks_NnmStudentId] ON [NnmMarks] ([NnmStudentId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE INDEX [IX_NnmStudent_NnmClassId] ON [NnmStudent] ([NnmClassId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE UNIQUE INDEX [IX_NnmStudent_NnmStudentEmail] ON [NnmStudent] ([NnmStudentEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE UNIQUE INDEX [IX_NnmStudent_NnmStudentPhone] ON [NnmStudent] ([NnmStudentPhone]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    CREATE UNIQUE INDEX [IX_NnmSubjects_NnmSubjectName] ON [NnmSubjects] ([NnmSubjectName]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260930051636_NnmCreateStudentManager'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260930051636_NnmCreateStudentManager', N'8.0.31');
END;
GO

COMMIT;
GO
