using System.Runtime.CompilerServices;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraCreateModel
    {
        public Guid IdProveedor { get; set; }
        public Guid IdCompraTipo { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
