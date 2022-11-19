using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces.Sales;
using ADM.Store.Models.Models.Customer;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories.Sales
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public CustomerRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<int> CreateAsync(string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            var newCustomer = new Customer
            {
                LastName = lastName,
                Email = emailAddress,
                FirtName = firstName,
                PhoneNumber = phoneNumber,
                Group1 = 0,
                Group2 = 0,
                Group3 = 0,
                // TODO service-user
                CreatedBy = "USER-SYS",
                UpdatedAt = DateTime.Now,
                CreatedAt = DateTime.Now,
            };

            await _aDMStore.Customers.AddAsync(newCustomer).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newCustomer.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var customerRegistered = await GetDetails(id).ConfigureAwait(false);

            _aDMStore.Customers.Remove(customerRegistered);

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<CustomerDetailsModel?> DetailsAsync(int customerNumber)
        {
            var query_detailsCustomer = from customer in _aDMStore.Customers
                                        where customer.Id == customerNumber
                                        select new CustomerDetailsModel
                                        {
                                            Id = customerNumber,
                                            LastName = customer.LastName,
                                            Email = customer.Email,
                                            FirtName = customer.FirtName,
                                            PhoneNumber = customer.PhoneNumber,
                                            Group1 = customer.Group1,
                                            Group2 = customer.Group2,
                                            Group3 = customer.Group3,
                                            CreatedBy = customer.CreatedBy,
                                            UpdatedAt = customer.UpdatedAt,
                                            CreatedAt = customer.UpdatedAt,
                                        };

            return await query_detailsCustomer.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<CustomerDetailsModel>> ListAsync()
        {
            var query_detailsCustomer = from customer in _aDMStore.Customers
                                        select new CustomerDetailsModel
                                        {
                                            Id = customer.Id,
                                            LastName = customer.LastName,
                                            Email = customer.Email,
                                            FirtName = customer.FirtName,
                                            PhoneNumber = customer.PhoneNumber,
                                            Group1 = customer.Group1,
                                            Group2 = customer.Group2,
                                            Group3 = customer.Group3,
                                            CreatedBy = customer.CreatedBy,
                                            UpdatedAt = customer.UpdatedAt,
                                            CreatedAt = customer.UpdatedAt,
                                        }; 

            return await query_detailsCustomer.ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(CustomerUpdateModel customerUpdate)
        {
            var customerRegistered = await GetDetails(customerUpdate.Id).ConfigureAwait(false);
            customerRegistered.LastName = customerUpdate.LastName;
            customerRegistered.Email = customerUpdate.Email;
            customerRegistered.FirtName = customerUpdate.FirtName;
            customerRegistered.PhoneNumber = customerUpdate.PhoneNumber;
            customerRegistered.Group1 = customerUpdate.Group1;
            customerRegistered.Group2 = customerUpdate.Group2;
            customerRegistered.Group3 = customerUpdate.Group3;
            customerRegistered.UpdatedAt = DateTime.Now;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }

        private async Task<Customer> GetDetails(int customerNumber)
        {
            var customerRegistered = await _aDMStore.Customers.FirstOrDefaultAsync(customer => customer.Id == customerNumber).ConfigureAwait(false);

            if (customerRegistered == null)
            {
                throw new NullReferenceException(nameof(customerRegistered));
            }

            return customerRegistered;
        }
    }
}
