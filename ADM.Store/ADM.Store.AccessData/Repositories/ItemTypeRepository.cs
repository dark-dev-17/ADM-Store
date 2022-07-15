using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Repositories
{
    internal class ItemTypeRepository : IItemTypeRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemTypeRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemTypeDetailsModel?> Details(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var queryType = from type in _aDMStore.ItemTypeCats
                            where type.Id == id
                            select new ItemTypeDetailsModel
                            {
                                Id = id,
                                TypeName = type.TypeName,
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
            var queryType = from type in _aDMStore.ItemTypeCats
                            where type.TypeName == name
                            select type.Id;
            return await queryType.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemTypeDetailsModel>> ListAsync()
        {
            var types_query = from ItemType in _aDMStore.ItemTypeCats
                              where ItemType.Active == true
                              select new ItemTypeDetailsModel
                              {
                                  Id = ItemType.Id,
                                  TypeName = ItemType.TypeName
                              };

            return await types_query.ToListAsync().ConfigureAwait(false);
        }
    }
}
