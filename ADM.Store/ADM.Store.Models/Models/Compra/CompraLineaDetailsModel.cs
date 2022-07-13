using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraLineaDetailsModel
    {
        public Guid Id { get; set; }
        public Guid IdCompra { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal PrecioCompra { get; set; }
        public decimal PrecioAproxVenta { get; set; }
        public CompraLineaEstatusDetailsModel Estatus { get; set; } = null!;
        public string FolioNota { get; set; } = null!;
        public string? Comentarios { get; set; }
    }
}
