using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.SupplierLocation;
using ADM.Store.AccessData.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

[assembly: InternalsVisibleTo("ADM.Store.Service")]
namespace ADM.Store.AccessData.Repositories
{
    internal class SupplierLocationRepository : ISupplierLocationRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public SupplierLocationRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierLocationCreate"></param>
        /// <returns></returns>
        public async Task<int> CreateAsync(SupplierLocationCreateModel supplierLocationCreate)
        {
            var newSupplierLocation = new SupplierLocation
            {
                CardCode = supplierLocationCreate.CardCode,
                LocationName = supplierLocationCreate.LocationName,
                LocationAddress = supplierLocationCreate.LocationAddress,
                ReferencesCo = supplierLocationCreate.ReferencesCo,
                Town = supplierLocationCreate.Town,
                ZipCode = supplierLocationCreate.ZipCode,
                StateName = supplierLocationCreate.StateName,
                // TODO service-user
                CreatedBy = "USER-SYS",
                Active = supplierLocationCreate.Active,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _aDMStore.SupplierLocations.AddAsync(newSupplierLocation).ConfigureAwait(false);

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newSupplierLocation.Id;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierLocation"></param>
        /// <returns></returns>
        public async Task<SupplierLocationDetailsModel?> DetailsAsync(int idSupplierLocation)
        {
            var supplierLocation_query = from location in _aDMStore.SupplierLocations
                                         where location.Id == idSupplierLocation
                                         select new SupplierLocationDetailsModel
                                         {
                                             Id = location.Id,
                                             CardCode = location.CardCode,
                                             LocationName = location.LocationName,
                                             LocationAddress = location.LocationAddress,
                                             Active = location.Active,
                                             CreatedAt = location.CreatedAt,
                                             UpdatedAt = location.UpdatedAt,
                                             StateName=location.StateName,
                                             CreatedBy=location.CreatedBy,
                                             Town = location.Town,
                                             ReferencesCo = location.ReferencesCo,
                                             ZipCode = location.ZipCode
                                         };
            return await supplierLocation_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierLocationName"></param>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        public async Task<SupplierLocationDetailsModel?> DetailsAsync(string supplierLocationName, string cardCode)
        {
            var supplierLocation_query = from location in _aDMStore.SupplierLocations
                                         where location.LocationName == supplierLocationName && location.CardCode == cardCode
                                         select new SupplierLocationDetailsModel
                                         {
                                             Id = location.Id,
                                             CardCode = location.CardCode,
                                             LocationName = location.LocationName,
                                             LocationAddress = location.LocationAddress,
                                             Active = location.Active,
                                             CreatedAt = location.CreatedAt,
                                             UpdatedAt = location.UpdatedAt,
                                             StateName = location.StateName,
                                             CreatedBy = location.CreatedBy,
                                             Town = location.Town,
                                             ReferencesCo = location.ReferencesCo,
                                             ZipCode = location.ZipCode
                                         };
            return await supplierLocation_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSupplierLocation"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(int idSupplierLocation)
        {
            var supplierLocation_query = from location in _aDMStore.SupplierLocations
                                         where location.Id == idSupplierLocation
                                         select location.Id;
            return await supplierLocation_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierLocationName"></param>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        public async Task<int> ExistsAsync(string supplierLocationName, string cardCode)
        {
            var supplierLocation_query = from location in _aDMStore.SupplierLocations
                                         where location.LocationName == supplierLocationName && location.CardCode == cardCode
                                         select location.Id;
            return await supplierLocation_query.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardCode"></param>
        /// <returns></returns>
        public async Task<List<SupplierLocationDetailsModel>> ListAsync(string cardCode)
        {
            var supplierLocation_query = from location in _aDMStore.SupplierLocations
                                         where location.CardCode == cardCode
                                         select new SupplierLocationDetailsModel
                                         {
                                             Id = location.Id,
                                             CardCode = location.CardCode,
                                             LocationName = location.LocationName,
                                             LocationAddress = location.LocationAddress,
                                             Active = location.Active,
                                             CreatedAt = location.CreatedAt,
                                             UpdatedAt = location.UpdatedAt,
                                             StateName = location.StateName,
                                             CreatedBy = location.CreatedBy,
                                             Town = location.Town,
                                             ReferencesCo = location.ReferencesCo,
                                             ZipCode = location.ZipCode
                                         };
            return await supplierLocation_query.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="supplierLocationUpdate"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task UpdateAsync(SupplierLocationUpdateModel supplierLocationUpdate)
        {
            var supplierLocation = await _aDMStore.SupplierLocations.FirstOrDefaultAsync(location => location.Id == supplierLocationUpdate.Id).ConfigureAwait(false);

            if (supplierLocation == null)
            {
                throw new NullReferenceException();
            }
            
            supplierLocation.LocationName = supplierLocationUpdate.LocationName;
            supplierLocation.LocationAddress = supplierLocationUpdate.LocationAddress;
            supplierLocation.Active = supplierLocationUpdate.Active;
            supplierLocation.StateName = supplierLocationUpdate.StateName;
            supplierLocation.Town = supplierLocationUpdate.Town;
            supplierLocation.ReferencesCo = supplierLocationUpdate.ReferencesCo;
            supplierLocation.ZipCode = supplierLocationUpdate.ZipCode;

            _aDMStore.SupplierLocations.Update(supplierLocation);

            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
