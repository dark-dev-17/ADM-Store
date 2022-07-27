CREATE TABLE [dbo].[ItemOption]
(
	[ItemCode] nvarchar(50) NOT NULL,
	Variation nvarchar(3) not null,
	ItemTile nvarchar(max) not null,
	ItemDescription text not null,
	UnitPrice decimal(10,2) not null,
	Stock int not null,
	Size nvarchar(10) not null,
	ItemStatus int not null,
	ColorName nvarchar(100) null,
	ColorCode nvarchar(100) null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	foreign key(ItemCode) references Item(ItemCode),
	primary key(ItemCode,Variation)
)
