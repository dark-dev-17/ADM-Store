using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces.Purchasing;
using ADM.Store.Models.Models.PurchaseOrder;
using ADM.Store.Models.Models.Supplier;
using ADM.Store.Models.Models.SupplierContact;
using ADM.Store.Models.Models.SupplierLocation;
using ADM.Store.Models.Models.SupplierStatus;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]

namespace ADM.Store.AccessData.Repositories.Purchasing
{
    internal class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public PurchaseOrderRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<int> CreateAsync(string cardCode, int locationId, int contactId, string statusId)
        {
            var newPurchaseOrder = new PurchaseOrder
            {
                DocTotal = 0,
                DocDate = DateTime.Now,
                DocStatus = statusId,
                Supplier = cardCode,
                SupplierLocation = locationId,
                SupplierContact = contactId,
                Canceled = false,
                CanceledBy = "",
                CandeledDate = DateTime.Now,
                // TODO service-user
                CreatedBy = "USER-SYS",
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            };

            await _aDMStore.PurchaseOrders.AddAsync(newPurchaseOrder).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newPurchaseOrder.DocNum;
        }

        public Task DeleteAsync(int docNum)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseOrderDetailsModel?> DetailsAsync(int docNum)
        {
            var queryPurchaseOrder = from order in _aDMStore.PurchaseOrders
                                     where order.DocNum == docNum
                                     let supplier_jq = (from supplier in _aDMStore.Suppliers
                                                       join status in _aDMStore.SupplierStatusCats on supplier.SupplierStatus equals status.Id
                                                       where supplier.CardCode == order.Supplier
                                                       select new SupplierDetailsModel
                                                       {
                                                           CardCode = supplier.CardCode,
                                                           SuplierName = supplier.SuplierName,
                                                           CreatedAt = supplier.CreatedAt,
                                                           UpdatedAt = supplier.UpdatedAt,
                                                           Active = supplier.Active,
                                                           CreatedBy = supplier.CreatedBy,
                                                           Status = new SupplierStatusDetailsModel
                                                           {
                                                               Id = status.Id,
                                                               StatusName = status.StatusName
                                                           }
                                                       }).First()
                                     let items_jq = (from items in _aDMStore.PurchaseOrderItems
                                                    where items.DocNum == docNum
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
                                                        UnitPrice = items.UnitPrice,
                                                        UpdatedAt= items.UpdatedAt,
                                                        Variation = items.Variation
                                                    }).ToList()
                                     select new PurchaseOrderDetailsModel
                                     {
                                         Supplier = supplier_jq,
                                         CardCode = order.Supplier,
                                         Canceled = order.Canceled,
                                         CandeledDate = order.CandeledDate,
                                         CreatedBy = order.CreatedBy,
                                         DocDate = order.DocDate,
                                         DocNum = order.DocNum,
                                         DocStatus = order.DocStatus,
                                         UpdatedAt = order.UpdatedAt,
                                         CanceledBy = order.CanceledBy,
                                         CreatedAt = order.CreatedAt,
                                         DocTotal = order.DocTotal,
                                         Items = items_jq,
                                         Contact = new SupplierContactDetailsModel
                                         {
                                             CardCode = order.SupplierContactNavigation.CardCode,
                                             SupplierName = order.SupplierContactNavigation.SupplierName,
                                             PhoneNumber = order.SupplierContactNavigation.PhoneNumber,
                                             CreatedAt = order.SupplierContactNavigation.CreatedAt,
                                             Active = order.SupplierContactNavigation.Active,
                                             CreatedBy = order.SupplierContactNavigation.CreatedBy,
                                             Id = order.SupplierContactNavigation.Id
                                         },
                                         Location = new SupplierLocationDetailsModel
                                         {
                                             Id = order.SupplierLocationNavigation.Id,
                                             CardCode = order.SupplierLocationNavigation.CardCode,
                                             LocationName = order.SupplierLocationNavigation.LocationName,
                                             LocationAddress = order.SupplierLocationNavigation.LocationAddress,
                                             Active = order.SupplierLocationNavigation.Active,
                                             CreatedAt = order.SupplierLocationNavigation.CreatedAt,
                                             UpdatedAt = order.SupplierLocationNavigation.UpdatedAt,
                                             StateName = order.SupplierLocationNavigation.StateName,
                                             CreatedBy = order.SupplierLocationNavigation.CreatedBy,
                                             Town = order.SupplierLocationNavigation.Town,
                                             ReferencesCo = order.SupplierLocationNavigation.ReferencesCo,
                                             ZipCode = order.SupplierLocationNavigation.ZipCode
                                         }
        };

