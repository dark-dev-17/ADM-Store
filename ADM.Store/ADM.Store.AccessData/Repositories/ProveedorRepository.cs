using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Proveedor;
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
    internal class ProveedorRepository : IProveedorRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ProveedorRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<ProveedorDetailsModel?> DetailsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var proveedorQuery = from proveedor in _aDMStore.Gproveedors
                                 where proveedor.Id == id
                                 select new ProveedorDetailsModel
                                 {
                                     Id = proveedor.Id,
                                     Nombre = proveedor.Nombre,
                                     Telefono = proveedor.Telefono,
                                     Calle = proveedor.Calle,
                                     Municipio = proveedor.Municipio,
                                     Estado = proveedor.Estado,
                                     NoInt = proveedor.NoInt,
                                     NoExt = proveedor.NoExt,
                                     Cp = proveedor.Cp,
                                     FacePage = proveedor.FacePage,
                                     WebPage = proveedor.WebPage,
                                     UpdatedAt = proveedor.UpdatedAt
                                 };

            return await proveedorQuery.FirstOrDefaultAsync(proveedor => proveedor.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _aDMStore.Gproveedors.AnyAsync(proveedor => proveedor.Id == id).ConfigureAwait(false);
        }

        public async Task<List<ProveedorDetailsModel>> List()
        {
            var proveedoresQuery = from proveedor in _aDMStore.Gproveedors
                                 select new ProveedorDetailsModel
                                 {
                                     Id = proveedor.Id,
                                     Nombre = proveedor.Nombre,
                                     Telefono = proveedor.Telefono,
                                     Calle = proveedor.Calle,
                                     Municipio = proveedor.Municipio,
                                     Estado = proveedor.Estado,
                                     NoInt = proveedor.NoInt,
                                     NoExt = proveedor.NoExt,
                                     Cp = proveedor.Cp,
                                     FacePage = proveedor.FacePage,
                                     WebPage = proveedor.WebPage,
                                     UpdatedAt = proveedor.UpdatedAt
                                 };
            return await proveedoresQuery.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Guid?> RegistrarAsync(ProveedorCreateModel proveedorRegister)
        {
            var proveedor = new Gproveedor
            {
                Id = Guid.NewGuid(),
                Nombre = proveedorRegister.Nombre,
                Telefono = proveedorRegister.Telefono,
                Calle = proveedorRegister.Calle,
                Municipio = proveedorRegister.Municipio,
                Estado = proveedorRegister.Estado,
                NoInt = proveedorRegister.NoInt,
                NoExt = proveedorRegister.NoExt,
                Cp = proveedorRegister.Cp,
                FacePage = proveedorRegister.FacePage,
                WebPage = proveedorRegister.WebPage,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };

            await _aDMStore.Gproveedors.AddAsync(proveedor).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return proveedor.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, ProveedorUpdateModel proveedorUpdate)
        {
            var proveedor = await _aDMStore.Gproveedors.FirstOrDefaultAsync(proveedor => proveedor.Id == id).ConfigureAwait(false);

            if (proveedor == null)
            {
                return false;
            }

            proveedor.Nombre = proveedorUpdate.Nombre;
            proveedor.Telefono = proveedorUpdate.Telefono;
            proveedor.Calle = proveedorUpdate.Calle;
            proveedor.Municipio = proveedorUpdate.Municipio;
            proveedor.Estado = proveedorUpdate.Estado;
            proveedor.NoInt = proveedorUpdate.NoInt;
            proveedor.NoExt = proveedorUpdate.NoExt;
            proveedor.Cp = proveedorUpdate.Cp;
            proveedor.FacePage = proveedorUpdate.FacePage;
            proveedor.WebPage = proveedorUpdate.WebPage;
            proveedor.UpdatedAt = DateTime.UtcNow;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
