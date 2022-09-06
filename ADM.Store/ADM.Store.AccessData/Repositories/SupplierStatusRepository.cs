using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierStatus;
using System.Runtime.CompilerServices;
using ADM.Store.AccessData.Entities;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierStatusRepository : ISupplierStatusRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SupplierStatusRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierStatusName"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(string supplierStatusName)
        {
            var newSupplierStatus = new SupplierStatusCat()
            {
                StatusName = supplierStatusName,
            };
            await _aDMStore.SupplierStatusCats.AddAsync(newSupplierStatus).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newSupplierStatus.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierStatus"></param>
        /// <returns></returns>
        public async Task<SupplierStatusDetailsModel?> DetailsAsync(int idSupplierStatus)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.Id == idSupplierStatus
                                       select new SupplierStatusDetailsModel()
                                       {
                                           Id = status.Id,
                                           StatusName = status.StatusName,
                                       };

            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierStatusName"></param>
        /// <returns></returns>
        public async Task<SupplierStatusDetailsModel?> DetailsAsync(string supplierStatusName)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.StatusName == supplierStatusName
                                       select new SupplierStatusDetailsModel()
                                       {
                                           Id = status.Id,
                                           StatusName = status.StatusName,
                                       };

            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierStatus"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(int idSupplierStatus)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.Id == idSupplierStatus
                                       select status.Id;
            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierStatusName"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(string supplierStatusName)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.StatusName == supplierStatusName
                                       select status.Id;
            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierStatusDetailsModel>> ListAsync()
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       select new SupplierStatusDetailsModel()
                                       {
                                           Id = status.Id,
                                           StatusName = status.StatusName,
                                       };

            return await supplierStatus_query.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierStatus"></param>
        /// <param name="supplierStatusName"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task UpdateAsync(int idSupplierStatus, string supplierStatusName)
        {
            var supplierStatus = await _aDMStore.SupplierStatusCats.FirstOrDefaultAsync(status => status.Id == idSupplierStatus).ConfigureAwait(false);

            if (supplierStatus == null)
            {
                throw new NullReferenceException();
            }
            supplierStatus.StatusName = supplierStatusName;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
