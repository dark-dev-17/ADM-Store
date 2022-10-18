using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces.Purchasing;
using ADM.Store.Models.Models.PurchaseOrder;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories.Purchasing
{
    internal class PurchaseOrderItemRepository : IPurchaseOrderItemRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public PurchaseOrderItemRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task CreateAsync(int docNum, PurchaseOrderItemCreateModel itemCreateModel)
        {
            var newItem = SetCreate(docNum, itemCreateModel);

            await _aDMStore.PurchaseOrderItems.AddAsync(newItem).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CreateAsync(int docNum, List<PurchaseOrderItemCreateModel> listItemCreateModel)
        {
            if (listItemCreateModel != null && listItemCreateModel.Count > 0)
            {
                listItemCreateModel.ForEach(async item =>
                {
                    var newItem = SetCreate(docNum, item);
                    await _aDMStore.PurchaseOrderItems.AddAsync(newItem).ConfigureAwait(false);
                });
                    await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private PurchaseOrderItem SetCreate(int docNum, PurchaseOrderItemCreateModel itemCreateModel)
        {
            return new PurchaseOrderItem
            {
                DocNum = docNum,
                ItemCode = itemCreateModel.ItemCode,
                Variation = itemCreateModel.Variation,
                LineNum = itemCreateModel.LineNum,
                UnitPrice = itemCreateModel.UnitPrice,
                Quantity = itemCreateModel.Quantity,
                Total = itemCreateModel.UnitPrice * itemCreateModel.Quantity,
                Comments = itemCreateModel.Comments,
                Reference1 = itemCreateModel.Reference1,
                Reference2 = itemCreateModel.Reference2,
                TypeItem = itemCreateModel.TypeItem,
                // TODO service-user
                CreatedBy = "USER-SYS",
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            };
        }

        public async Task DeleteAsync(PurchaseOrderItemDeleteModel itemDeleteModel)
        {
            var ItemDetails = await _aDMStore.PurchaseOrderItems.FirstOrDefaultAsync(item =>
            item.DocNum == itemDeleteModel.DocNum &&
            item.ItemCode == itemDeleteModel.ItemCode &&
            item.Variation == itemDeleteModel.Variation)
                .ConfigureAwait(false);

            if (ItemDetails == null)
            {
                throw new NullReferenceException(nameof(ItemDetails));
            }

            _aDMStore.PurchaseOrderItems.Remove(ItemDetails);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task DeleteAsync(List<PurchaseOrderItemDeleteModel> itemDeleteModel)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PurchaseOrderItemUpdateModel itemUpdateModel)
        {
            var ItemDetails = await _aDMStore.PurchaseOrderItems.FirstOrDefaultAsync(item =>
            item.DocNum == itemUpdateModel.DocNum &&
            item.ItemCode == itemUpdateModel.ItemCode &&
            item.Variation == itemUpdateModel.Variation)
                .ConfigureAwait(false);

            if(ItemDetails == null)
            {
                throw new NullReferenceException(nameof(ItemDetails));
            }


            ItemDetails.ItemCode = itemUpdateModel.ItemCode;
            ItemDetails.Variation = itemUpdateModel.Variation;
            ItemDetails.UnitPrice = itemUpdateModel.UnitPrice;
            ItemDetails.Quantity = itemUpdateModel.Quantity;
            ItemDetails.Total = ItemDetails.UnitPrice * ItemDetails.Quantity;
            ItemDetails.LineNum = itemUpdateModel.LineNum;
            ItemDetails.Reference1 = itemUpdateModel.Reference1;
            ItemDetails.Reference2 = itemUpdateModel.Reference2;
            ItemDetails.Comments = itemUpdateModel.Comments;
            ItemDetails.CreatedAt = DateTime.Now;
            ItemDetails.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task UpdateAsync(List<PurchaseOrderItemUpdateModel> itemUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
