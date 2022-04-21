CREATE TABLE [dbo].[BookAccount]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	IdClient uniqueidentifier not null,
	NoAccount int not null,
	Total decimal(10,2),
	TotalPaid decimal(10,2),
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
)
