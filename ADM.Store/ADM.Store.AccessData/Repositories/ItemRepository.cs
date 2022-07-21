using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Item;
using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemMaterial;
using ADM.Store.Models.Models.ItemStatus;
using ADM.Store.Models.Models.ItemSubCategory;
using ADM.Store.Models.Models.ItemType;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<string> CreateAsync(ItemCreateModel itemCreate, int idStatus)
        {
            var newItem = new Item
            {
                ItemCode = itemCreate.ItemCode,
                ItemTile = itemCreate.ItemTile,
                ItemDescription = itemCreate.ItemDescription,
                UnitPrice = itemCreate.UnitPrice,
                ChageTax = itemCreate.ChageTax,
                Stock = itemCreate.Stock,
                ItemStatus = idStatus,
                ItemType = itemCreate.ItemType,
                Material = itemCreate.Material,
                Category = itemCreate.Category,
                SubCategory = itemCreate.SubCategory,
                ManagedByOptions = itemCreate.ManagedByOptions,
                Size = itemCreate.Size,
                ColorName = itemCreate.ColorName,
                ColorCode = itemCreate.ColorCode,
                // TODO service-user
                CreatedBy = "USER-SYS",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _aDMStore.Items.AddAsync(newItem).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newItem.ItemCode;
        }

        public async Task<bool> DeleteAsync(string itemCode)
        {
            var item = await _aDMStore.Items.FirstOrDefaultAsync(item => item.ItemCode.Trim() == itemCode.Trim()).ConfigureAwait(false);
            if (item == null)
            {
                return false;
            }

            _aDMStore.Items.Remove(item);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<ItemDetailsModel?> DetailsAsync(string itemCode)
        {
            #region query
            var itemQuery = from item in _aDMStore.Items
                            join type in _aDMStore.ItemTypeCats on item.ItemType equals type.Id
                            join material in _aDMStore.ItemMaterialCats on item.Material equals material.Id
                            join status in _aDMStore.ItemStatuses on item.ItemStatus equals status.Id
                            join category in _aDMStore.ItemCategoryCats on item.Category equals category.Id
                            join subcategory in _aDMStore.ItemCategoryCats on item.SubCategory equals subcategory.Id
                            where item.ItemCode == itemCode
                            select new ItemDetailsModel
                            {
                                ItemCode = item.ItemCode,
                                ItemTile = item.ItemTile,
                                ItemDescription = item.ItemDescription,
                                UnitPrice = item.UnitPrice,
                                ChageTax = item.ChageTax,
                                Stock = item.Stock,
                                ItemStatus = new ItemStatusDetailsModel
                                {
                                    Id = status.Id,
                                    StatusName = status.StatusName,
                                },
                                ItemType = new ItemTypeDetailsModel
                                {
                                    Id = type.Id,
                                    TypeName = type.TypeName,
                                },
                                Material = new ItemMaterialDetailsModel
                                {
                                    Id = material.Id,
                                    MaterialName = material.MaterialName
                                },
                                Category = new ItemCategoryDetailsModel
                                {
                                    Id = category.Id,
                                    CategoryName = category.CategoryName
                                },
                                SubCategory = subcategory == null ? null : new ItemSubCategoryDetailsModel
                                {
                                    Id = subcategory.Id,
                                    CategoryName = subcategory.CategoryName,
                                    CategoryParent = subcategory.CategoryParent
                                },
                                ManagedByOptions = item.ManagedByOptions,
                                Size = item.Size,
                                ColorName = item.ColorName,
                                ColorCode = item.ColorCode,
                                CreatedBy = item.CreatedBy,
                                CreatedAt = item.CreatedAt,
                                UpdatedAt = item.UpdatedAt,
                            };
            #endregion

            return await itemQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(string itemCode)
        {
            return await _aDMStore.Items.AnyAsync(item => item.ItemCode == itemCode).ConfigureAwait(false);
        }

        public async Task<List<ItemDetailsModel>> ListAsync()
        {
            #region query
            var itemListQuery = from item in _aDMStore.Items
                            join type in _aDMStore.ItemTypeCats on item.ItemType equals type.Id
                            join material in _aDMStore.ItemMaterialCats on item.Material equals material.Id
                            join status in _aDMStore.ItemStatuses on item.ItemStatus equals status.Id
                            join category in _aDMStore.ItemCategoryCats on item.Category equals category.Id
                            join subcategory in _aDMStore.ItemCategoryCats on item.SubCategory equals subcategory.Id
                            orderby item.ItemCode
                            select new ItemDetailsModel
                            {
                                ItemCode = item.ItemCode,
                                ItemTile = item.ItemTile,
                                ItemDescription = item.ItemDescription,
                                UnitPrice = item.UnitPrice,
                                ChageTax = item.ChageTax,
                                Stock = item.Stock,
                                ItemStatus = new ItemStatusDetailsModel
                                {
                                    Id = status.Id,
                                    StatusName = status.StatusName,
                                },
                                ItemType = new ItemTypeDetailsModel
                                {
                                    Id = type.Id,
                                    TypeName = type.TypeName,
                                },
                                Material = new ItemMaterialDetailsModel
                                {
                                    Id = material.Id,
                                    MaterialName = material.MaterialName
                                },
                                Category = new ItemCategoryDetailsModel
                                {
                                    Id = category.Id,
                                    CategoryName = category.CategoryName
                                },
                                SubCategory = subcategory == null ? null : new ItemSubCategoryDetailsModel
                                {
                                    Id = subcategory.Id,
                                    CategoryName = subcategory.CategoryName,
                                    CategoryParent = subcategory.CategoryParent
                                },
                                ManagedByOptions = item.ManagedByOptions,
                                Size = item.Size,
                                ColorName = item.ColorName,
                                ColorCode = item.ColorCode,
                                CreatedBy = item.CreatedBy,
                                CreatedAt = item.CreatedAt,
                                UpdatedAt = item.UpdatedAt,
                            };
            #endregion

            return await itemListQuery.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(ItemUpdateModel itemUpdate)
        {
            var item = await _aDMStore.Items.FirstOrDefaultAsync(item => item.ItemCode.Trim() == itemUpdate.ItemCode.Trim()).ConfigureAwait(false);
            if (item == null)
            {
                return false;
            }

            item.ItemTile = itemUpdate.ItemTile;
            item.ItemDescription = itemUpdate.ItemDescription;
            item.UnitPrice = itemUpdate.UnitPrice;
            item.ChageTax = itemUpdate.ChageTax;
            item.Stock = itemUpdate.Stock;
            item.ItemStatus = itemUpdate.ItemStatus;
            item.ItemType = itemUpdate.ItemType;
            item.Material = itemUpdate.Material;
            item.Category = itemUpdate.Category;
            item.SubCategory = itemUpdate.SubCategory;
            item.ManagedByOptions = itemUpdate.ManagedByOptions;
            item.Size = itemUpdate.Size;
            item.ColorName = itemUpdate.ColorName;
            item.ColorCode = itemUpdate.ColorCode;
            item.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
