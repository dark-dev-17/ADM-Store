using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierLocation;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces.Inventory;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services.Inventory
{
    internal class SupplierLocationService : ISupplierLocationService
    {
        private readonly ISupplierLocationRepository _locationRepository;
        private readonly ILogger<SupplierLocationService> _logger;

        public SupplierLocationService(ISupplierLocationRepository locationRepository, ILogger<SupplierLocationService> logger)
        {
            _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationCreateModel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierLocationDetailsModel> CreateAsync(SupplierLocationCreateModel locationCreateModel)
        {
            if (locationCreateModel == null)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, "La informacion enviada es incorrecta, por favor intenta nuevamente");
            }

            SetSupplier(locationCreateModel.CardCode);
            ValidData(locationCreateModel.LocationName);

            int idLocationCreatedValid = await _locationRepository.ExistsAsync(locationCreateModel.LocationName, locationCreateModel.CardCode).ConfigureAwait(false);

            if (idLocationCreatedValid == 0)
            {
                idLocationCreatedValid = await _locationRepository.CreateAsync(locationCreateModel).ConfigureAwait(false);
            }

            var locationDetails = await _locationRepository.DetailsAsync(idLocationCreatedValid).ConfigureAwait(false);

            if (locationDetails == null)
            {
                throw new ExceptionService(-201, "La ubicacion del proveedor no fue registrada");
            }

            return locationDetails;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <param name="idLocation"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierLocationDetailsModel> DetailsAsync(string cardCode, int idLocation)
        {
            SetSupplier(cardCode);
            if(idLocation == 0)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, "Por favor selecciona una ubicacion correcta");
            }

            var locationDetails = await _locationRepository.DetailsAsync(idLocation).ConfigureAwait(false);

            if (locationDetails == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "La ubicacion del proveedor no fue encontrada");
            }

            return locationDetails;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<List<SupplierLocationDetailsModel>> ListAsync(string cardCode)
        {
            SetSupplier(cardCode);

            return await _locationRepository.ListAsync(cardCode).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationUpdateModel"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task UpdateAsync(SupplierLocationUpdateModel locationUpdateModel)
        {
            var locationDetails = await _locationRepository.ExistsAsync(locationUpdateModel.Id).ConfigureAwait(false);

            if (locationDetails == 0)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "La ubicacion del proveedor no fue encontrada");
            }

            await _locationRepository.UpdateAsync(locationUpdateModel).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <exception cref="ExceptionService"></exception>
        private void SetSupplier(string cardCode)
        {
            if (string.IsNullOrEmpty(cardCode) || string.IsNullOrWhiteSpace(cardCode))
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, "Codigo de proveedor no valido");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locatioName"></param>
        /// <exception cref="ExceptionService"></exception>
        private void ValidData(string locatioName)
        {
            if (string.IsNullOrEmpty(locatioName) || string.IsNullOrWhiteSpace(locatioName))
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, "Por favor selecciona un nombre valido");
            }
        }
    }
}
