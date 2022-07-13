CREATE TABLE [dbo].[GProveedor]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	Nombre nvarchar(300) not null,
	Telefono nvarchar(20) not null,
	Calle nvarchar(200) not null,
	Municipio nvarchar(200) not null,
	Estado nvarchar(5) not null,
	NoInt nvarchar(20) null,
	NoExt nvarchar(20) null,
	CP nvarchar(6) not null,
	FacePage nvarchar(max) null,
	WebPage nvarchar(max) null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)
