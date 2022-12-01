using ADM.Store.Models.Models.Customer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces.Sales
{
    internal interface ICustomerService
    {
        public Task<CustomerDetailsModel?> GetAsync(int customerNumber);
        public Task<CustomerDetailsModel?> GetAsync(string firstName, string lastName);
        public Task<List<CustomerDetailsModel>> ListAsync();
        public Task<int> CreateAsync(CustomerCreateModel customerCreate);
        public Task UpdateAsync(CustomerUpdateModel customerUpdate);
    }
}
