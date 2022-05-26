using System;
using System.Collections.Generic;

namespace ADM.Store.AccessData.Entities
{
    public partial class GcompraLinea
    {
        public Guid Id { get; set; }
        public Guid IdCompra { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioAproxVenta { get; set; }
        public Guid IdCompraLineaEstatus { get; set; }
        public string FolioNota { get; set; } = null!;
        public string? Comentarios { get; set; }

        public virtual GcompraLineaEstatus IdCompraLineaEstatusNavigation { get; set; } = null!;
        public virtual Gcompra IdCompraNavigation { get; set; } = null!;
    }
}
