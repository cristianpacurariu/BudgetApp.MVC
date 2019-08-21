
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/21/2019 11:37:04
-- Generated from EDMX file: C:\Users\LTm\Desktop\C# exercises\BugdetApp.MVC.Git\MVC.Budget.DataAccess\Model\SpendingsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SpendingsDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Accounts_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_Accounts_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Operations_OperationTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operations] DROP CONSTRAINT [FK_Operations_OperationTypes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[Operations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operations];
GO
IF OBJECT_ID(N'[dbo].[OperationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OperationTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdCurrency] int  NOT NULL,
    [Name] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(3)  NULL
);
GO

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdAccount] int  NOT NULL,
    [IdOperationType] int  NOT NULL,
    [Ammount] decimal(18,2)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OperationTypes'
CREATE TABLE [dbo].[OperationTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(25)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsCredit] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Currencies'
ALTER TABLE [dbo].[Currencies]
ADD CONSTRAINT [PK_Currencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperationTypes'
ALTER TABLE [dbo].[OperationTypes]
ADD CONSTRAINT [PK_OperationTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCurrency] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_Accounts_Currencies]
    FOREIGN KEY ([IdCurrency])
    REFERENCES [dbo].[Currencies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Accounts_Currencies'
CREATE INDEX [IX_FK_Accounts_Currencies]
ON [dbo].[Accounts]
    ([IdCurrency]);
GO

-- Creating foreign key on [IdAccount] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operations_Accounts]
    FOREIGN KEY ([IdAccount])
    REFERENCES [dbo].[Accounts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_Accounts'
CREATE INDEX [IX_FK_Operations_Accounts]
ON [dbo].[Operations]
    ([IdAccount]);
GO

-- Creating foreign key on [IdOperationType] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [FK_Operations_OperationTypes]
    FOREIGN KEY ([IdOperationType])
    REFERENCES [dbo].[OperationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operations_OperationTypes'
CREATE INDEX [IX_FK_Operations_OperationTypes]
ON [dbo].[Operations]
    ([IdOperationType]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------