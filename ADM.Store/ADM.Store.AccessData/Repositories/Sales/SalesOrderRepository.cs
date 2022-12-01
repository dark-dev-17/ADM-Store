using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces.Sales;
using ADM.Store.Models.Models.SalesOrder;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories.Sales
{
    internal class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SalesOrderRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task ChangeStatusAsync(int docNum, string status)
        {
            var orderRegistered = await _aDMStore.SalesOrders.FirstOrDefaultAsync(customer => customer.DocNum == docNum).ConfigureAwait(false);

            if (orderRegistered == null)
            {
                throw new NullReferenceException(nameof(orderRegistered));
            }

            orderRegistered.DocStatus = status;
            orderRegistered.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CreateAsync(int customerNumber,DateTime docDate,int docType, string docStatus)
        {
            var newSalesOrder = new SalesOrder
            {
                DocDate = docDate,
                DocStatus = docStatus,
                DocTotal = 0,
                DocType = docType,
                Customer = customerNumber,
                Canceled = false,
                CanceledBy = string.Empty,
                CandeledDate = DateTime.Now,
                // TODO service-user
                CreatedBy = "USER-SYS",
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            };

            await _aDMStore.SalesOrders.AddAsync(newSalesOrder).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newSalesOrder.DocNum;
        }

        public async Task<SalesOrderDetailsModel?> DetailsAsync(int docNum)
        {
            var qr_salesOrder = from salesOrder in _aDMStore.SalesOrders
                                where salesOrder.DocNum == docNum
                                select new SalesOrderDetailsModel
                                {
                                    DocNum = salesOrder.DocNum,
                                    DocDate = salesOrder.DocDate,
                                    DocStatus = salesOrder.DocStatus,
                                    DocTotal = salesOrder.DocTotal,
                                    DocType = salesOrder.DocType,
                                    Canceled = salesOrder.Canceled,
                                    CanceledBy = salesOrder.CanceledBy,
                                    CandeledDate = salesOrder.CandeledDate,
                                    CreatedBy = salesOrder.CreatedBy,
                                    UpdatedAt = salesOrder.UpdatedAt,
                                    CreatedAt = salesOrder.CreatedAt,
                                    Customer = new Models.Models.Customer.CustomerDetailsModel
                                    {
                                        Id = salesOrder.CustomerNavigation.Id,
                                        LastName = salesOrder.CustomerNavigation.LastName,
                                        Email = salesOrder.CustomerNavigation.Email,
                                        FirtName = salesOrder.CustomerNavigation.FirtName,
                                        PhoneNumber = salesOrder.CustomerNavigation.PhoneNumber,
                                        Group1 = salesOrder.CustomerNavigation.Group1,
                                        Group2 = salesOrder.CustomerNavigation.Group2,
                                        Group3 = salesOrder.CustomerNavigation.Group3,
                                        CreatedBy = salesOrder.CustomerNavigation.CreatedBy,
                                        CreatedAt = salesOrder.CustomerNavigation.CreatedAt,
                                        UpdatedAt = salesOrder.CustomerNavigation.UpdatedAt
                                    }
                                };

            return await qr_salesOrder.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<SalesOrderDetailsModel>> List()
        {
            var qr_salesOrder = from salesOrder in _aDMStore.SalesOrders
                                select new SalesOrderDetailsModel
                                {
                                    DocNum = salesOrder.DocNum,
                                    DocDate = salesOrder.DocDate,
                                    DocStatus = salesOrder.DocStatus,
                                    DocTotal = salesOrder.DocTotal,
                                    DocType = salesOrder.DocType,
                                    Canceled = salesOrder.Canceled,
                                    CanceledBy = salesOrder.CanceledBy,
                                    CandeledDate = salesOrder.CandeledDate,
                                    CreatedBy = salesOrder.CreatedBy,
                                    UpdatedAt = salesOrder.UpdatedAt,
                                    CreatedAt = salesOrder.CreatedAt,
                                    Customer = new Models.Models.Customer.CustomerDetailsModel
                                    {
                                        Id = salesOrder.CustomerNavigation.Id,
                                        LastName = salesOrder.CustomerNavigation.LastName,
                                        Email = salesOrder.CustomerNavigation.Email,
                                        FirtName = salesOrder.CustomerNavigation.FirtName,
                                        PhoneNumber = salesOrder.CustomerNavigation.PhoneNumber,
                                        Group1 = salesOrder.CustomerNavigation.Group1,
                                        Group2 = salesOrder.CustomerNavigation.Group2,
                                        Group3 = salesOrder.CustomerNavigation.Group3,
                                        CreatedBy = salesOrder.CustomerNavigation.CreatedBy,
                                        CreatedAt = salesOrder.CustomerNavigation.CreatedAt,
                                        UpdatedAt = salesOrder.CustomerNavigation.UpdatedAt
                                    }
                                };

            return await qr_salesOrder.ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<SalesOrderDetailsModel>> List(string status)
        {
            var qr_salesOrder = from salesOrder in _aDMStore.SalesOrders
                                where salesOrder.DocStatus == status
                                select new SalesOrderDetailsModel
                                {
                                    DocNum = salesOrder.DocNum,
                                    DocDate = salesOrder.DocDate,
                                    DocStatus = salesOrder.DocStatus,
                                    DocTotal = salesOrder.DocTotal,
                                    DocType = salesOrder.DocType,
                                    Canceled = salesOrder.Canceled,
                                    CanceledBy = salesOrder.CanceledBy,
                                    CandeledDate = salesOrder.CandeledDate,
                                    CreatedBy = salesOrder.CreatedBy,
                                    UpdatedAt = salesOrder.UpdatedAt,
                                    CreatedAt = salesOrder.CreatedAt,
                                    Customer = new Models.Models.Customer.CustomerDetailsModel
                                    {
                                        Id = salesOrder.CustomerNavigation.Id,
                                        LastName = salesOrder.CustomerNavigation.LastName,
                                        Email = salesOrder.CustomerNavigation.Email,
                                        FirtName = salesOrder.CustomerNavigation.FirtName,
                                        PhoneNumber = salesOrder.CustomerNavigation.PhoneNumber,
                                        Group1 = salesOrder.CustomerNavigation.Group1,
                                        Group2 = salesOrder.CustomerNavigation.Group2,
                                        Group3 = salesOrder.CustomerNavigation.Group3,
                                        CreatedBy = salesOrder.CustomerNavigation.CreatedBy,
                                        CreatedAt = salesOrder.CustomerNavigation.CreatedAt,
                                        UpdatedAt = salesOrder.CustomerNavigation.UpdatedAt
                                    }
                                };

            return await qr_salesOrder.ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<SalesOrderDetailsModel>> List(int customerNumber)
        {
            var qr_salesOrder = from salesOrder in _aDMStore.SalesOrders
                                where salesOrder.Customer == customerNumber
                                select new SalesOrderDetailsModel
                                {
                                    DocNum = salesOrder.DocNum,
                                    DocDate = salesOrder.DocDate,
                                    DocStatus = salesOrder.DocStatus,
                                    DocTotal = salesOrder.DocTotal,
                                    DocType = salesOrder.DocType,
                                    Canceled = salesOrder.Canceled,
                                    CanceledBy = salesOrder.CanceledBy,
                                    CandeledDate = salesOrder.CandeledDate,
                                    CreatedBy = salesOrder.CreatedBy,
                                    UpdatedAt = salesOrder.UpdatedAt,
                                    CreatedAt = salesOrder.CreatedAt,
                                    Customer = new Models.Models.Customer.CustomerDetailsModel
                                    {
                                        Id = salesOrder.CustomerNavigation.Id,
                                        LastName = salesOrder.CustomerNavigation.LastName,
                                        Email = salesOrder.CustomerNavigation.Email,
                                        FirtName = salesOrder.CustomerNavigation.FirtName,
                                        PhoneNumber = salesOrder.CustomerNavigation.PhoneNumber,
                                        Group1 = salesOrder.CustomerNavigation.Group1,
                                        Group2 = salesOrder.CustomerNavigation.Group2,
                                        Group3 = salesOrder.CustomerNavigation.Group3,
                                        CreatedBy = salesOrder.CustomerNavigation.CreatedBy,
                                        CreatedAt = salesOrder.CustomerNavigation.CreatedAt,
                                        UpdatedAt = salesOrder.CustomerNavigation.UpdatedAt
                                    }
                                };

            return await qr_salesOrder.ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(SalesOrderUpdateModel orderUpdateModel)
        {
            var orderRegistered = await _aDMStore.SalesOrders.FirstOrDefaultAsync(customer => customer.DocNum == orderUpdateModel.DocNum).ConfigureAwait(false);

            if (orderRegistered == null)
            {
                throw new NullReferenceException(nameof(orderRegistered));
            }

            orderRegistered.DocDate = orderUpdateModel.DocDate;
            orderRegistered.DocStatus = orderUpdateModel.DocStatus;
            orderRegistered.DocTotal = orderUpdateModel.DocTotal;
            orderRegistered.DocType = orderUpdateModel.DocType;
            orderRegistered.Customer = orderUpdateModel.Customer;
            orderRegistered.Canceled = orderUpdateModel.Canceled;
            orderRegistered.CanceledBy = orderUpdateModel.CanceledBy;
            orderRegistered.CandeledDate = orderUpdateModel.CandeledDate;
            orderRegistered.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateTotalAsync(int docNum)
        {
            var orderRegistered = await _aDMStore.SalesOrders.FirstOrDefaultAsync(customer => customer.DocNum == docNum).ConfigureAwait(false);

            if (orderRegistered == null)
            {
                throw new NullReferenceException(nameof(orderRegistered));
            }

            orderRegistered.DocTotal = await _aDMStore.SalesOrderItems.Where(line => line.DocNum == docNum).SumAsync(line => line.Total).ConfigureAwait(false);
            orderRegistered.UpdatedAt = DateTime.Now;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
