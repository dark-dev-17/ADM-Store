using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemTheme;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Repositories
{
    internal class ItemThemeRepository : IItemThemeRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemThemeRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemThemeDetailsModel?> Details(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var queryType = from type in _aDMStore.ItemThemeCats
                            where type.Id == id
                            select new ItemThemeDetailsModel
                            {
                                Id = id,
                                ThemeName = type.ThemeName,
                            };
            return await queryType.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }
            var queryType = from type in _aDMStore.ItemThemeCats
                            where type.ThemeName == name
                            select type.Id;
            return await queryType.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemThemeDetailsModel>> ListAsync()
        {
            var types_query = from ItemType in _aDMStore.ItemThemeCats
                              where ItemType.Active == true
                              select new ItemThemeDetailsModel
                              {
                                  Id = ItemType.Id,
                                  ThemeName = ItemType.ThemeName
                              };

            return await types_query.ToListAsync().ConfigureAwait(false);
        }
    }
}
