﻿-- Creating table 'tbl_RequirementImplementationComplete'
CREATE TABLE [dbo].[tbl_RequirementImplementationComplete] (
    [ID] uniqueidentifier  NOT NULL,
    [SiteID] uniqueidentifier  NOT NULL,
    [Title] nvarchar(256)  NOT NULL
);
GO
-- Creating foreign key on [SiteID] in table 'tbl_RequirementImplementationComplete'
ALTER TABLE [dbo].[tbl_RequirementImplementationComplete]
ADD CONSTRAINT [FK_tbl_RequirementImplementationComplete_tbl_Sites]
    FOREIGN KEY ([SiteID])
    REFERENCES [dbo].[tbl_Sites]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [ID] in table 'tbl_RequirementImplementationComplete'
ALTER TABLE [dbo].[tbl_RequirementImplementationComplete]
ADD CONSTRAINT [PK_tbl_RequirementImplementationComplete]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_RequirementImplementationComplete_tbl_Sites'
CREATE INDEX [IX_FK_tbl_RequirementImplementationComplete_tbl_Sites]
ON [dbo].[tbl_RequirementImplementationComplete]
    ([SiteID]);