            return await queryPurchaseOrder.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(int docNum)
        {
            return await _aDMStore.PurchaseOrders.AnyAsync(order => order.DocNum == docNum).ConfigureAwait(false);
        }

        public async Task<List<PurchaseOrderBasicDetailsModel>> ListAsync()
        {
            var queryPurchaseOrder = from order in _aDMStore.PurchaseOrders
                                     let supplier_jq = (from supplier in _aDMStore.Suppliers
                                                       where supplier.CardCode == order.Supplier
                                                       select new SupplierDetailsModel
                                                       {
                                                           CardCode = supplier.CardCode,
                                                           SuplierName = supplier.SuplierName,
                                                           CreatedAt = supplier.CreatedAt,
                                                           UpdatedAt = supplier.UpdatedAt,
                                                           Active = supplier.Active,
                                                           CreatedBy = supplier.CreatedBy,
                                                           Status = new SupplierStatusDetailsModel
                                                           {
                                                               //Id = status.Id,
                                                               //StatusName = status.StatusName
                                                           }
                                                       }).First()
                                     select new PurchaseOrderBasicDetailsModel
                                     {
                                         Supplier = supplier_jq,
                                         CardCode = order.Supplier,
                                         Canceled = order.Canceled,
                                         CandeledDate = order.CandeledDate,
                                         CreatedBy = order.CreatedBy,
                                         DocDate = order.DocDate,
                                         DocNum = order.DocNum,
                                         DocStatus = order.DocStatus,
                                         DocTotal = order.DocTotal,
                                         UpdatedAt = order.UpdatedAt,
                                     };

            return await queryPurchaseOrder.ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(int docNum, string cardCode, int locationId, int contactId, string statusId)
        {
            var purchaseOrder = await _aDMStore.PurchaseOrders.FirstOrDefaultAsync(order => order.DocNum == docNum).ConfigureAwait(false);
            if (purchaseOrder == null)
            {
                throw new NullReferenceException(nameof(purchaseOrder));
            }

            //var totalLines = await _aDMStore.PurchaseOrderItems.Where(order => order.DocNum == docNum).SumAsync(line => (line.UnitPrice * line.Quantity)).ConfigureAwait(false);

            purchaseOrder.DocStatus = statusId;
            purchaseOrder.Supplier = cardCode;
            purchaseOrder.SupplierLocation = locationId;
            purchaseOrder.SupplierContact = contactId;
            //purchaseOrder.DocTotal = totalLines;
            purchaseOrder.UpdatedAt = DateTime.Now;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateDocTotal(int docNum)
        {
            var purchaseOrder = await _aDMStore.PurchaseOrders.FirstOrDefaultAsync(order => order.DocNum == docNum).ConfigureAwait(false);
            if (purchaseOrder == null)
            {
                throw new NullReferenceException(nameof(purchaseOrder));
            }

            var totalLines = await _aDMStore.PurchaseOrderItems.Where(order => order.DocNum == docNum).SumAsync(line => (line.UnitPrice * line.Quantity)).ConfigureAwait(false);

            purchaseOrder.DocTotal = totalLines;
            purchaseOrder.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
