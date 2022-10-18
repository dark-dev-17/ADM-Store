using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.PurchaseOrder;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces.Purchasing
{
    internal interface IPurchaseOrderRepository
    {
        public Task<int> CreateAsync(string cardCode, int locationId, int contactId, string statusId);
        public Task<PurchaseOrderDetailsModel?> DetailsAsync(int docNum);
        public Task DeleteAsync(int docNum);
        public Task<bool> ExistsAsync(int docNum);
        public Task<List<PurchaseOrderBasicDetailsModel>> ListAsync();
        public Task UpdateDocTotal(int docNum);
        public Task UpdateAsync(int docNum, string cardCode, int locationId, int contactId, string statusId);
    }
}
