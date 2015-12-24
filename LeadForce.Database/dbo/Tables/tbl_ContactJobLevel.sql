﻿-- Creating table 'tbl_ContactJobLevel'
CREATE TABLE [dbo].[tbl_ContactJobLevel] (
    [ID] uniqueidentifier  NOT NULL,
    [Name] nvarchar(250)  NOT NULL,
    [SiteID] uniqueidentifier  NOT NULL
);
GO
-- Creating foreign key on [SiteID] in table 'tbl_ContactJobLevel'
ALTER TABLE [dbo].[tbl_ContactJobLevel]
ADD CONSTRAINT [FK_tbl_ContactJobLevel_tbl_Sites]
    FOREIGN KEY ([SiteID])
    REFERENCES [dbo].[tbl_Sites]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [ID] in table 'tbl_ContactJobLevel'
ALTER TABLE [dbo].[tbl_ContactJobLevel]
ADD CONSTRAINT [PK_tbl_ContactJobLevel]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_ContactJobLevel_tbl_Sites'
CREATE INDEX [IX_FK_tbl_ContactJobLevel_tbl_Sites]
ON [dbo].[tbl_ContactJobLevel]
    ([SiteID]);