using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.SupplierContact;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces.Inventory
{
    internal interface ISupplierContactService
    {
        public Task<SupplierContactDetailsModel> CreateAsync(string cardCode, SupplierContactCreateModel newContact);
        public Task<SupplierContactDetailsModel> DetailsAsync(string cardCode, int idContact);
        public Task<List<SupplierContactDetailsModel>> ListAsync(string cardCode);
        public Task UpdateAsync(string cardCode,SupplierContactUpdateModel newContact);
    }
}
