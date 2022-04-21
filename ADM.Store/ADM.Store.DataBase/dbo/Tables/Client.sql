CREATE TABLE [dbo].[Client]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY,
	ClientName nvarchar(200) not null,
	PhoneNumber nvarchar(12) null,
	CreatedBy nvarchar(10) not null,
	CreatedAt datetime not null,
	UpdatedAt datetime not null,
)
