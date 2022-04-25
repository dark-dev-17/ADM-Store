CREATE TABLE [dbo].[BookAccount]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	IdClient uniqueidentifier not null,
	TypeAccount int not null,
	Total decimal(10,2) not null,
	TotalPaid decimal(10,2) not null,
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
)
