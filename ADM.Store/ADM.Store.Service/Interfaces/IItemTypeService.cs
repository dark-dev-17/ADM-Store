using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.ItemType;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IItemTypeService
    {
        public Task<ItemTypeDetailsModel> DetailsAsync(int idItemType);
        public Task<List<ItemTypeDetailsModel>> ListAsync();
        //public Task UpdateAsync();
    }
}
