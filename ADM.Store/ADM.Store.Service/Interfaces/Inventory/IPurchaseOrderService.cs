using ADM.Store.Models.Models.PurchaseOrder;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces.Inventory
{
    internal interface IPurchaseOrderService
    {
        public Task<PurchaseOrderDetailsModel> DetailsAsync(int docNum);
        public Task<int> CreateAsync(PurchaseOrderCreateModel orderCreateModel);
        public Task<List<PurchaseOrderBasicDetailsModel>> ListAsync();
        public Task UpdateAsync(int docNum, PurchaseOrderUpdateModel orderUpdateModel);
        public Task<PurchaseOrderItemDetailsModel?> DetailsItemAsync(string itemCode);
    }
}
