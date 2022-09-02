/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


insert into ItemStatus(StatusName) values('Activo');
insert into ItemStatus(StatusName) values('Borrador');



insert into ItemTypeCat(TypeName, Active) values('Joyeria', 1);

--catalogos en tipo de material en articulo para Jeweler
declare @JewelerId int
select top 1 @JewelerId = Id from ItemTypeCat

insert into ItemThemeCat(ThemeName, Active,ItemType) values('Default', 1, @JewelerId);

insert into ItemMaterialCat(MaterialName,ItemType) values ('Oro',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Plata',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Acero inoxidable',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Chapa oro',@JewelerId);

--catelogos para tipo de producto de cadena
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Cadena',null)

declare @cadenaIdCategory int
select top 1 @cadenaIdCategory = Id from ItemCategoryCat where CategoryName = 'Cadena'

--https://www.youtube.com/watch?v=S8b8x3-u0tM

insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Ancla plana',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Barbada',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Bilbao',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Bizantina',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Bolas',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Gucci',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Cola de rata',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Cartier o 3x1',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Forzada',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Serpiente',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Espiga',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'Belcher',@cadenaIdCategory)
insert into ItemCategoryCat(ItemType,CategoryName,CategoryParent) values (@JewelerId,'',@cadenaIdCategory)


