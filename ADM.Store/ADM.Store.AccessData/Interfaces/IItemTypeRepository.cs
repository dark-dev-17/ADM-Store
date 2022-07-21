using ADM.Store.Models.Models.ItemType;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemTypeRepository
    {
        public Task<ItemTypeDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemTypeDetailsModel>> ListAsync();
    }
}
