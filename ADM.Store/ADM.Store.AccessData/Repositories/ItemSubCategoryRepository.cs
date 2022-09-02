using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemSubCategory;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class ItemSubCategoryRepository : IItemSubCategoryRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemSubCategoryRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<int> CreateAsync(int idItemType, int idCategory, string categoryName)
        {
            if (idItemType == 0)
            {
                return 0;
            }

            if (idCategory == 0)
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
                CategoryParent = idCategory,
            };

            await _aDMStore.ItemCategoryCats.AddAsync(newCategory).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newCategory.Id;
        }

        public async Task<ItemSubCategoryDetailsModel?> DetailsAsync(int idCategory, int idSubCategory)
        {
            if (idCategory == 0)
            {
                return null;
            }
            if (idSubCategory == 0)
            {
                return null;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.Id == idSubCategory && cat.CategoryParent == idCategory
                                select new ItemSubCategoryDetailsModel
                                {
                                    Id = cat.Id,
                                    CategoryName = cat.CategoryName,
                                    CategoryParent = cat.CategoryParent
                                };
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> ExistsInCategoryeAsync(int idCategory, int idSubCategory)
        {
            if (idCategory == 0)
            {
                return 0;
            }
            if (idSubCategory == 0)
            {
                return 0;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.Id == idSubCategory && cat.CategoryParent == idCategory
                                select cat.Id;
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> ExistsInCategoryeAsync(int idCategory, string subCategoryName)
        {
            if (idCategory == 0)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(subCategoryName))
            {
                return 0;
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.CategoryName.ToLower().Trim() == subCategoryName.ToLower().Trim() && cat.CategoryParent == idCategory
                                select cat.Id;
            return await queryCategory.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<ItemSubCategoryDetailsModel>> ListAsync(int idCategory, bool showOnlyActives = false)
        {
            if (idCategory == 0)
            {
                return new List<ItemSubCategoryDetailsModel>();
            }

            var queryCategory = from cat in _aDMStore.ItemCategoryCats
                                where cat.CategoryParent == idCategory
                                select new ItemSubCategoryDetailsModel
                                {
                                    Id = cat.Id,
                                    CategoryName = cat.CategoryName,
                                };
            return await queryCategory.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(int idSubCategory, string subCategoryName)
        {
            if (idSubCategory == 0)
            {
                return false;
            }

            var categoryForUpdate = await _aDMStore.ItemCategoryCats.FirstOrDefaultAsync(cat => cat.Id == idSubCategory).ConfigureAwait(false);

            if (categoryForUpdate == null)
            {
                return false;
            }

            categoryForUpdate.CategoryName = subCategoryName;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
