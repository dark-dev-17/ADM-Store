CREATE TABLE [dbo].[ItemOption]
(
	Id int identity (1,1) primary key not null,
	[ItemCode] nvarchar(50) NOT NULL,
	Variation nvarchar(3) not null,
	ItemTile nvarchar(max) not null,
	ItemDescription text not null,
	UnitPrice decimal(10,2) not null,
	Stock int not null,
	Size nvarchar(10) not null,
	ColorName nvarchar(100) null,
	ColorCode nvarchar(100) null,
	foreign key(ItemCode) references Item(ItemCode)
)
