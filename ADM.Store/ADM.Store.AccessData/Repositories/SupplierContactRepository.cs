using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierContact;
using ADM.Store.AccessData.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierContactRepository : ISupplierContactRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SupplierContactRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactCreateModel"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(SupplierContactCreateModel contactCreateModel)
        {
            var newSupplierContac = new SupplierContact
            {
                CardCode = contactCreateModel.CardCode,
                SupplierName = contactCreateModel.SupplierName,
                // TODO service-user
                CreatedBy = "USER-SYS",
                PhoneNumber = contactCreateModel.PhoneNumber,
                Active = contactCreateModel.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _aDMStore.SupplierContacts.AddAsync(newSupplierContac).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newSupplierContac.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierContact"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task DeleteAsync(int idSupplierContact)
        {
            var supplierContact = await _aDMStore.SupplierContacts.FirstOrDefaultAsync(contact => contact.Id == idSupplierContact).ConfigureAwait(false);
            if (supplierContact == null)
            {
                throw new NullReferenceException();
            }

            _aDMStore.SupplierContacts.Remove(supplierContact);

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierContact"></param>
        /// <returns></returns>
        public async Task<SupplierContactDetailsModel?> DetailsAsync(int idSupplierContact)
        {
            var supplierContact_query = from contact in _aDMStore.SupplierContacts
                                        where contact.Id == idSupplierContact
                                        select new SupplierContactDetailsModel
                                        {
                                            CardCode = contact.CardCode,
                                            SupplierName = contact.SupplierName,
                                            PhoneNumber = contact.PhoneNumber,
                                            CreatedAt = contact.CreatedAt,
                                            Active = contact.Active,
                                            CreatedBy = contact.CreatedBy,
                                            Id = contact.Id
                                        };
            return await supplierContact_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSupplierContact"></param>
        /// <returns></returns>
        public async Task<SupplierContactDetailsModel?> DetailsAsync(string nameSupplierContact)
        {
            var supplierContact_query = from contact in _aDMStore.SupplierContacts
                                        where contact.SupplierName == nameSupplierContact
                                        select new SupplierContactDetailsModel
                                        {
                                            CardCode = contact.CardCode,
                                            SupplierName = contact.SupplierName,
                                            PhoneNumber = contact.PhoneNumber,
                                            CreatedAt = contact.CreatedAt,
                                            Active = contact.Active,
                                            CreatedBy = contact.CreatedBy,
                                            Id = contact.Id
                                        };
            return await supplierContact_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierContact"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(int idSupplierContact)
        {
            var supplierContact_query = from contact in _aDMStore.SupplierContacts
                                        where contact.Id == idSupplierContact
                                        select contact.Id;

            return await supplierContact_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSupplierContact"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(string nameSupplierContact, string cardCode)
        {
            var supplierContact_query = from contact in _aDMStore.SupplierContacts
                                        where contact.SupplierName == nameSupplierContact && contact.CardCode == cardCode
                                        select contact.Id;

            return await supplierContact_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        public async Task<List<SupplierContactDetailsModel>> ListAsync(string cardCode)
        {
            var supplierContact_query = from contact in _aDMStore.SupplierContacts
                                        where contact.CardCode == cardCode
                                        select new SupplierContactDetailsModel
                                        {
                                            CardCode = contact.CardCode,
                                            SupplierName = contact.SupplierName,
                                            PhoneNumber = contact.PhoneNumber,
                                            CreatedAt = contact.CreatedAt,
                                            Active = contact.Active,
                                            CreatedBy = contact.CreatedBy,
                                            Id = contact.Id
                                        };
            return await supplierContact_query.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactUpdateModel"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task UpdateAsync(SupplierContactUpdateModel contactUpdateModel)
        {
            var supplierContact = await _aDMStore.SupplierContacts.FirstOrDefaultAsync(contact => contact.Id == contactUpdateModel.Id).ConfigureAwait(false);
            if (supplierContact == null)
            {
                throw new NullReferenceException();
            }

            _aDMStore.SupplierContacts.Remove(supplierContact);

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
