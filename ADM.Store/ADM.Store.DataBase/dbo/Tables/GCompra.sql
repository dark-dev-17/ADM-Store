CREATE TABLE [dbo].[GCompra]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	IdProveedor uniqueidentifier not null,
	FechaCompra datetime not null,
	Total decimal(10,2) not null,
	IdCompraEstatus uniqueidentifier not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
	foreign key(IdProveedor) references GProveedor(Id),
	foreign key(IdCompraEstatus) references GCompraEstatus(Id)
)
