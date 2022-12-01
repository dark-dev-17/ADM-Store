using ADM.Store.Models.Models.BussinesAccount;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IBussinesAccountService
    {
        public Task<int> CreateAsync(BussinesAccountCreateModel bussinesAccountCreate);
        public Task<BussinesAccountDetailsModel?> DetailsAsync(int idBussinesAccount);
        public Task<List<BussinesAccountDetailsModel>> ListAsync();
        public Task<List<BussinesAccountHistoryDetailsModel>> GetHistory(int idBussinesAccount);
        public Task UpdateAsync(BussinesAccountUpdateModel bussinesAccountUpdate);
    }
}
