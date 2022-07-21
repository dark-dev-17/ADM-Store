using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemCategory;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemCategoryRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<int> CreateAsync(int idItemType, string categoryName)
        {
            if (idItemType == 0)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return 0;
            }

            var newCategory = new ItemCategoryCat
            {
                CategoryName = categoryName,
                ItemType = idItemType,
                CategoryParent = null,
            };

            await _aDMStore.ItemCategoryCats.AddAsync(newCategory).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newCategory.Id;
        }

        public async Task<ItemCategoryDetailsModel?> DetailsAsync(int idCategory, int idItemType)
        {
            if (idCategory == 0)
            {
                return null;
            }
            if (idItemType == 0)
            {
                return null;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.Id == idCategory && cat.ItemType == idItemType
                                select new ItemCategoryDetailsModel
                                {
                                    Id = cat.Id,
                                    CategoryName = cat.CategoryName,
                                };
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> ExistsInItemTypeAsync(int idCategory, int idItemType)
        {
            if (idItemType == 0)
            {
                return 0;
            }
            if (idCategory == 0)
            {
                return 0;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.Id == idCategory && cat.ItemType == idItemType
                                select cat.Id;
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> ExistsInItemTypeAsync(string categoryName, int idItemType)
        {
            if (idItemType == 0)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return 0;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.CategoryName.ToLower().Trim() == categoryName.ToLower().Trim() && cat.ItemType == idItemType
                                select cat.Id;
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<ItemCategoryDetailsModel>> ListAsync(int idItemType, bool showOnlyActives = false)
        {
            if (idItemType == 0)
            {
                return new List<ItemCategoryDetailsModel>();
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.ItemType == idItemType && cat.CategoryParent == null
                                select new ItemCategoryDetailsModel
                                {
                                    Id = cat.Id,
                                    CategoryName = cat.CategoryName,
                                };
            return await queryCategory.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(int idCategory, string categoryName)
        {
            if (idCategory == 0)
            {
                return false;
            }

            var categoryForUpdate = await _aDMStore.ItemCategoryCats.FirstOrDefaultAsync(cat => cat.Id == idCategory).ConfigureAwait(false);

            if (categoryForUpdate == null)
            {
                return false;
            }

            categoryForUpdate.CategoryName = categoryName;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
