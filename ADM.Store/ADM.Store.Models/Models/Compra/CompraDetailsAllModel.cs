using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraDetailsAllModel
    {
        public Guid Id { get; set; }
        public CompraDetailsModel Header { get; set; } = null!;
        public List<CompraLineaDetailsModel> Lineas { get; set; } = null!;
    }
}
