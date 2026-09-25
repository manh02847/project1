IF DB_ID(N'NnmK24CNT2Lesson10EFDb') IS NULL
BEGIN
    CREATE DATABASE NnmK24CNT2Lesson10EFDb;
END
GO

USE NnmK24CNT2Lesson10EFDb;
GO

IF OBJECT_ID(N'dbo.NnmMember', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.NnmMember
    (
        Id BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        NnmUserName VARCHAR(20) NULL,
        NnmPassword VARCHAR(50) NULL,
        NnmFullName NVARCHAR(50) NULL,
        NnmEmail VARCHAR(50) NULL,
        NnmPhone CHAR(12) NULL,
        NnmStatus BIT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.NnmMember)
BEGIN
    INSERT INTO dbo.NnmMember
        (NnmUserName, NnmPassword, NnmFullName, NnmEmail, NnmPhone, NnmStatus)
    VALUES
        ('manh02847', 'Password123!', N'Nguyễn Ngọc Mạnh', 'manh02847@example.com', '0987654321', 1),
        ('tranthib', 'SecurePass456#', N'Trần Thị B', 'tranthib@example.com', '0912345678', 1);
END
GO

-- Lệnh Scaffold-DbContext tương ứng (Windows Authentication):
-- Scaffold-DbContext "Server=.\SQL2019;Database=NnmK24CNT2Lesson10EFDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
