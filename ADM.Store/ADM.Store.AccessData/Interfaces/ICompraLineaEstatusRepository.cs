using ADM.Store.Models.Models.Compra;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ICompraLineaEstatusRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<CompraLineaEstatusDetailsModel>> ListAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Task<CompraLineaEstatusDetailsModel?> BuscarEstatusByNameAsync(string nombre);
    }
}
