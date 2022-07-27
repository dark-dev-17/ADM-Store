using ADM.Store.Models.Models.ItemCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Interfaces
{
    internal interface IItemCategoryService
    {
        public Task<ItemCategoryDetailsModel> CreateAsync(ItemCategoryCreateModel itemCategoryCreate);
        public Task DeleteAsync(int idItemType, int idCategory);
        public Task<ItemCategoryDetailsModel> DetailsAsync(int idItemType, int idCategory);
        public Task<List<ItemCategoryDetailsModel>> ListByTypeItemAsync(int idItemType);
        public Task<bool> UpdateAsync(ItemCategoryUpdateModel itemCategoryUpdate);
    }
}
