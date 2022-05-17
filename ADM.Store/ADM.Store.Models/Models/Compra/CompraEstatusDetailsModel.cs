using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("ADM.Store.AccessData")]
[assembly: InternalsVisibleTo("ADM.Store.Service")]
[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Models.Models.Compra
{
    internal class CompraEstatusDetailsModel
    {
        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
