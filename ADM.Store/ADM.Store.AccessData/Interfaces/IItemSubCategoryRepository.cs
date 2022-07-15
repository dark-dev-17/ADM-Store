using ADM.Store.Models.Models.ItemSubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemSubCategoryRepository
    {
        public Task<int> CreateAsync(int idItemType, int idCategory, string categoryName);
        public Task<ItemSubCategoryDetailsModel?> DetailsAsync(int idCategory, int idSubCategory);
        public Task<int> ExistsInCategoryeAsync(int idCategory, int idSubCategory);
        public Task<int> ExistsInCategoryeAsync(int idCategory, string subCategoryName);
        public Task<List<ItemSubCategoryDetailsModel>> ListAsync(int idCategory, bool showOnlyActives = false);
        public Task<bool> UpdateAsync(int idSubCategory, string subCategoryName);
    }
}
