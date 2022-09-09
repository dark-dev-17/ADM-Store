using ADM.Store.Service.Interfaces.Inventory;
using System.Runtime.CompilerServices;
using ADM.Store.Models.Models.SupplierContact;
using Microsoft.Extensions.Logging;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Dictionaries;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services.Inventory
{
    internal class SupplierContactService : ISupplierContactService
    {
        private readonly ISupplierContactRepository _contactRepository;
        private readonly ILogger<SupplierContactService> _logger;

        public SupplierContactService(ISupplierContactRepository contactRepository, ILogger<SupplierContactService> logger)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <param name="newContact"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierContactDetailsModel> CreateAsync(string cardCode, SupplierContactCreateModel newContact)
        {
            SetSupplier(cardCode);

            if(Equals(newContact, null))
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            int idContactCreated = await _contactRepository.ExistsAsync(newContact.SupplierName, cardCode);

            if (idContactCreated == 0)
            {
                idContactCreated = await _contactRepository.CreateAsync(newContact).ConfigureAwait(false);
            }

            var contactCreated = await _contactRepository.DetailsAsync(idContactCreated).ConfigureAwait(false);

            if(contactCreated == null)
            {
                throw new ExceptionService(-201,"Contacto no registrado");
            }

            return contactCreated;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <param name="idContact"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task<SupplierContactDetailsModel> DetailsAsync(string cardCode, int idContact)
        {
            SetSupplier(cardCode);

            var contactFound = await _contactRepository.DetailsAsync(idContact).ConfigureAwait(false);

            if(contactFound== null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.SUPPLIER_CONTACT_NOTFOUND);
            }

            if(contactFound.CardCode != cardCode)
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            return contactFound;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        public async Task<List<SupplierContactDetailsModel>> ListAsync(string cardCode)
        {
            SetSupplier(cardCode);

            return await _contactRepository.ListAsync(cardCode).ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <param name="newContact"></param>
        /// <returns></returns>
        /// <exception cref="ExceptionService"></exception>
        public async Task UpdateAsync(string cardCode, SupplierContactUpdateModel newContact)
        {
            SetSupplier(cardCode);

            if (Equals(newContact, null))
            {
                throw new ExceptionService(StatusCodeService.Status400BadRequest, ConstantsService.MODEL_ERROR_DATA_NULL);
            }

            int idContactCreated = await _contactRepository.ExistsAsync(newContact.Id);

            if (idContactCreated == 0)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, ConstantsService.SUPPLIER_CONTACT_NOTFOUND);
            }

            await _contactRepository.UpdateAsync(newContact).ConfigureAwait(false);
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
