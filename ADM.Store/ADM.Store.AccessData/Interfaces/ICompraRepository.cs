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
    internal interface ICompraRepository
    {
        /// <summary>
        /// Registrar nueva compra
        /// </summary>
        /// <param name="newCompra"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Task<Guid?> RegistrarAsync(CompraCreateModel newCompra, Guid Status);
        /// <summary>
        /// Obtener detalles generales de la compra solicitada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CompraDetailsModel?> DetailsAsync(Guid idCompra);
        /// <summary>
        /// Actualizar fecha, proveedor de una compra realizada
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="updateCompra"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Guid idCompra, CompraUpdateModel updateCompra);
        /// <summary>
        /// Listar compras ordenadas por createdAt desc
        /// </summary>
        /// <returns></returns>
        public Task<List<CompraDetailsModel>> ListAsync();
        /// <summary>
        /// mover la compra de compra borrador a compra en firme
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public Task<bool> CambiarEstatusCompra(Guid idCompra, Guid Status);
        /// <summary>
        /// Sumar o restar total
        /// </summary>
        /// <param name="idCompra">Id de la compra</param>
        /// <param name="cantidad">cantidad a sumar o restar</param>
        /// <returns></returns>
        public Task<bool> UpdateTotal(Guid idCompra, decimal cantidad);
        /// <summary>
        /// agregar nueva linea a compra
        /// </summary>
        /// <returns></returns>
        public Task<Guid?> AddCompraLinea(CompraLineaCreateModel compraLineaCreate, Guid EstatusLinea);
        /// <summary>
        /// eliminar linea en orden compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="idCompraLinea"></param>
        /// <returns></returns>
        public Task<bool> RemoveCompraLinea(Guid idCompra, Guid idCompraLinea);
        /// <summary>
        /// actualizar compra linea
        /// </summary>
        /// <param name="updateCompraLinea"></param>
        /// <returns></returns>
        public Task<bool> UpdateCompraLinea(Guid idCompra, Guid idCompraLinea,CompraLineaUpdateModel updateCompraLinea);
        /// <summary>
        /// obtener detalles de linea compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <param name="idCompraLinea"></param>
        /// <returns></returns>
        public Task<CompraLineaDetailsModel?> DetailsCompraLinea(Guid idCompra, Guid idCompraLinea);
        /// <summary>
        /// listar lineas por orden de compra
        /// </summary>
        /// <param name="idCompra"></param>
        /// <returns></returns>
        public Task<List<CompraLineaDetailsModel>> ListCompraLineaByIdCompra(Guid idCompra);
    }
}
