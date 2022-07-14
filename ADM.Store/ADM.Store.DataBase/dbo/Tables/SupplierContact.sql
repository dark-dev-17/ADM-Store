CREATE TABLE [dbo].[SupplierContact]
(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	CardCode NVARCHAR(20) NOT NULL,
    SupplierName nvarchar(max) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL,
	Active BIT not null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
    FOREIGN KEY(CardCode) REFERENCES Supplier(CardCode)
)
