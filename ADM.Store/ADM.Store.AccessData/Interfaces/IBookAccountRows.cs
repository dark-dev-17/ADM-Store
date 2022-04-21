using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    public interface IBookAccountRows
    {
        public Task<bool> AddRowNewDetail();
        public Task<bool> UpdateRowDetail();
        public Task<bool> DeleteRowDetail(int idBookAccount, int idBookAccountDetails);
    }
}
