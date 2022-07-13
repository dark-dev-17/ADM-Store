using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CompraTipoRepository : ICompraTipoRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public CompraTipoRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<CompraTipoDetailsModel?> BuscarEstatusByNameAsync(string nombre)
        {
            var estusQuery = from estatus in _aDMStore.GcompraTipos
                             where estatus.Estatus.Trim().ToLower() == nombre.Trim().ToLower()
                             select new CompraTipoDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<CompraTipoDetailsModel>> ListAsync()
        {
            var estusQuery = from estatus in _aDMStore.GcompraTipos
                             select new CompraTipoDetailsModel
                             {
                                 Estatus = estatus.Estatus,
                                 Id = estatus.Id
                             };

            return await estusQuery.ToListAsync().ConfigureAwait(false);
        }
    }
}
