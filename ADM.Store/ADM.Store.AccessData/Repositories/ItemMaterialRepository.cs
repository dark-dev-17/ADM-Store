using ADM.Store.AccessData.Entities;
using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemMaterial;
using Microsoft.EntityFrameworkCore;

namespace ADM.Store.AccessData.Repositories
{
    internal class ItemMaterialRepository : IItemMaterialRepository
    {
        private readonly ADMStoreContext _aDMStore;

        public ItemMaterialRepository(ADMStoreContext aDMStore)
        {
            _aDMStore = aDMStore;
        }
        /// <summary>
        /// Create new item material
        /// </summary>
        /// <param name="itemMaterialName">name for the new item material</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<int> CreateAsync(string itemMaterialName, int idItemType)
        {
            var newItemMaterial = new ItemMaterialCat
            {
                MaterialName = itemMaterialName,
                ItemType = idItemType,
            };

            await _aDMStore.ItemMaterialCats.AddAsync(newItemMaterial).ConfigureAwait(false);
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return newItemMaterial.Id;
        }
        /// <summary>
        /// delete item material
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to delete</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int idItemMaterial, int idItemType)
        {
            var deleteItemMaterial = await _aDMStore.ItemMaterialCats
                .FirstOrDefaultAsync(mat => mat.Id == idItemMaterial && mat.ItemType == idItemType)
                .ConfigureAwait(false);
            if (deleteItemMaterial != null)
            {
                _aDMStore.ItemMaterialCats.Remove(deleteItemMaterial);
                await _aDMStore.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// get details for the item material selected in the type of item
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to get details</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<ItemMaterialDetailsModel?> DetailsAsync(int idItemMaterial, int idItemType)
        {
            var query_materials = from material in _aDMStore.ItemMaterialCats
                                  where material.ItemType == idItemType && material.Id == idItemMaterial
                                  select new ItemMaterialDetailsModel
                                  {
                                      Id = material.Id,
                                      MaterialName = material.MaterialName,
                                  };

            return await query_materials.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// verify by name if exists an item material in the type of item selected
        /// </summary>
        /// <param name="itemMaterialName">name for the item material to verify</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<int> ExistsByNameInItemTypeAsync(string itemMaterialName, int idItemType)
        {
            if (string.IsNullOrWhiteSpace(itemMaterialName) || idItemType == 0)
            {
                return 0;
            }

            var query_material = from material in _aDMStore.ItemMaterialCats where material.MaterialName.ToLower().Trim() == itemMaterialName.ToLower().Trim() && material.ItemType == idItemType select material.Id;

            return await query_material.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// verify by id if exists an item material in the type of item selected
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to verify</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<int> ExistsInItemTypeAsync(int idItemMaterial, int idItemType)
        {
            if (idItemMaterial == 0 || idItemType == 0)
            {
                return 0;
            }

            var query_material = from material in _aDMStore.ItemMaterialCats where material.Id == idItemMaterial && material.ItemType == idItemType select material.Id;

            return await query_material.FirstOrDefaultAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// list item materials by type of item
        /// </summary>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        public async Task<List<ItemMaterialDetailsModel>> ListByItemTypeAsync(int idItemType)
        {
            if (idItemType == 0)
            {
                return new List<ItemMaterialDetailsModel>();
            }

            var query_materials = from material in _aDMStore.ItemMaterialCats
                                  where material.ItemType == idItemType
                                  select new ItemMaterialDetailsModel
                                  {
                                      Id = material.Id,
                                      MaterialName = material.MaterialName,
                                  };

            return await query_materials.ToListAsync().ConfigureAwait(false);
        }
        /// <summary>
        /// update an item material based on the id
        /// </summary>
        /// <param name="itemMaterialName">new name for the item material</param>
        /// <param name="idItemMaterial">if for update</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(string itemMaterialName, int idItemMaterial)
        {
            if (string.IsNullOrWhiteSpace(itemMaterialName) || idItemMaterial == 0)
            {
                return false;
            }

            var itemMaterial = await _aDMStore.ItemMaterialCats.FirstOrDefaultAsync(material => material.Id == idItemMaterial).ConfigureAwait(false);

            if (itemMaterial == null)
            {
                return false;
            }

            itemMaterial.MaterialName = itemMaterialName;
            await _aDMStore.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
