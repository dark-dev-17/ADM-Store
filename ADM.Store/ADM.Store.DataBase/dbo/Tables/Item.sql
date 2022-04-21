CREATE TABLE [dbo].[Item]
(
	[Id] nvarchar(50) NOT NULL PRIMARY KEY,
	ItemDescription nvarchar(max) not null,
	UnitPrice decimal(10,2) not null,
	Quantity int not null,
	IdCategory int not null,
	IdSubCategory int not null,
	IdMaterial int not null,
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,

	foreign key(IdCategory) references Category(Id),
	foreign key(IdSubCategory) references Category(Id),
	foreign key(IdMaterial) references ItemMaterial(Id)
)
