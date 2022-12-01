using ADM.Store.Models.Models.BussinesAccount;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IBussinesAccountRepository
    {
        public Task<int> CreateAsync(string name, string comments);
        public Task<List<BussinesAccountDetailsModel>> ListAsync();
        public Task<int> UpdateAsync(int idBussinesAccount,string name, string comments);
        public Task AddHistoryLine(int idBussinesAccount, decimal total, BussinesAccountHistoryType historyType, BussinesAccountDocRefType docRefType, int docRefNum, string comments);
        public Task<List<BussinesAccountHistoryDetailsModel>> GetHistory(int idBussinesAccoun);
    }

    internal enum BussinesAccountHistoryType
    {
        entrada,
        salida
    }

    internal enum BussinesAccountDocRefType
    {
        incommingPayment,
        outCommingPayment
    }
}
