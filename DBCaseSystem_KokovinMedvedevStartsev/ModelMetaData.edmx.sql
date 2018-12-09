
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2018 17:20:41
-- Generated from EDMX file: C:\Users\user\Source\Repos\DBCase_System_KokovinMedvedevStartsev\DBCaseSystem_KokovinMedvedevStartsev\ModelMetaData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [metaModelDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AttributeTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AttributeSet] DROP CONSTRAINT [FK_AttributeTable];
GO
IF OBJECT_ID(N'[dbo].[FK_TableRelation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RelationSet] DROP CONSTRAINT [FK_TableRelation];
GO
IF OBJECT_ID(N'[dbo].[FK_DatabaseTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TableSet] DROP CONSTRAINT [FK_DatabaseTable];
GO
IF OBJECT_ID(N'[dbo].[FK_QueryQueryOutput]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[QueryOutputSet] DROP CONSTRAINT [FK_QueryQueryOutput];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TableSet];
GO
IF OBJECT_ID(N'[dbo].[RelationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelationSet];
GO
IF OBJECT_ID(N'[dbo].[AttributeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttributeSet];
GO
IF OBJECT_ID(N'[dbo].[QuerySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QuerySet];
GO
IF OBJECT_ID(N'[dbo].[DatabaseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DatabaseSet];
GO
IF OBJECT_ID(N'[dbo].[QueryOutputSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QueryOutputSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TableSet'
CREATE TABLE [dbo].[TableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Database_Id] int  NOT NULL
);
GO

-- Creating table 'RelationSet'
CREATE TABLE [dbo].[RelationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ConnectedTableID] int  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Table_Id] int  NOT NULL
);
GO

-- Creating table 'AttributeSet'
CREATE TABLE [dbo].[AttributeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [IsNull] bit  NOT NULL,
    [IsKey] bit  NOT NULL,
    [Length] int  NOT NULL,
    [DefaultValue] nvarchar(max)  NOT NULL,
    [Indexed] bit  NOT NULL,
    [Table_Id] int  NOT NULL
);
GO

-- Creating table 'QuerySet'
CREATE TABLE [dbo].[QuerySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [QueryText] nvarchar(max)  NOT NULL,
    [QueryObject_Id] int  NOT NULL
);
GO

-- Creating table 'DatabaseSet'
CREATE TABLE [dbo].[DatabaseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'QueryOutputSet'
CREATE TABLE [dbo].[QueryOutputSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Query_Id] int  NOT NULL
);
GO

-- Creating table 'QueryObjectSet'
CREATE TABLE [dbo].[QueryObjectSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ObjectID] nvarchar(max)  NOT NULL,
    [Type] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TableSet'
ALTER TABLE [dbo].[TableSet]
ADD CONSTRAINT [PK_TableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [PK_RelationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AttributeSet'
ALTER TABLE [dbo].[AttributeSet]
ADD CONSTRAINT [PK_AttributeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuerySet'
ALTER TABLE [dbo].[QuerySet]
ADD CONSTRAINT [PK_QuerySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DatabaseSet'
ALTER TABLE [dbo].[DatabaseSet]
ADD CONSTRAINT [PK_DatabaseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QueryOutputSet'
ALTER TABLE [dbo].[QueryOutputSet]
ADD CONSTRAINT [PK_QueryOutputSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QueryObjectSet'
ALTER TABLE [dbo].[QueryObjectSet]
ADD CONSTRAINT [PK_QueryObjectSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Table_Id] in table 'AttributeSet'
ALTER TABLE [dbo].[AttributeSet]
ADD CONSTRAINT [FK_AttributeTable]
    FOREIGN KEY ([Table_Id])
    REFERENCES [dbo].[TableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AttributeTable'
CREATE INDEX [IX_FK_AttributeTable]
ON [dbo].[AttributeSet]
    ([Table_Id]);
GO

-- Creating foreign key on [Table_Id] in table 'RelationSet'
ALTER TABLE [dbo].[RelationSet]
ADD CONSTRAINT [FK_TableRelation]
    FOREIGN KEY ([Table_Id])
    REFERENCES [dbo].[TableSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TableRelation'
CREATE INDEX [IX_FK_TableRelation]
ON [dbo].[RelationSet]
    ([Table_Id]);
GO

-- Creating foreign key on [Database_Id] in table 'TableSet'
ALTER TABLE [dbo].[TableSet]
ADD CONSTRAINT [FK_DatabaseTable]
    FOREIGN KEY ([Database_Id])
    REFERENCES [dbo].[DatabaseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DatabaseTable'
CREATE INDEX [IX_FK_DatabaseTable]
ON [dbo].[TableSet]
    ([Database_Id]);
GO

-- Creating foreign key on [Query_Id] in table 'QueryOutputSet'
ALTER TABLE [dbo].[QueryOutputSet]
ADD CONSTRAINT [FK_QueryQueryOutput]
    FOREIGN KEY ([Query_Id])
    REFERENCES [dbo].[QuerySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QueryQueryOutput'
CREATE INDEX [IX_FK_QueryQueryOutput]
ON [dbo].[QueryOutputSet]
    ([Query_Id]);
GO

-- Creating foreign key on [QueryObject_Id] in table 'QuerySet'
ALTER TABLE [dbo].[QuerySet]
ADD CONSTRAINT [FK_QueryObjectQuery]
    FOREIGN KEY ([QueryObject_Id])
    REFERENCES [dbo].[QueryObjectSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QueryObjectQuery'
CREATE INDEX [IX_FK_QueryObjectQuery]
ON [dbo].[QuerySet]
    ([QueryObject_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------