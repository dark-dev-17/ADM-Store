using ADM.Store.Models.Models.Proveedor;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.AccessData")]
[assembly: InternalsVisibleTo("ADM.Store.Service")]
[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Models.Models.Compra
{
    internal class CompraDetailsModel
    {
        public Guid Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public CompraEstatusDetailsModel Estatus { get; set; } = null!;
        public Guid IdProveedor { get; set; }
        public string ProveedorNombre { get; set; } = null!;
    }
}
