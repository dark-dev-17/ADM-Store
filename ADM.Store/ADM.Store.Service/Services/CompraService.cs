using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Compra;
using ADM.Store.Service.Enums;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class CompraService : ICompraService
    {
        protected readonly ICompraRepository _compraRepository;
        protected readonly IProveedorRepository _proveedorRepository;
        protected readonly ICompraEstatusRepository _compraEstatusRepository;
        protected readonly ICompraLineaEstatusRepository _compraLineaEstatusRepository;
        protected readonly ILogger<CompraService> _logger;
        private string[] _errorsProcess;
        private Guid _idCompraCreated;
        private Guid _idCompraItemCreated;

        public CompraService(ICompraRepository compraRepository, IProveedorRepository proveedorRepository,
                             ICompraLineaEstatusRepository compraLineaEstatusRepository, ICompraEstatusRepository compraEstatusRepository, ILogger<CompraService> logger)
        {
            _compraRepository = compraRepository;
            _proveedorRepository = proveedorRepository;
            _compraLineaEstatusRepository = compraLineaEstatusRepository;
            _compraEstatusRepository = compraEstatusRepository;
            _logger = logger;
        }

        public async Task<CreateResultTypes> AddItemAsync(Guid idCompra, CompraLineaCreateModel compraLineaCreate)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError($"please select a valid id[{idCompra}]", idCompra);
                throw new ArgumentException(nameof(idCompra));
            }

            _logger.LogInformation($"idCompra: [{idCompra}] received successfully", idCompra);

            var headerCompra = await _compraRepository.DetailsAsync(idCompra).ConfigureAwait(false);

            if (headerCompra == null)
            {
                _logger.LogError($"compra selected not found {idCompra}", idCompra);
                return CreateResultTypes.RelationNotFound;
            }

            _logger.LogInformation($"compra with id: [{idCompra}] found", idCompra);

            var statusLine = await _compraLineaEstatusRepository.BuscarEstatusByNameAsync("nuevo producto").ConfigureAwait(false);

            if (statusLine == null)
            {
                _logger.LogError($"estatus line 'nuevo producto' was not found");
                return CreateResultTypes.RelationNotFound;
            }

            var newItem = await _compraRepository.AddCompraLinea(compraLineaCreate, statusLine.Id).ConfigureAwait(false);

            if(newItem == Guid.Empty)
            {
                _logger.LogError($"item not added to compra lines");
                return CreateResultTypes.NotCreated;
            }

            _logger.LogInformation($"new item added [{newItem}]");
            _idCompraItemCreated = (Guid)newItem;

            await _compraRepository.UpdateTotal(idCompra).ConfigureAwait(false);

            return CreateResultTypes.Created;
        }

        public async Task<CreateResultTypes> CreateCompraAsync(CompraCreateModel compraCreate)
        {
            if (compraCreate == null)
            {
                _logger.LogError("Invalid information to create a new Compra", compraCreate);
                return CreateResultTypes.InValidModel;
            }

            _logger.LogInformation("Information received successfylly", compraCreate);

            if (! await _proveedorRepository.ExistsAsync(compraCreate.IdProveedor))
            {
                _logger.LogError($"the proveedor selected was not found", compraCreate.IdProveedor);
                return CreateResultTypes.RelationNotFound;
            }

            var estatusDraft = await _compraEstatusRepository.BuscarEstatusByNameAsync("draft").ConfigureAwait(false);

            if (estatusDraft == null)
            {
                _logger.LogError($"the draft status was not founded", estatusDraft);
                return CreateResultTypes.RelationNotFound;
            }

            _logger.LogInformation("the draft status was found", estatusDraft);

            var idCompraCreated = await _compraRepository.RegistrarAsync(compraCreate, estatusDraft.Id).ConfigureAwait(false);
            
            if(idCompraCreated == Guid.Empty)
            {
                _logger.LogError($"compra not saved", estatusDraft);
                return CreateResultTypes.NotCreated;
            }

            _idCompraCreated = idCompraCreated;

            _logger.LogInformation($"new compra saved with id: {idCompraCreated}", idCompraCreated);

            return CreateResultTypes.Created;
        }

        public async Task<DeleteResultTypes> DeleteItemAsync(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError($"please select a valid idCompra[{idCompra}]", idCompra);
                throw new ArgumentException(nameof(idCompra));
            }

            _logger.LogInformation($"idCompra: [{idCompra}] received successfully", idCompra);

            if (idCompraLinea == Guid.Empty)
            {
                _logger.LogError($"please select a valid idCompraLinea[{idCompraLinea}]", idCompraLinea);
                throw new ArgumentException(nameof(idCompraLinea));
            }

            _logger.LogInformation($"idCompraLinea: [{idCompraLinea}] received successfully", idCompraLinea);

            var result = await _compraRepository.RemoveCompraLinea(idCompra, idCompraLinea);

            if (!result)
            {
                return DeleteResultTypes.NotFound;
            }
            await _compraRepository.UpdateTotal(idCompra).ConfigureAwait(false);
            return DeleteResultTypes.Deleted;
        }

        public async Task<CompraDetailsAllModel?> DetailsCompraAsync(Guid idCompra)
        {

            if (idCompra == Guid.Empty)
            {
                _logger.LogError($"please select a valid id[{idCompra}]", idCompra);
                throw new ArgumentException(nameof(idCompra));
            }

            _logger.LogInformation($"idCompra: [{idCompra}] received successfully", idCompra);
            var headerCompra =  await _compraRepository.DetailsAsync(idCompra).ConfigureAwait(false);

            if (headerCompra == null)
            {
                _logger.LogError($"compra with id: [{idCompra}] not found", idCompra);
                return null;
            }

            var itemsCompra = await _compraRepository.ListCompraLineaByIdCompra(idCompra).ConfigureAwait(false);

            _logger.LogInformation($"[{itemsCompra.Count}] found", idCompra);
            var compraDetails = new CompraDetailsAllModel
            {
                Id = idCompra,
                Header = headerCompra,
                Lineas = itemsCompra
            };

            return compraDetails;
        }

        public async Task<CompraLineaDetailsModel?> DetailsItemInCompra(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError($"please select a valid idCompra[{idCompra}]", idCompra);
                throw new ArgumentException(nameof(idCompra));
            }

            _logger.LogInformation($"idCompra: [{idCompra}] received successfully", idCompra);

            if (idCompraLinea == Guid.Empty)
            {
                _logger.LogError($"please select a valid idCompraLinea[{idCompraLinea}]", idCompraLinea);
                throw new ArgumentException(nameof(idCompraLinea));
            }

            _logger.LogInformation($"idCompraLinea: [{idCompraLinea}] received successfully", idCompraLinea);

            var result = await _compraRepository.DetailsCompraLinea(idCompra, idCompraLinea);

            return result;
        }

        public Guid GetIdCompraCreated()
        {
            return _idCompraCreated;
        }

        public string[] GetMessagesError()
        {
            throw new NotImplementedException();
        }

        public Guid GetNewIdItemAdded()
        {
            return _idCompraItemCreated;
        }

        public async Task<ProcessActionResultTypes> UpdateCompraAsync(Guid idCompra, CompraUpdateModel compraUpdate)
        {
            if (compraUpdate == null)
            {
                _logger.LogError("Invalid information to create a new Compra", compraUpdate);
                return ProcessActionResultTypes.InValidModel;
            }

            _logger.LogInformation("Information received successfylly", compraUpdate);

            if (!await _proveedorRepository.ExistsAsync(compraUpdate.IdProveedor))
            {
                _logger.LogError($"the proveedor selected was not found", compraUpdate.IdProveedor);
                return ProcessActionResultTypes.NotFound;
            }

            _logger.LogInformation($"the proveedor selected was found", compraUpdate.IdProveedor);
            var completed = await _compraRepository.UpdateAsync(idCompra, compraUpdate).ConfigureAwait(false);

            if (!completed)
            {
                _logger.LogError($"compra not updated", compraUpdate.IdProveedor);
                return ProcessActionResultTypes.NotUpdated;
            }
            _logger.LogInformation($"Compra updated", compraUpdate.IdProveedor);
            return ProcessActionResultTypes.Updated;
        }

        public async Task<CompraLineaDetailsModel?> UpdateItemAsync(Guid idCompra, Guid idCompraLinea, CompraLineaUpdateModel compraLineaUpdate)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError($"please select a valid id[{idCompra}]", idCompra);
                throw new ArgumentException(nameof(idCompra));
            }

            _logger.LogInformation($"idCompra: [{idCompra}] received successfully", idCompra);

            var result = await _compraRepository.UpdateCompraLinea(idCompra, idCompraLinea, compraLineaUpdate).ConfigureAwait(false);

            if (!result)
            {
                return null;
            }
            await _compraRepository.UpdateTotal(idCompra).ConfigureAwait(false);
            return await _compraRepository.DetailsCompraLinea(idCompra, idCompraLinea);
        }
    }
}
