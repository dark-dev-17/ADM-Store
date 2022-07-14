CREATE TABLE [dbo].[ItemTag]
(
	ItemCode nvarchar(50) NOT NULL,
	ItemTag int not null,
	primary key(ItemCode,ItemTag)
)
