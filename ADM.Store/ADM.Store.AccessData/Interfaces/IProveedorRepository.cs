using ADM.Store.Models.Models.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface IProveedorRepository
    {
        /// <summary>
        /// registrar nuevo proveedor
        /// </summary>
        /// <param name="proveedorRegister"></param>
        /// <returns></returns>
        public Task<Guid?> RegistrarAsync(ProveedorCreateModel proveedorRegister);
        /// <summary>
        /// obtener detalles por id de proveedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ProveedorDetailsModel?> DetailsAsync(Guid id);
        /// <summary>
        /// actualizar proveedor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proveedorUpdate"></param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Guid id, ProveedorUpdateModel proveedorUpdate);
        /// <summary>
        /// listar proveedores ordenados por nombre asc
        /// </summary>
        /// <returns></returns>
        public Task<List<ProveedorDetailsModel>> List();
        /// <summary>
        /// Validar si existe un proveedor por idProveedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(Guid id);
    }
}
