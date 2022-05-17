using ADM.Store.AccessData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CompraRepository : ICompraRepository
    {
        public Task<Guid?> RegistrarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
