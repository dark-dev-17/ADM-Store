using ADM.Store.Models.Models.Supplier;
using ADM.Store.Models.Models.SupplierLocation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]

namespace ADM.Store.Service.Interfaces.Inventory
{
    internal interface ISupplierService
    {
        public Task<SupplierDetailsModel> CreateAsync(SupplierCreateModel newSupplier);
        public Task<SupplierDetailsModel> DetailsAsync(string cardCode);
        public Task<List<SupplierDetailsModel>> ListAsync();
        public Task UpdateAsync(string cardCode,SupplierUpdateModel newSupplier);
    }
}
