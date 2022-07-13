using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CompraLineaEstatusRepository : ICompraLineaEstatusRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public  CompraLineaEstatusRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<CompraLineaEstatusDetailsModel?> BuscarEstatusByNameAsync(string nombre)
        {
            var estusQuery = from estatus in _aDMStore.GcompraLineaEstatuses
                             where estatus.Estatus.Trim().ToLower() == nombre.Trim().ToLower()
                             select new CompraLineaEstatusDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<CompraLineaEstatusDetailsModel>> ListAsync()
        {
            var estusQuery = from estatus in _aDMStore.GcompraLineaEstatuses
                             select new CompraLineaEstatusDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.ToListAsync().ConfigureAwait(false);
        }
    }
}
