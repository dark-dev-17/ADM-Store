CREATE TABLE [dbo].[OutgoingPayment]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	Total decimal(10,2) not null,
	PaymentDate date not null,
	BussinesAccount int not null,
	DocNum int not null,
	Comments nvarchar(max) null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	foreign key(DocNum) references PurchaseOrder (DocNum),
	foreign key(BussinesAccount) references BussinesAccount (Id),
)
