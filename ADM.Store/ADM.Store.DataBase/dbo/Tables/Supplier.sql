CREATE TABLE [dbo].[Supplier]
(
	CardCode NVARCHAR(20) NOT NULL PRIMARY KEY,
	SuplierName NVARCHAR(150) NOT NULL,
	SupplierStatus INT NOT NULL,
	Active BIT not null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	FOREIGN KEY(SupplierStatus) REFERENCES SupplierStatusCat(Id)
)
