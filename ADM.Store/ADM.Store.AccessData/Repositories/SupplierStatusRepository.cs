using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<int> ExistsAsync(int idSupplierStatus)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.Id == idSupplierStatus
                                       select status.Id;
            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> ExistsAsync(string supplierStatusName)
        {
            var supplierStatus_query = from status in _aDMStore.SupplierStatusCats
                                       where status.StatusName == supplierStatusName
                                       select status.Id;
            return await supplierStatus_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

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

        public async Task UpdateAsync(int idSupplierStatus, string supplierStatusName)
        {
            var supplierStatus = await _aDMStore.SupplierStatusCats.FirstOrDefaultAsync(status => status.Id == idSupplierStatus).ConfigureAwait(false);

            if (supplierStatus == null)
            {
                throw new NullReferenceException(nameof(SupplierStatusCat));
            }
            supplierStatus.StatusName = supplierStatusName;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

        }
    }
}
