using ADM.Store.Models.Models.ItemOption;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemOptionRespository
    {
        public Task<bool> CreateAsync(ItemOptionCreateModel itemOption);
        public Task<bool> DeleteAsync(string itemCode, string variation);
        public Task<ItemOptionDetailsModel?> DetailsAsync(string itemCode, string variation);
        public Task<bool> ExistsAsync(string itemCode, string variation);
        public Task<List<ItemOptionDetailsModel>> ListAsync(string itemCode);
        public Task<bool> UpdateAsync(ItemOptionUpdateModel itemOption);
    }
}
