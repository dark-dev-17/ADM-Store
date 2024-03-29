﻿CREATE TABLE [dbo].[PurchaseOrder]
(
	DocNum INT identity(1,1) NOT NULL PRIMARY KEY,
	Supplier NVARCHAR(20) NOT NULL,
	SupplierLocation int not null,
	SupplierContact int not null,
	DocDate date not null,
	DocTotal decimal(10,2) not null,
	DocStatus varchar(1) not null,
	Canceled bit not null,
	CandeledDate DateTime not null,
	CanceledBy nvarchar(200) not null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	FOREIGN KEY(Supplier) REFERENCES Supplier(CardCode),
	FOREIGN KEY(SupplierLocation) REFERENCES SupplierLocation(Id),
	FOREIGN KEY(SupplierContact) REFERENCES SupplierContact(Id)
)
