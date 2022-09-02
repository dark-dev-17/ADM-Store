﻿using ADM.Store.Models.Models.SupplierLocation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Service")]


namespace ADM.Store.AccessData.Interfaces
{
    internal interface ISupplierLocationRepository
    {
        public Task<int> CreateAsync(SupplierLocationCreateModel supplierLocationCreate);
        public Task<SupplierLocationDetailsModel> DetailsAsync(int idSupplierLocation);
        public Task<SupplierLocationDetailsModel> DetailsAsync(string supplierLocationName);
        public Task<int> ExistsAsync(int idSupplierLocation);
        public Task<int> ExistsAsync(string supplierLocationName);
        public Task<List<SupplierLocationDetailsModel>> ListAsync(string cardCode);
        public Task<int> UpdateAsync(SupplierLocationUpdateModel supplierLocationUpdate);

    }
}