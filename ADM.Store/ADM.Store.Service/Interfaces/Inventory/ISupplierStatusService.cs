using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.ItemType;
using ADM.Store.Models.Models.SupplierStatus;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces.Inventory
{
    internal interface ISupplierStatusService
    {
        public Task<int> CreateAsync(string statusName);
        public Task<SupplierStatusDetailsModel> DetailsAsync(int statusId);
        public Task<List<SupplierStatusDetailsModel>> ListAsync();
        public Task UpdateAsync(int statusId, string statusName);
    }
}
