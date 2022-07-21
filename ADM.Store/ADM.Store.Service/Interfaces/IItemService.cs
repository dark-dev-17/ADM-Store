using ADM.Store.Models.Models.Item;
using ADM.Store.Service.Responses;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IItemService
    {
        public Task<ItemDetailsModel> CreateAsync(ItemCreateModel itemCreate);
        public Task<List<ItemDetailsModel>> ListAsync();
        ////public Task<>
        public Task<bool> DeleteAsync(string itemCode);
        public Task<ItemDetailsModel> DetailsAsync(string itemCode);
        public Task<bool> UpdateAsync(string itemCode, ItemUpdateModel itemUpdate);
    }
}
