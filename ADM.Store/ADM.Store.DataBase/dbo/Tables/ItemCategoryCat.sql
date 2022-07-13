CREATE TABLE [dbo].[ItemCategoryCat]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	ItemType int not null,
	CategoryName nvarchar(150) not null,
	CategoryParent int null,
	Foreign key(ItemType) references ItemTypeCat(Id),
	Foreign key(ItemType) references ItemTypeCat(Id)
)
