using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Supplier;
using ADM.Store.AccessData.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using ADM.Store.Models.Models.SupplierStatus;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierRepository : ISupplierRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SupplierRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierCreate"></param>
        /// <returns></returns>
        public async Task<string> CreateAsync(SupplierCreateModel supplierCreate)
        {
            var newSupplier = new Supplier
            {
                CardCode = supplierCreate.CardCode,
                SuplierName = supplierCreate.SuplierName,
                Active = supplierCreate.Active,
                SupplierStatus = supplierCreate.SupplierStatus,
                // TODO service-user
                CreatedBy = "USER-SYS",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _aDMStore.Suppliers.AddAsync(newSupplier).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newSupplier.CardCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CardCode"></param>
        /// <returns></returns>
        public async Task<SupplierDetailsModel?> DetailsAsync(string CardCode)
        {
            var supplier_query = from supplier in _aDMStore.Suppliers join status in _aDMStore.SupplierStatusCats on supplier.SupplierStatus equals status.Id
                                 where supplier.CardCode == CardCode
                                 select new SupplierDetailsModel
                                 {
                                     CardCode = supplier.CardCode,
                                     SuplierName = supplier.SuplierName,
                                     CreatedAt = supplier.CreatedAt,
                                     UpdatedAt = supplier.UpdatedAt,
                                     Active = supplier.Active,
                                     CreatedBy = supplier.CreatedBy,
                                     Status =  new SupplierStatusDetailsModel
                                     {
                                         Id = status.Id,
                                         StatusName = status.StatusName
                                     }
                                 };
            return await supplier_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CardCode"></param>
        /// <returns></returns>
        public async Task<bool> ExistsByCardCodeAsync(string CardCode)
        {
            return await _aDMStore.Suppliers.AnyAsync(status => status.CardCode == CardCode).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        public async Task<string?> ExistsByNameAsync(string supplierName)
        {
            var supplier_query = from supplier in _aDMStore.Suppliers where supplier.SuplierName.ToLower() == supplierName.ToLower() select supplier.CardCode;

            return await supplier_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierDetailsModel>> ListAsync()
        {
            var supplier_query = from supplier in _aDMStore.Suppliers
                                 join status in _aDMStore.SupplierStatusCats on supplier.SupplierStatus equals status.Id
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
                                 };
            return await supplier_query.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public async Task<List<SupplierDetailsModel>> ListAsync(int statusId)
        {
            var supplier_query = from supplier in _aDMStore.Suppliers
                                 join status in _aDMStore.SupplierStatusCats on supplier.SupplierStatus equals status.Id
                                 where supplier.SupplierStatus == statusId
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
                                 };
            return await supplier_query.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierUpdate"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task UpdateAsync(SupplierUpdateModel supplierUpdate)
        {
            var supplier = await _aDMStore.Suppliers.FirstOrDefaultAsync(supplier => supplier.CardCode == supplierUpdate.CardCode).ConfigureAwait(false);
            if (supplier == null)
            {
                throw new NullReferenceException();
            }

            supplier.SuplierName = supplierUpdate.SuplierName;
            supplier.SupplierStatus = supplierUpdate.SupplierStatus;
            supplier.UpdatedAt = DateTime.Now;

        }
    }
}
