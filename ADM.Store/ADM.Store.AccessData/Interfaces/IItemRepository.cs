using ADM.Store.Models.Models.Item;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemRepository
    {
        public Task<string> CreateAsync(ItemCreateModel itemCreate);
        public Task<ItemDetailsModel?> DetailsAsync(string itemCode);
        public Task<bool> ExistsAsync(string itemCode);
        public Task<List<ItemDetailsModel>> ListAsync();
        public Task<bool> DeleteAsync(string itemCode);
        public Task<bool> UpdateAsync(ItemUpdateModel itemUpdate);
    }
}
