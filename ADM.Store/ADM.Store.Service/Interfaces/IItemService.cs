using ADM.Store.Models.Models.Item;
using ADM.Store.Models.Models.ItemOption;
using ADM.Store.Service.Responses;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IItemService
    {
        public Task<ItemDetailsModel> CreateAsync(ItemCreateModel itemCreate);
        public Task<List<ItemDetailsModel>> ListAsync();
        public Task<bool> DeleteAsync(string itemCode);
        public Task<ItemDetailsModel> DetailsAsync(string itemCode);
        public Task<bool> UpdateAsync(string itemCode, ItemUpdateModel itemUpdate);
        public Task<bool> AddOptionAsync(string itemCode, ItemOptionCreateModel optionCreate);
        public Task<bool> UpdateOptionAsync(string itemCode, string variation, ItemOptionUpdateModel itemUpdate);
        public Task<bool> DeleteOptionAsync(string itemCode, string variation);
        public Task<ItemOptionDetailsModel> DetailsOptionAsync(string itemCode, string variation);
        public Task<List<ItemOptionDetailsModel>> ListOptionAsync(string itemCode);
        public Task<string> ValidateItemCodeVariation(string itemCode);
    }
}
