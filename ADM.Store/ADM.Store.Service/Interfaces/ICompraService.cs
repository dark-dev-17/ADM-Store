using ADM.Store.Models.Models.Compra;
using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Enums;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface ICompraService
    {
        public string[] GetMessagesError();
        public Task<CreateResultTypes> CreateCompraAsync(CompraCreateModel compraCreate);
        public Task<CompraDetailsAllModel?> DetailsCompraAsync(Guid idCompra);
        public Task<ProcessActionResultTypes> UpdateCompraAsync(Guid idCompra, CompraUpdateModel compraUpdate);
        public Task<CreateResultTypes> AddItemAsync(Guid idCompra, CompraLineaCreateModel compraLineaCreate);
        public Guid GetNewIdItemAdded();
        public Task<CompraLineaDetailsModel?> UpdateItemAsync(Guid idCompra, Guid idCompraLinea, CompraLineaUpdateModel compraLineaUpdate);
        public Task<DeleteResultTypes> DeleteItemAsync(Guid idCompra, Guid idCompraLinea);
        public Guid GetIdCompraCreated();
        public Task<CompraLineaDetailsModel?> DetailsItemInCompra(Guid idCompra, Guid idCompraLinea);
    }
}
