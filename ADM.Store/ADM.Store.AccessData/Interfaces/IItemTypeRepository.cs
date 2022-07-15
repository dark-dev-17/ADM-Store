using ADM.Store.Models.Models.ItemType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemTypeRepository
    {
        public Task<ItemTypeDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemTypeDetailsModel>> ListAsync();
    }
}
