IF DB_ID(N'FinanceTracker') IS NULL
    CREATE DATABASE FinanceTracker;
GO
USE FinanceTracker;
GO
IF OBJECT_ID(N'dbo.OperationTypes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.OperationTypes (
        Id int NOT NULL PRIMARY KEY CHECK (Id IN (1, 2)),
        Name nvarchar(20) NOT NULL UNIQUE
    );
    INSERT INTO dbo.OperationTypes (Id, Name) VALUES (1, N'Доход'), (2, N'Расход');
END;
GO
IF OBJECT_ID(N'dbo.Operations', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Operations (
        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
        TypeId int NOT NULL REFERENCES dbo.OperationTypes(Id),
        Amount decimal(12,2) NOT NULL CHECK (Amount > 0),
        OperationDate date NOT NULL,
        Description nvarchar(150) NOT NULL DEFAULT N''
    );
END;
GO
