using ADM.Store.Models.Models.ItemStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemStatusRepository
    {
        public Task<ItemStatusDetailsModel?> Details(int id);
        public Task<int> GetByName(string name);
        public Task<List<ItemStatusDetailsModel>> ListAsync();
    }
}
