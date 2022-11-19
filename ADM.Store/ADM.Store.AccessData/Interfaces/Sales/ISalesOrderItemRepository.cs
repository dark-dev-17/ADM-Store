using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.SalesOrder;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces.Sales
{
    internal interface ISalesOrderItemRepository
    {
        public Task<int> CreateAsync(SalesOrderItemCreateModel itemCreateModel);
        public Task<SalesOrderItemDetailsModel?> DetailsAsync(int docNum, string itemCode);
        public Task DeleteAsync(int docNum, string itemCode);
        public Task<bool> ExistsInOrderAsync(int docNum, string itemCode);
        public Task<List<SalesOrderItemDetailsModel>> ListAsync(int docNum);
        public Task<decimal> TotalItemsAsync(int docNum);
        public Task UpdateAsync(SalesOrderItemUpdateModel itemUpdateModel);
    }
}
