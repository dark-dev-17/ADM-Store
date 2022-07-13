CREATE TABLE [dbo].[ItemTagsCat]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	TagName nvarchar(200) not null,
	ItemType int not null,
	Foreign key(ItemType) references ItemTypeCat(Id),
)
