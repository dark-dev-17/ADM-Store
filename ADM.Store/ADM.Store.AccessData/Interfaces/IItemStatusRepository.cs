using ADM.Store.Models.Models.ItemStatus;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemStatusRepository
    {
        public Task<ItemStatusDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemStatusDetailsModel>> ListAsync();
    }
}
