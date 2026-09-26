IF DB_ID(N'NguyenNgocManh_2410900051_Db') IS NULL
    CREATE DATABASE [NguyenNgocManh_2410900051_Db];
GO

USE [NguyenNgocManh_2410900051_Db];
GO

IF OBJECT_ID(N'dbo.NguyenNgocManhEmployee', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NguyenNgocManhEmployee
    (
        Id INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_NguyenNgocManhEmployee PRIMARY KEY,
        NguyenNgocManhName NVARCHAR(100) NOT NULL,
        NguyenNgocManhGender NVARCHAR(10) NOT NULL,
        NguyenNgocManhBirthDay DATE NOT NULL,
        NguyenNgocManhEmail NVARCHAR(150) NOT NULL,
        NguyenNgocManhPhone VARCHAR(20) NOT NULL,
        NguyenNgocManhActive BIT NOT NULL
            CONSTRAINT DF_NguyenNgocManhEmployee_Active DEFAULT (1)
    );
END;
GO

IF OBJECT_ID(N'dbo.NguyenNgocManhStudent', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NguyenNgocManhStudent
    (
        Id INT IDENTITY(1,1) NOT NULL
            CONSTRAINT PK_NguyenNgocManhStudent PRIMARY KEY,
        NguyenNgocManhName NVARCHAR(100) NOT NULL,
        NguyenNgocManhGender NVARCHAR(10) NOT NULL,
        NguyenNgocManhBirthDay DATE NOT NULL,
        NguyenNgocManhEmail NVARCHAR(150) NULL,
        NguyenNgocManhPhone VARCHAR(20) NULL,
        NguyenNgocManhActive BIT NOT NULL
            CONSTRAINT DF_NguyenNgocManhStudent_Active DEFAULT (1)
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.NguyenNgocManhStudent)
BEGIN
    INSERT INTO dbo.NguyenNgocManhStudent
        (NguyenNgocManhName, NguyenNgocManhGender, NguyenNgocManhBirthDay,
         NguyenNgocManhEmail, NguyenNgocManhPhone, NguyenNgocManhActive)
    VALUES
        (N'Nguyễn Ngọc Mạnh', N'Nam', '20060701',
         N'2410900051@student.example', '0912345678', 1);
END;
GO
