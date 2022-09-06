using ADM.Store.Models.Models.Supplier;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ISupplierRepository
    {
        public Task<string> CreateAsync(SupplierCreateModel supplierCreate);
        public Task<SupplierDetailsModel?> DetailsAsync(string CardCode);
        public Task<string?> ExistsByNameAsync(string supplierName);
        public Task<bool> ExistsByCardCodeAsync(string CardCode);
        public Task<List<SupplierDetailsModel>> ListAsync();
        public Task<List<SupplierDetailsModel>> ListAsync(int statusId);
        public Task UpdateAsync(SupplierUpdateModel supplierUpdate);

    }
}
