using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    internal partial class Gcompra
    {
        public Gcompra()
        {
            GcompraLineas = new HashSet<GcompraLinea>();
        }

        public Guid Id { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public Guid IdCompraEstatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual GcompraEstatus IdCompraEstatusNavigation { get; set; } = null!;
        public virtual Gproveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<GcompraLinea> GcompraLineas { get; set; }
    }
}
