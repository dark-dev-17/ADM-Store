using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierContactRepository : ISupplierContactRepository
    {
        public Task<int> CreateAsync(SupplierContactCreateModel contactCreateModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int idSupplierContact)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierContactDetailsModel?> DetailsAsync(int idSupplierContact)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierContactDetailsModel?> DetailsAsync(string nameSupplierContact)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsAsync(int idSupplierContact)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsAsync(string nameSupplierContact)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierContactDetailsModel>> ListAsync(string cardCode)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SupplierContactUpdateModel contactUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
