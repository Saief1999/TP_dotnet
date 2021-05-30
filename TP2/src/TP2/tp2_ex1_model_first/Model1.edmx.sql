
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2021 11:40:21
-- Generated from EDMX file: C:\Users\saief\source\repos\TP2\tp2_ex1_model_first\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db_tp2_model_first];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VCSystems'
CREATE TABLE [dbo].[VCSystems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [release_date] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Developers'
CREATE TABLE [dbo].[Developers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [full_name] nvarchar(max)  NOT NULL,
    [adress] nvarchar(max)  NOT NULL,
    [age] int  NOT NULL
);
GO

-- Creating table 'DeveloperVCSystem'
CREATE TABLE [dbo].[DeveloperVCSystem] (
    [Developer_Id] int  NOT NULL,
    [VCSystems_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VCSystems'
ALTER TABLE [dbo].[VCSystems]
ADD CONSTRAINT [PK_VCSystems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Developers'
ALTER TABLE [dbo].[Developers]
ADD CONSTRAINT [PK_Developers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Developer_Id], [VCSystems_Id] in table 'DeveloperVCSystem'
ALTER TABLE [dbo].[DeveloperVCSystem]
ADD CONSTRAINT [PK_DeveloperVCSystem]
    PRIMARY KEY CLUSTERED ([Developer_Id], [VCSystems_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Developer_Id] in table 'DeveloperVCSystem'
ALTER TABLE [dbo].[DeveloperVCSystem]
ADD CONSTRAINT [FK_DeveloperVCSystem_Developer]
    FOREIGN KEY ([Developer_Id])
    REFERENCES [dbo].[Developers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [VCSystems_Id] in table 'DeveloperVCSystem'
ALTER TABLE [dbo].[DeveloperVCSystem]
ADD CONSTRAINT [FK_DeveloperVCSystem_VCSystem]
    FOREIGN KEY ([VCSystems_Id])
    REFERENCES [dbo].[VCSystems]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DeveloperVCSystem_VCSystem'
CREATE INDEX [IX_FK_DeveloperVCSystem_VCSystem]
ON [dbo].[DeveloperVCSystem]
    ([VCSystems_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------