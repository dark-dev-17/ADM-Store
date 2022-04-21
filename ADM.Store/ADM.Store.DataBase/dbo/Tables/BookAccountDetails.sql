CREATE TABLE [dbo].[BookAccountDetails]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	[IdBookAccount] int not null,
	IdItem nvarchar(50) null,
	TypeDetails int not null,
	Total decimal(10,2) not null,
	Comments nvarchar(max) null,
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	foreign key([IdBookAccount]) references [BookAccount](Id),
	foreign key(IdItem) references Item(Id)
)
