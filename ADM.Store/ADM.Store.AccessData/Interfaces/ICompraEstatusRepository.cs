using ADM.Store.Models.Models.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ICompraEstatusRepository
    {
        /// <summary>
        /// Listar estatus de compra por nombre asc
        /// </summary>
        /// <returns></returns>
        public Task<List<CompraEstatusDetailsModel>> ListAsync();
        /// <summary>
        /// buscar estatus por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Task<CompraEstatusDetailsModel?> BuscarEstatusByNameAsync(string nombre);
    }
}
