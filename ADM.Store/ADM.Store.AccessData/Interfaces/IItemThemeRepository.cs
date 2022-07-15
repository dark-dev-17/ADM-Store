using ADM.Store.Models.Models.ItemTheme;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemThemeRepository
    {
        public Task<ItemThemeDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemThemeDetailsModel>> ListAsync();
    }
}
