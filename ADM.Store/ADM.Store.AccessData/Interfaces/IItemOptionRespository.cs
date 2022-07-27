using ADM.Store.Models.Models.ItemOption;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemOptionRespository
    {
        public Task<bool> CreateAsync(ItemOptionCreateModel itemOption, int idStatus);
        public Task<bool> DeleteAsync(string itemCode, string variation);
        public Task<ItemOptionDetailsModel?> DetailsAsync(string itemCode, string variation);
        public Task<bool> ExistsAsync(string itemCode, string variation);
        public Task<List<ItemOptionDetailsModel>> ListAsync(string itemCode);
        public Task<bool> UpdateAsync(ItemOptionUpdateModel itemOption);
    }
}
