using ADM.Store.Models.Models.Customer;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces.Sales
{
    internal interface ICustomerRepository
    {
        public Task<int> CreateAsync(string firstName,string lastName,string phoneNumber, string emailAddress);
        public Task<CustomerDetailsModel?> DetailsAsync(int customerNumber);
        public Task<List<CustomerDetailsModel>> ListAsync();
        public Task DeleteAsync(int id);
        public Task UpdateAsync(CustomerUpdateModel customerUpdate);
    }
}
