﻿-- Creating table 'tbl_PaymentArticle'
CREATE TABLE [dbo].[tbl_PaymentArticle] (
    [ID] uniqueidentifier  NOT NULL,
    [SiteID] uniqueidentifier  NOT NULL,
    [Title] nvarchar(256)  NOT NULL,
    [PaymentPassCategoryID] uniqueidentifier  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO
-- Creating foreign key on [PaymentPassCategoryID] in table 'tbl_PaymentArticle'
ALTER TABLE [dbo].[tbl_PaymentArticle]
ADD CONSTRAINT [FK_tbl_PaymentArticle_tbl_PaymentPassCategory]
    FOREIGN KEY ([PaymentPassCategoryID])
    REFERENCES [dbo].[tbl_PaymentPassCategory]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating foreign key on [SiteID] in table 'tbl_PaymentArticle'
ALTER TABLE [dbo].[tbl_PaymentArticle]
ADD CONSTRAINT [FK_tbl_PaymentArticle_tbl_Sites]
    FOREIGN KEY ([SiteID])
    REFERENCES [dbo].[tbl_Sites]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO
-- Creating primary key on [ID] in table 'tbl_PaymentArticle'
ALTER TABLE [dbo].[tbl_PaymentArticle]
ADD CONSTRAINT [PK_tbl_PaymentArticle]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_PaymentArticle_tbl_PaymentPassCategory'
CREATE INDEX [IX_FK_tbl_PaymentArticle_tbl_PaymentPassCategory]
ON [dbo].[tbl_PaymentArticle]
    ([PaymentPassCategoryID]);
GO
-- Creating non-clustered index for FOREIGN KEY 'FK_tbl_PaymentArticle_tbl_Sites'
CREATE INDEX [IX_FK_tbl_PaymentArticle_tbl_Sites]
ON [dbo].[tbl_PaymentArticle]
    ([SiteID]);