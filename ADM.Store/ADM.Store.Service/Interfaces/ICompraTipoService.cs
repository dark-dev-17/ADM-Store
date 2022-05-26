using ADM.Store.Models.Models.Compra;
using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface ICompraTipoService
    {
        public Task<List<CompraTipoDetailsModel>> List();
    }
}
