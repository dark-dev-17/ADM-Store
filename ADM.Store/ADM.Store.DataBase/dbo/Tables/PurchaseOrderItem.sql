CREATE TABLE [dbo].[PurchaseOrderItem] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [DocNum]     INT,
    [ItemCode]   NVARCHAR (50)   NOT NULL,
    [Variation]  NVARCHAR (3)    NULL,
    [TypeItem]   NVARCHAR (3)    NOT NULL,
    [UnitPrice]  DECIMAL (10, 2) NOT NULL,
    [Quantity]   INT             NOT NULL,
    [Total]      DECIMAL (10, 2) NOT NULL,
    [LineNum]    INT             NOT NULL,
    [Reference1] NVARCHAR (50)   NULL,
    [Reference2] NVARCHAR (50)   NULL,
    [Comments]   NVARCHAR (MAX)  NULL,
    [CreatedBy]  NVARCHAR (200)  NOT NULL,
    [CreatedAt]  DATETIME        NOT NULL,
    [UpdatedAt]  DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED (Id ASC),
    FOREIGN KEY ([DocNum]) REFERENCES [dbo].[PurchaseOrder] ([DocNum])
);


