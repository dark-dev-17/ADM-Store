using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.PurchaseOrder;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces.Purchasing
{
    internal interface IPurchaseOrderItemRepository
    {
        public Task CreateAsync(PurchaseOrderItemCreateModel itemCreateModel);
        public Task DeleteAsync(PurchaseOrderItemDeleteModel itemDeleteModel);
        public Task UpdateAsync(PurchaseOrderItemUpdateModel itemUpdateModel);
    }
}
