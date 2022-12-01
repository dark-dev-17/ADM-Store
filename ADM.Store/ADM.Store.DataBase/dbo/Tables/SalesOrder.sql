CREATE TABLE [dbo].[SalesOrder]
(
	DocNum INT identity(1,1) NOT NULL PRIMARY KEY,
	Customer int not null,
	DocDate date not null,
	DocType int not null,
	DocTotal decimal(10,2) not null,
	DocStatus varchar(1) not null,
	Canceled bit not null,
	CandeledDate DateTime not null,
	CanceledBy nvarchar(200) not null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	Foreign key(Customer) references Customer(Id)
)
