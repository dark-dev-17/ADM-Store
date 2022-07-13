using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Enums;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly ILogger<ProveedorService> _logger;
        private Guid _idProveedor;

        public ProveedorService(IProveedorRepository proveedorRepository, ILogger<ProveedorService> logger)
        {
            _proveedorRepository = proveedorRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedorCreate"></param>
        /// <returns></returns>
        public async Task<ProcessActionResultTypes> CreateProveedorAsync(ProveedorCreateModel proveedorCreate)
        {
            if (proveedorCreate is null)
            {
                _logger.LogError($"the information is invalid, please verify it", proveedorCreate);
                return ProcessActionResultTypes.InValidModel;
            }

            _logger.LogInformation("the information was received successfully", proveedorCreate);


            var newIdProveedorCreated = await _proveedorRepository.RegistrarAsync(proveedorCreate).ConfigureAwait(false);

            if (newIdProveedorCreated == Guid.Empty)
            {
                _logger.LogError($"proveedor not created");
                return ProcessActionResultTypes.NotCreated;
            }
            _logger.LogInformation("Proveedor created successfully", newIdProveedorCreated);
            _idProveedor = (Guid)newIdProveedorCreated;

            return ProcessActionResultTypes.Created;
        }

        public async Task<ProveedorDetailsModel?> GetByIdProveedorAsync(Guid idProveedor)
        {
            if (idProveedor == Guid.Empty)
            {
                _logger.LogError($"idProveedor is not valid", idProveedor);
                throw new ArgumentException(nameof(idProveedor));
            }

            _logger.LogInformation("idProveedor received successfully", idProveedor);
            var proveedor = await _proveedorRepository.DetailsAsync(idProveedor).ConfigureAwait(false);

            return proveedor;
        }

        public Guid GetIdProveedorCreated()
        {
            return _idProveedor;
        }

        public async Task<List<ProveedorDetailsModel>> ListAsync()
        {
            var listProveedores = await _proveedorRepository.List().ConfigureAwait(false);

            return listProveedores;
        }

        public async Task<ProcessActionResultTypes> UpdateByIdProveedorAsync(Guid idProveedor, ProveedorUpdateModel proveedorUpdate)
        {
            if (idProveedor == Guid.Empty)
            {
                _logger.LogError($"idProveedor is not valid", idProveedor);
                throw new ArgumentException(nameof(idProveedor));
            }

            _logger.LogInformation("idProveedor received successfully", idProveedor);

            if (proveedorUpdate is null)
            {
                _logger.LogError($"the information is invalid, please verify it", proveedorUpdate);
                return ProcessActionResultTypes.InValidModel;
            }

            _logger.LogInformation("the information was received successfully", proveedorUpdate);

            if (idProveedor != proveedorUpdate.Id)
            {
                return ProcessActionResultTypes.DataIncongruity;
            }

            if ( ! await _proveedorRepository.ExistsAsync(idProveedor))
            {
                _logger.LogWarning($"the proveeedor with id: {idProveedor} was not found", idProveedor);
                return ProcessActionResultTypes.NotFound;
            }

            var resultAction = await _proveedorRepository.UpdateAsync(idProveedor, proveedorUpdate).ConfigureAwait(false);

            if (!resultAction)
            {
                return ProcessActionResultTypes.NotUpdated;
            }

            return ProcessActionResultTypes.Updated;

        }
    }
}
