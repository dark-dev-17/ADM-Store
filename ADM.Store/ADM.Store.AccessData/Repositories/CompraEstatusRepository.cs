using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CompraEstatusRepository : ICompraEstatusRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public CompraEstatusRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<CompraEstatusDetailsModel?> BuscarEstatusByNameAsync(string nombre)
        {
            var estusQuery = from estatus in _aDMStore.GcompraEstatuses
                             where estatus.Estatus.Trim().ToLower() == nombre.Trim().ToLower()
                             select new CompraEstatusDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<CompraEstatusDetailsModel>> ListAsync()
        {
            var estusQuery = from estatus in _aDMStore.GcompraEstatuses
                             select new CompraEstatusDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.ToListAsync().ConfigureAwait(false);
        }
    }
}
