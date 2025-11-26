USE TP1;
GO

IF OBJECT_ID('dbo.Productos') IS NULL
BEGIN
    CREATE TABLE dbo.Productos(
        Id     INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Precio DECIMAL(10,2) NOT NULL
    );
END
