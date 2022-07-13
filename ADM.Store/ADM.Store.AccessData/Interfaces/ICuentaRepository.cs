using ADM.Store.AccessData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Interfaces
{
    internal interface ICuentaRepository
    {
        /// <summary>
        /// Registrar nueva cuenta
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Task<Guid?> RegistrarAsync(string nombre);
        /// <summary>
        /// obtener detalles de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Gcuenta?> DetailsAsync(Guid id);
        /// <summary>
        /// actualizar nombre de cuenta
        /// </summary>
        /// <param name="id">id de la cuenta</param>
        /// <param name="nombre">Nuevo nombre</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Guid id, string nombre);
        /// <summary>
        /// listar cuentas
        /// </summary>
        /// <returns></returns>
        public Task<List<Gcuenta>> ListAsync();
    }
}
