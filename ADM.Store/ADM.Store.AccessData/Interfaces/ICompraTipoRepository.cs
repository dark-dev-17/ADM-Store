using ADM.Store.Models.Models.Compra;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ICompraTipoRepository
    {
        /// <summary>
        /// Listar estatus de compra por nombre asc
        /// </summary>
        /// <returns></returns>
        public Task<List<CompraTipoDetailsModel>> ListAsync();
        /// <summary>
        /// buscar estatus por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Task<CompraTipoDetailsModel?> BuscarEstatusByNameAsync(string nombre);
    }
}
