CREATE TABLE [dbo].[SupplierLocation]
(
	Id INT IDENTITY NOT NULL PRIMARY KEY,
	CardCode NVARCHAR(20) NOT NULL,
    LocationName nvarchar(max) NOT NULL,
	LocationAddress nvarchar(max) not null,
    StateName nvarchar(30) not null,
    Town nvarchar(30) not null,
    ZipCode nvarchar(5) not null,
    ReferencesCo nvarchar(max) null,
	Active BIT not null,
	CreatedBy nvarchar(200) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
    FOREIGN KEY(CardCode) REFERENCES Supplier(CardCode)
)
