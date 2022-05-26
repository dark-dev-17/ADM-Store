using System.Runtime.CompilerServices;

namespace ADM.Store.Models.Models.Compra
{
    public class CompraLineaEstatusDetailsModel
    {
        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
