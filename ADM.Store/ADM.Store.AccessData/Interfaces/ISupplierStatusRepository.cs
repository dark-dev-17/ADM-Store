using ADM.Store.Models.Models.SupplierStatus;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]

namespace ADM.Store.AccessData.Interfaces
{
    internal interface ISupplierStatusRepository
    {
        public Task<int> CreateAsync(string supplierStatusName);
        public Task<SupplierStatusDetailsModel?> DetailsAsync(int idSupplierStatus);
        public Task<SupplierStatusDetailsModel?> DetailsAsync(string supplierStatusName);
        public Task<int> ExistsAsync(int idSupplierStatus);
        public Task<int> ExistsAsync(string supplierStatusName);
        public Task<List<SupplierStatusDetailsModel>> ListAsync();
        public Task UpdateAsync(int idSupplierStatus, string supplierStatusName);
    }
}
