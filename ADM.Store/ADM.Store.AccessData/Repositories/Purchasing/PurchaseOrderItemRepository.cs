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
                LineNum = itemCreateModel.LineNum,
                UnitPrice = itemCreateModel.UnitPrice,
                Quantity = itemCreateModel.Quantity,
                Total = itemCreateModel.UnitPrice * itemCreateModel.Quantity,
                Comments = itemCreateModel.Comments,
                Reference1 = itemCreateModel.Reference1,
                Reference2 = itemCreateModel.Reference2,
                WeightItem = itemCreateModel.WeightItem,
                PublicPrice = itemCreateModel.PublicPrice,
                PriceByGrs = itemCreateModel.PriceByGrs,
                FactorRevenue = itemCreateModel.FactorRevenue,
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
            item.ItemCode == itemDeleteModel.ItemCode)
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
            item.ItemCode == itemUpdateModel.ItemCode)
                .ConfigureAwait(false);

            if(ItemDetails == null)
            {
                throw new NullReferenceException(nameof(ItemDetails));
            }


            ItemDetails.ItemCode = itemUpdateModel.ItemCode;
            ItemDetails.UnitPrice = itemUpdateModel.UnitPrice;
            ItemDetails.Quantity = itemUpdateModel.Quantity;
            ItemDetails.Total = ItemDetails.UnitPrice * ItemDetails.Quantity;
            ItemDetails.LineNum = itemUpdateModel.LineNum;
            ItemDetails.Reference1 = itemUpdateModel.Reference1;
            ItemDetails.Reference2 = itemUpdateModel.Reference2;
            ItemDetails.WeightItem = itemUpdateModel.WeightItem;
            ItemDetails.PriceByGrs = itemUpdateModel.PriceByGrs;
            ItemDetails.FactorRevenue = itemUpdateModel.FactorRevenue;
            ItemDetails.Comments = itemUpdateModel.Comments;
            ItemDetails.PublicPrice = itemUpdateModel.PublicPrice;
            //ItemDetails.CreatedAt = DateTime.Now;
            ItemDetails.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task UpdateAsync(List<PurchaseOrderItemUpdateModel> itemUpdateModel)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseOrderItemDetailsModel?> DetailsAsync(string itemCode)
        {
            var qr_detailsItem = from items in _aDMStore.PurchaseOrderItems
                                 where items.Reference1 == itemCode
                                 select new PurchaseOrderItemDetailsModel
                                 {
                                     Comments = items.Comments,
                                     CreatedAt = items.CreatedAt,
                                     CreatedBy = items.CreatedBy,
                                     ItemCode = items.ItemCode,
                                     LineNum = items.LineNum,
                                     Quantity = items.Quantity,
                                     Reference1 = items.Reference1,
                                     Reference2 = items.Reference2,
                                     Total = items.Total,
                                     PriceByGrs = items.PriceByGrs,
                                     WeightItem = items.WeightItem,
                                     FactorRevenue = items.FactorRevenue,
                                     UnitPrice = items.UnitPrice,
                                     UpdatedAt = items.UpdatedAt,
                                     PublicPrice = items.PublicPrice,
                                     IsSold = items.IsSold,
                                 };

            return await qr_detailsItem.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public void MoveToStolenAsync(string itemCode, bool isStolen)
        {
            var ItemDetails = _aDMStore.PurchaseOrderItems.FirstOrDefault(item => item.Reference1 == itemCode);

            if (ItemDetails == null)
            {
                throw new NullReferenceException(nameof(ItemDetails));
            }

            ItemDetails.IsSold = isStolen;
            //ItemDetails.CreatedAt = DateTime.Now;
            ItemDetails.UpdatedAt = DateTime.Now;

            _aDMStore.SaveChanges();
        }
    }
}
