IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ERPDB')
  BEGIN
    CREATE DATABASE [ERPDB]

    END
    GO
       USE [ERPDB]
    GO
    
IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='TruckStatuses' and xtype='U')
BEGIN
    CREATE TABLE TruckStatuses (
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Name VARCHAR(200) NOT NULL,
    )
END

SET IDENTITY_INSERT TruckStatuses ON

GO 

MERGE INTO TruckStatuses ts
USING
(
    SELECT 0 AS Id, N'Out Of Service' AS Name UNION ALL
    SELECT 1, N'Loading' UNION ALL 
    SELECT 2, N'To Job' UNION ALL 
    SELECT 3, N'At Job' UNION ALL 
    SELECT 4, N'Returning'
) AS src
ON ts.Id = src.Id
WHEN NOT MATCHED THEN INSERT(Id,Name) VALUES(src.Id, src.Name);

SET IDENTITY_INSERT TruckStatuses OFF


IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='Trucks' and xtype='U')
BEGIN
    CREATE TABLE Trucks (
        Id INT PRIMARY KEY IDENTITY (1, 1),
        Code VARCHAR(200) NOT NULL,
        Name VARCHAR(200) NOT NULL,
        StatusId INT NOT NULL,
        Description NVARCHAR(4000) NULL
    )
END
GO

SET IDENTITY_INSERT Trucks ON

MERGE INTO Trucks t
USING
(
    SELECT 1 AS Id, 'COFFEE001' AS Code, 'Coffee Truck 1' AS Name, 1 AS StatusId, N'Coffee Truck for testing.' AS Description UNION ALL
    SELECT 2, 'BEER001', 'Beer Truck 1', 2, N'Beer Truck for testing.' UNION ALL
    SELECT 3, 'CHOC0_XL', 'Big Choco Truck 1', 0, N'Choco Truck for testing.'
) AS tsrc
ON t.Id = tsrc.Id
WHEN NOT MATCHED THEN INSERT(Id, Code, Name, StatusId, Description) 
VALUES(tsrc.Id, tsrc.Code, tsrc.Name, tsrc.StatusId, tsrc.Description);

SET IDENTITY_INSERT Trucks OFF

GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='UNQ_Trucks_Code' AND object_id = OBJECT_ID('Trucks'))
BEGIN
    CREATE UNIQUE INDEX UNQ_Trucks_Code ON Trucks(Code)
END

GO

IF (OBJECT_ID('FK_Trucks_TruckStatuses', 'F') IS NULL)
BEGIN
    ALTER TABLE Trucks ADD CONSTRAINT FK_Trucks_TruckStatuses FOREIGN KEY (StatusId)
    REFERENCES TruckStatuses (Id)
END