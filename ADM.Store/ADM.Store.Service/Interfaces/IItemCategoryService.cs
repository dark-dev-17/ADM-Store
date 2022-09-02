using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemSubCategory;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IItemCategoryService
    {
        public Task<int> CreateAsync(int idItemType, ItemCategoryCreateModel itemCategoryCreate);
        public Task DeleteAsync(int idItemType, int idCategory);
        public Task<ItemCategoryDetailsModel> DetailsAsync(int idItemType, int idCategory);
        public Task<List<ItemCategoryDetailsModel>> ListByTypeItemAsync(int idItemType);
        public Task<bool> UpdateAsync(int idItemType, int idItemCategory, ItemCategoryUpdateModel itemCategoryUpdate);
        public Task<int> AddSubCategoryAsync(int idItemType, ItemSubCategoryCreateModel itemSubCategoryCreate);
        public Task<ItemSubCategoryDetailsModel> DetailsSubCategoryAsync(int idItemType, int idCategory, int idSubCategory);
        public Task<List<ItemSubCategoryDetailsModel>> ListSubCategoryAsync(int idItemType, int idCategory);
        public Task<bool> UpdateSubCategoryAsync(int idItemType, ItemSubCategoryUpdateModel itemSubCategoryUpdate);
    }
}
