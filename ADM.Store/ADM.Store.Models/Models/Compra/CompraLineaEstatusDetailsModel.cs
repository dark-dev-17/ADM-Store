using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.AccessData")]
[assembly: InternalsVisibleTo("ADM.Store.Service")]
[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Models.Models.Compra
{
    internal class CompraLineaEstatusDetailsModel
    {
        public Guid Id { get; set; }
        public string Estatus { get; set; } = null!;
    }
}
