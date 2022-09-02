using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierLocationRepository : ISupplierLocationRepository
    {
        public Task<int> CreateAsync(SupplierLocationCreateModel supplierLocationCreate)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierLocationDetailsModel> DetailsAsync(int idSupplierLocation)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierLocationDetailsModel> DetailsAsync(string supplierLocationName)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsAsync(int idSupplierLocation)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsAsync(string supplierLocationName)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierLocationDetailsModel>> ListAsync(string cardCode)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SupplierLocationUpdateModel supplierLocationUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
