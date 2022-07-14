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


insert into ItemStatus(StatusName) values('Active');
insert into ItemStatus(StatusName) values('Draft');



insert into ItemTypeCat(TypeName, Active) values('Jeweler''s', 1);

--catalogos en tipo de material en articulo para Jeweler
declare @JewelerId int
select top 1 @JewelerId = Id from ItemTypeCat

insert into ItemThemeCat(ThemeName, Active,ItemType) values('Default', 1, @JewelerId);

insert into ItemMaterialCat(MaterialName,ItemType) values ('Oro',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Plata',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Acero inoxidable',@JewelerId);
insert into ItemMaterialCat(MaterialName,ItemType) values ('Chapa oro',@JewelerId);
