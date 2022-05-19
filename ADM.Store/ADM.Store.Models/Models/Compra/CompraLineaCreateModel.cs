using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Compra
{
    internal class CompraLineaCreateModel
    {
        public Guid IdCompra { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioAproxVenta { get; set; }
        public string FolioNota { get; set; } = null!;
        public string? Comentarios { get; set; }
    }
}
