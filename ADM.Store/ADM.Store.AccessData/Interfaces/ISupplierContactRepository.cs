using ADM.Store.Models.Models.SupplierContact;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]

namespace ADM.Store.AccessData.Interfaces
{
    internal interface ISupplierContactRepository
    {
        public Task<int> CreateAsync(SupplierContactCreateModel contactCreateModel);
        public Task<SupplierContactDetailsModel?> DetailsAsync(int idSupplierContact);
        public Task<SupplierContactDetailsModel?> DetailsAsync(string nameSupplierContact);
        public Task<int> ExistsAsync(int idSupplierContact);
        public Task<int> ExistsAsync(string nameSupplierContact);
        public Task<List<SupplierContactDetailsModel>> ListAsync(string cardCode);
        public Task UpdateAsync(SupplierContactUpdateModel contactUpdateModel);
        public Task DeleteAsync(int idSupplierContact);
    }
}
