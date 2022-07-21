using ADM.Store.Models.Models.ItemCategory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemCategoryRepository
    {
        public Task<int> CreateAsync(int idItemType, string categoryName);
        public Task<ItemCategoryDetailsModel?> DetailsAsync(int idCategory, int idItemType);
        public Task<int> ExistsInItemTypeAsync(int idCategory, int idItemType);
        public Task<int> ExistsInItemTypeAsync(string categoryName, int idItemType);
        public Task<List<ItemCategoryDetailsModel>> ListAsync(int idItemType, bool showOnlyActives = false);
        public Task<bool> UpdateAsync(int idCategory, string categoryName);
    }
}
