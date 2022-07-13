using ADM.Store.Models.Models.Proveedor;
using System.Runtime.CompilerServices;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraDetailsModel
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
