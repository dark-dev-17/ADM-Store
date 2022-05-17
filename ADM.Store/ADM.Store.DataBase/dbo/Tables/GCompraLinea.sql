CREATE TABLE [dbo].[GCompraLinea]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	IdCompra uniqueidentifier not null,
	Descripcion nvarchar(200) not null,
	PrecioCompra decimal(10,2) not null,
	PrecioAproxVenta decimal(10,2) not null,
	IdCompraLineaEstatus uniqueidentifier not null,
	FolioNota nvarchar(50) not null,
	Comentarios nvarchar(max) null,
	foreign key(IdCompraLineaEstatus) references GCompraLineaEstatus(Id),
	foreign key(IdCompra) references GCompra(Id)
)
