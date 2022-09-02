using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierRepository : ISupplierRepository
    {
        public Task<int> CreateAsync(string supplierName)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierDetailsModel?> DetailsAsync(string CardCode)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsByCardCodeAsync(string CardCode)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExistsByNameAsync(string supplierName)
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierDetailsModel>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<SupplierDetailsModel>> ListAsync(int statusId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string cardCode, string supplierName)
        {
            throw new NotImplementedException();
        }
    }
}
