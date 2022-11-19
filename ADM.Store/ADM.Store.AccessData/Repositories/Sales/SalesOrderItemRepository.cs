using ADM.Store.AccessData.Interfaces.Sales;
using ADM.Store.Models.Models.SalesOrder;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories.Sales
{
    internal class SalesOrderItemRepository : ISalesOrderItemRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SalesOrderItemRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        public Task<int> CreateAsync(SalesOrderItemCreateModel itemCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int docNum, string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task<SalesOrderItemDetailsModel?> DetailsAsync(int docNum, string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsInOrderAsync(int docNum, string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesOrderItemDetailsModel>> ListAsync(int docNum)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> TotalItemsAsync(int docNum)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SalesOrderItemUpdateModel itemUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
