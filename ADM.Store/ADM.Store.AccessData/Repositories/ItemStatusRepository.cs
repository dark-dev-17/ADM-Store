using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemStatus;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class ItemStatusRepository : IItemStatusRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemStatusRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemStatusDetailsModel?> Details(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var queryType = from type in _aDMStore.ItemStatuses
                            where type.Id == id
                            select new ItemStatusDetailsModel
                            {
                                Id = id,
                                StatusName = type.StatusName,
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
            var queryType = from type in _aDMStore.ItemStatuses
                            where type.StatusName == name
                            select type.Id;
            return await queryType.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ItemStatusDetailsModel>> ListAsync()
        {
            var types_query = from ItemType in _aDMStore.ItemStatuses
                              select new ItemStatusDetailsModel
                              {
                                  Id = ItemType.Id,
                                  StatusName = ItemType.StatusName
                              };

            return await types_query.ToListAsync().ConfigureAwait(false);
        }
    }
}
