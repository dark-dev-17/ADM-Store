CREATE TABLE [dbo].[ItemThemeCat]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	ThemeName nvarchar(50) not null,
	Active bit not null,
	ItemType int not null,
	Foreign key(ItemType) references ItemTypeCat(Id),
)
