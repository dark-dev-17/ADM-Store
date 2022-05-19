using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class CompraRepository : ICompraRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public CompraRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public Task<Guid?> AddCompraLinea(CompraLineaCreateModel compraLineaCreate, Guid EstatusLinea)
        {
            throw new NotImplementedException();
        }

        public async Task<CompraDetailsModel?> DetailsAsync(Guid idCompra)
        {
            if (idCompra == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompra));
            }

            var comprasQuery = from compra in _aDMStore.Gcompras
                               join estatus in _aDMStore.GcompraLineaEstatuses on compra.IdCompraEstatus equals estatus.Id
                               join proveedor in _aDMStore.Gproveedors on compra.IdProveedor equals proveedor.Id
                               where compra.Id == idCompra
                               select new CompraDetailsModel
                               {
                                   Id = compra.Id,
                                   FechaCompra = compra.FechaCompra,
                                   IdProveedor = proveedor.Id,
                                   ProveedorNombre = proveedor.Nombre,
                                   Estatus = new CompraEstatusDetailsModel
                                   {
                                       Id = estatus.Id,
                                       Estatus = estatus.Estatus
                                   },
                                   CreatedAt = compra.CreatedAt,
                                   UpdatedAt = compra.UpdatedAt,
                                   Total = compra.Total
                               };

            return await comprasQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<CompraLineaDetailsModel?> DetailsCompraLinea(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompra));
            }

            if (idCompraLinea == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompraLinea));
            }
            var compraLineaQuery = from compraLinea in _aDMStore.GcompraLineas join lineaEstatus in _aDMStore.GcompraLineaEstatuses on compraLinea.IdCompraLineaEstatus equals lineaEstatus.Id
                                   where compraLinea.IdCompra == idCompra && compraLinea.Id == idCompraLinea
                                   select new CompraLineaDetailsModel
                                   {
                                       Id = compraLinea.Id,
                                       Descripcion = compraLinea.Descripcion,
                                       PrecioCompra = compraLinea.PrecioCompra,
                                       PrecioAproxVenta = compraLinea.PrecioAproxVenta,
                                       FolioNota = compraLinea.FolioNota,
                                       Comentarios = compraLinea.Comentarios,
                                       IdCompra = compraLinea.IdCompra,
                                       Estatus = new CompraLineaEstatusDetailsModel
                                       {
                                           Id = lineaEstatus.Id,
                                           Estatus = lineaEstatus.Estatus
                                       }
                                   };

            return await compraLineaQuery.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<List<CompraDetailsModel>> ListAsync()
        {
            var comprasQuery = from compra in _aDMStore.Gcompras
                               join estatus in _aDMStore.GcompraLineaEstatuses on compra.IdCompraEstatus equals estatus.Id
                               join proveedor in _aDMStore.Gproveedors on compra.IdProveedor equals proveedor.Id
                               orderby compra.FechaCompra descending 
                               select new CompraDetailsModel
                               {
                                   Id = compra.Id,
                                   FechaCompra = compra.FechaCompra,
                                   IdProveedor = proveedor.Id,
                                   ProveedorNombre = proveedor.Nombre,
                                   Estatus = new CompraEstatusDetailsModel
                                   {
                                       Id = estatus.Id,
                                       Estatus = estatus.Estatus
                                   },
                                   CreatedAt = compra.CreatedAt,
                                   UpdatedAt = compra.UpdatedAt,
                                   Total = compra.Total
                               };

            return await comprasQuery.ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<CompraLineaDetailsModel>> ListCompraLineaByIdCompra(Guid idCompra)
        {
            if (idCompra == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompra));
            }

            var compraLineaQuery = from compraLinea in _aDMStore.GcompraLineas
                                   join lineaEstatus in _aDMStore.GcompraLineaEstatuses on compraLinea.IdCompraLineaEstatus equals lineaEstatus.Id
                                   select new CompraLineaDetailsModel
                                   {
                                       Id = compraLinea.Id,
                                       Descripcion = compraLinea.Descripcion,
                                       PrecioCompra = compraLinea.PrecioCompra,
                                       PrecioAproxVenta = compraLinea.PrecioAproxVenta,
                                       FolioNota = compraLinea.FolioNota,
                                       Comentarios = compraLinea.Comentarios,
                                       IdCompra = compraLinea.IdCompra,
                                       Estatus = new CompraLineaEstatusDetailsModel
                                       {
                                           Id = lineaEstatus.Id,
                                           Estatus = lineaEstatus.Estatus
                                       }
                                   };

            return await compraLineaQuery.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> CambiarEstatusCompra(Guid idCompra, Guid Status)
        {
            if (idCompra == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompra));
            }

            if (Status == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Status));
            }

            var compra = await _aDMStore.Gcompras.FirstOrDefaultAsync(compra => compra.Id == idCompra).ConfigureAwait(false);

            if (compra == null)
            {
                return false;
            }

            compra.IdCompraEstatus = Status;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<Guid?> RegistrarAsync(CompraCreateModel newCompra, Guid Status)
        {
            if (Status == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Status));
            }

            var nuevaCompra = new Gcompra
            {
                Id = Guid.NewGuid(),
                FechaCompra = newCompra.FechaCompra,
                Total = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IdProveedor = newCompra.IdProveedor,
                IdCompraEstatus = Status
            };

            await _aDMStore.Gcompras.AddAsync(nuevaCompra).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return nuevaCompra.Id;
        }

        public async Task<bool> RemoveCompraLinea(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompra));
            }

            if (idCompraLinea == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(idCompraLinea));
            }
            var compraLinea = await _aDMStore.GcompraLineas.FirstOrDefaultAsync(linea => linea.IdCompra == idCompra && linea.Id == idCompraLinea).ConfigureAwait(false);

            if(compraLinea == null)
            {
                return false;
            }

            _aDMStore.GcompraLineas.Remove(compraLinea);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> UpdateAsync(Guid idCompra, CompraUpdateModel updateCompra)
        {
            var compra = await _aDMStore.Gcompras.FirstOrDefaultAsync(compra => compra.Id == idCompra).ConfigureAwait(false);

            if (compra == null)
            {
                return false;
            }

            compra.FechaCompra = updateCompra.FechaCompra;
            compra.IdProveedor = updateCompra.IdProveedor;
            compra.UpdatedAt = DateTime.UtcNow;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> UpdateCompraLinea(Guid idCompra, Guid idCompraLinea,CompraLineaUpdateModel updateCompraLinea)
        {
            var compraLinea = await _aDMStore.GcompraLineas.FirstOrDefaultAsync(linea => linea.IdCompra == idCompra && linea.Id == idCompraLinea).ConfigureAwait(false);

            if (compraLinea == null)
            {
                return false;
            }

            compraLinea.Descripcion = updateCompraLinea.Descripcion;
            compraLinea.Comentarios = updateCompraLinea.Comentarios;
            compraLinea.Comentarios = updateCompraLinea.FolioNota;
            compraLinea.PrecioAproxVenta = updateCompraLinea.PrecioAproxVenta;
            compraLinea.PrecioCompra = updateCompraLinea.PrecioCompra;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> UpdateTotal(Guid idCompra, decimal cantidad)
        {
            var compra = await _aDMStore.Gcompras.FirstOrDefaultAsync(compra => compra.Id == idCompra).ConfigureAwait(false);

            if (compra == null)
            {
                return false;
            }

            compra.Total = compra.Total + cantidad;
            compra.UpdatedAt = DateTime.UtcNow;

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
