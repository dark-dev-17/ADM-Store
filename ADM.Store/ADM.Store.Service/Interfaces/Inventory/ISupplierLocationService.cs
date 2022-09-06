using ADM.Store.Models.Models.SupplierLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Service.Interfaces.Inventory
{
    internal interface ISupplierLocationService
    {
        public Task<SupplierLocationDetailsModel> CreateAsync(SupplierLocationCreateModel locationCreateModel);
        public Task<SupplierLocationDetailsModel> DetailsAsync(string cardCode, int idLocation);
        public Task<List<SupplierLocationDetailsModel>> ListAsync(string cardCode);
        public Task UpdateAsync(SupplierLocationUpdateModel locationUpdateModel);
    }
}
