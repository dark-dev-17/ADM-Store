using ADM.Store.Models.Models.ItemTheme;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemThemeRepository
    {
        public Task<ItemThemeDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemThemeDetailsModel>> ListAsync();
    }
}
