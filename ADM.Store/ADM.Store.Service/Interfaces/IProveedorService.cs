using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IProveedorService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedorCreate"></param>
        /// <returns></returns>
        public Task<ProcessActionResultTypes> CreateProveedorAsync(ProveedorCreateModel proveedorCreate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <returns></returns>
        public Task<ProveedorDetailsModel?> GetByIdProveedorAsync(Guid idProveedor);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Guid GetIdProveedorCreated();
        /// <summary>
        /// Listar 
        /// </summary>
        /// <returns></returns>
        public Task<List<ProveedorDetailsModel>> ListAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <param name="proveedorUpdate"></param>
        /// <returns></returns>
        public Task<ProcessActionResultTypes> UpdateByIdProveedorAsync(Guid idProveedor, ProveedorUpdateModel proveedorUpdate);
    }
}
