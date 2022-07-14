CREATE TABLE [dbo].[ItemTypeCat]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY,
	TypeName nvarchar(150) not null,
	Active bit not null,
)
