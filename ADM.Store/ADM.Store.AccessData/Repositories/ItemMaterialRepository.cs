using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemMaterial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Repositories
{
    internal class ItemMaterialRepository : IItemMaterialRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemMaterialRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }

        public async Task<bool> ExistsByNameInItemTypeAsync(string itemMaterialName, int idItemType)
        {
            if(string.IsNullOrWhiteSpace(itemMaterialName) || idItemType == 0)
            {
                return false;
            }

            return await _aDMStore.ItemMaterialCats
                .AnyAsync(material => material.MaterialName.ToLower().Trim() == itemMaterialName.ToLower().Trim() && material.ItemType == idItemType)
                .ConfigureAwait(false);
        }

        public async Task<bool> ExistsInItemTypeAsync(int idItemMaterial, int idItemType)
        {
            if (idItemMaterial  == 0 || idItemType == 0)
            {
                return false;
            }

            return await _aDMStore.ItemMaterialCats
                .AnyAsync(material => material.Id == idItemMaterial && material.ItemType == idItemType)
                .ConfigureAwait(false);
        }

        public async Task<List<ItemMaterialDetailsModel>> ListByItemTypeAsync(int idItemType)
        {
            if(idItemType == 0)
            {
                return new List<ItemMaterialDetailsModel>();
            }

            var query_materials = from material in _aDMStore.ItemMaterialCats where material.ItemType == idItemType select new ItemMaterialDetailsModel
            {
                Id = material.Id,
                MaterialName = material.MaterialName,
            };

            return await query_materials.ToListAsync().ConfigureAwait(false);
        }
    }
}
