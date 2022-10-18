using ADM.Store.Models.Models.Item;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemRepository
    {
        public Task<string> CreateAsync(ItemCreateModel itemCreate, int idStatus);
        public Task<ItemDetailsModel?> DetailsAsync(string itemCode);
        public Task<bool> ExistsAsync(string itemCode);
        public Task<List<ItemDetailsModel>> ListAsync();
        public Task<bool> DeleteAsync(string itemCode);
        public Task<bool> UpdateAsync(ItemUpdateModel itemUpdate);
        public Task<string> ExistsItemVariationAsync(string itemCode);
    }
}
