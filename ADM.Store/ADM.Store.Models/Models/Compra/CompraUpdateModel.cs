using System.Runtime.CompilerServices;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraUpdateModel
    {
        public Guid Id { get; set; }
        public Guid IdProveedor { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
