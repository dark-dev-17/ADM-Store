CREATE TABLE [dbo].[ItemMaterialCat]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	MaterialName nvarchar(150) not null,
	ItemType int not null,
	Foreign key(ItemType) references ItemTypeCat(Id)
)
