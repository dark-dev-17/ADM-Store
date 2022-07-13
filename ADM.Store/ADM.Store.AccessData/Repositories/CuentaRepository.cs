using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CuentaRepository : ICuentaRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public CuentaRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<Gcuenta?> DetailsAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException("id");
            }

            return await _aDMStore.Gcuentas.FirstOrDefaultAsync(cuenta => cuenta.Id == id).ConfigureAwait(false);
        }

        public async Task<List<Gcuenta>> ListAsync()
        {
            return await _aDMStore.Gcuentas.OrderBy(cuenta => cuenta.Nombre).ToListAsync();
        }

        public async Task<Guid?> RegistrarAsync(string nombre)
        {
            var newCuenta = new Gcuenta
            {
                Id = Guid.NewGuid(),
                Nombre = nombre
            };

            await _aDMStore.Gcuentas.AddAsync(newCuenta).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newCuenta.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, string nombre)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id");
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("nombre");
            }

            var cuenta = await _aDMStore.Gcuentas.FirstOrDefaultAsync(cuenta => cuenta.Id == id).ConfigureAwait(false);

            if (cuenta == null)
            {
                return false;
            }

            cuenta.Nombre = nombre;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
