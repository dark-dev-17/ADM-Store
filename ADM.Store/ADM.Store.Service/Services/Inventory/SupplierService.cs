using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.Supplier;
using ADM.Store.Service.Dictionaries;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces.Inventory;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services.Inventory
{
    internal class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(ISupplierRepository supplierRepository, ILogger<SupplierService> logger)
        {
            _supplierRepository = supplierRepository ?? throw new ArgumentNullException(nameof(supplierRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSupplier"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<SupplierDetailsModel> CreateAsync(SupplierCreateModel newSupplier)
        {
            SetSupplier(newSupplier.CardCode);
            await _supplierRepository.CreateAsync(newSupplier).ConfigureAwait(false);

            return await DetailsAsync(newSupplier.CardCode).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierDetailsModel> DetailsAsync(string cardCode)
        {
            SetSupplier(cardCode);

            var supplierFound = await _supplierRepository.DetailsAsync(cardCode).ConfigureAwait(false);

            if (supplierFound == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.SUPPLIER_NOTFOUND);
            }

            return supplierFound;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SupplierDetailsModel>> ListAsync()
        {
            return await _supplierRepository.ListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <param name="newSupplier"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task UpdateAsync(string cardCode, SupplierUpdateModel newSupplier)
        {
            SetSupplier(cardCode);

            if (Equals(newSupplier, null))
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }
            if (newSupplier.CardCode != cardCode)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }
            bool existsSupplier = await _supplierRepository.ExistsByCardCodeAsync(cardCode).ConfigureAwait(false);

            if (!existsSupplier)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.SUPPLIER_NOTFOUND);
            }

            await _supplierRepository.UpdateAsync(newSupplier).ConfigureAwait(false);
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
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.SUPPLIER_CARDCODE_INVALID);
            }
        }
    }
}
