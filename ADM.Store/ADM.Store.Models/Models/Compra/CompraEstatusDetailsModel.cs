using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraEstatusDetailsModel
    {
        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
