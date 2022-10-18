using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.PurchaseOrder;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces.Purchasing
{
    internal interface IPurchaseOrderItemRepository
    {
        public Task CreateAsync(int docNum, PurchaseOrderItemCreateModel itemCreateModel);
        public Task CreateAsync(int docNum, List<PurchaseOrderItemCreateModel> listItemCreateModel);
        public Task DeleteAsync(PurchaseOrderItemDeleteModel itemDeleteModel);
        public Task DeleteAsync(List<PurchaseOrderItemDeleteModel> itemDeleteModel);
        public Task UpdateAsync(PurchaseOrderItemUpdateModel itemUpdateModel);
        public Task UpdateAsync(List<PurchaseOrderItemUpdateModel> itemUpdateModel);
    }
}
