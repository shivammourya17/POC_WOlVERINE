USE [crud];
GO

IF SCHEMA_ID(N'Asset') IS NULL
BEGIN
    EXEC(N'CREATE SCHEMA Asset');
END
GO

IF OBJECT_ID(N'Asset.AssetCategory', N'U') IS NULL
BEGIN
    CREATE TABLE Asset.AssetCategory
    (
        AssetCategoryId INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Asset_AssetCategory PRIMARY KEY,
        Name            NVARCHAR(100)     NOT NULL CONSTRAINT UQ_Asset_AssetCategory_Name UNIQUE,
        CreatedDate     DATETIME2         NOT NULL CONSTRAINT DF_Asset_AssetCategory_CreatedDate DEFAULT (SYSUTCDATETIME())
    );
END
GO

-- Written by the post decorator (AuditAssetCategoryDecorator) for every AddAssetCategoryCommand.
IF OBJECT_ID(N'Asset.AssetCategoryAudit', N'U') IS NULL
BEGIN
    CREATE TABLE Asset.AssetCategoryAudit
    (
        AuditId     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Asset_AssetCategoryAudit PRIMARY KEY,
        Name        NVARCHAR(100)     NULL,
        IsSuccess   BIT               NOT NULL,
        Message     NVARCHAR(500)     NULL,
        CreatedDate DATETIME2         NOT NULL CONSTRAINT DF_Asset_AssetCategoryAudit_CreatedDate DEFAULT (SYSUTCDATETIME())
    );
END
GO
