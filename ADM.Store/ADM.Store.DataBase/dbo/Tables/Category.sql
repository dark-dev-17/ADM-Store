CREATE TABLE [dbo].[Category]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	Description nvarchar(max) not null, 
	ParentId int null,
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null
)
