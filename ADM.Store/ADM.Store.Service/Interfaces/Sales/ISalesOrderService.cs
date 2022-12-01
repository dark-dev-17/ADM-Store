using ADM.Store.Models.Models.SalesOrder;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces.Sales
{
    internal interface ISalesOrderService
    {
        public Task<int> CreateAsync(SalesOrderCreateModel salesOrderCreate);
        public Task<SalesOrderDetailsFullModel> GetAsync(int docNum);
        public Task<List<SalesOrderDetailsModel>> ListAsync();
        public Task<List<SalesOrderDetailsModel>> ListAsync(int customerNumber);
        public Task<List<SalesOrderDetailsModel>> ListAsync(string status);
        public Task UpdateAsync(SalesOrderUpdateModel salesOrderUpdate);
        public Task CancelAsync(int docNum);
        public Task CompleteAsync(int docNum);
        public Task<List<SalesOrderItemDetailsModel>> ListLine(int docNum);
        public Task AddLine(SalesOrderItemCreateModel itemCreate);
        public Task<SalesOrderItemDetailsModel> DetailsLine(int docNum, string itemCode);
        public Task DeleteLine(int docNum, string itemCode);
        public Task UpdateLine(SalesOrderItemUpdateModel itemUpdate);
    }
}
