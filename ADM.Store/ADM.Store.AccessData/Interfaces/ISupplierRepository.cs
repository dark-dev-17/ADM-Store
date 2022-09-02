using ADM.Store.Models.Models.Supplier;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ISupplierRepository
    {
        public Task<int> CreateAsync(string supplierName);
        public Task<SupplierDetailsModel?> DetailsAsync(string CardCode);
        public Task<int> ExistsByNameAsync(string supplierName);
        public Task<int> ExistsByCardCodeAsync(string CardCode);
        public Task<List<SupplierDetailsModel>> ListAsync();
        public Task<List<SupplierDetailsModel>> ListAsync(int statusId);
        public Task UpdateAsync(string cardCode, string supplierName);

    }
}
