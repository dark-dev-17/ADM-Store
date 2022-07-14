using ADM.Store.Models.Models.ItemMaterial;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemMaterialRepository
    {
        /// <summary>
        /// Create new item material
        /// </summary>
        /// <param name="itemMaterialName">name for the new item material</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<int> CreateAsync(string itemMaterialName, int idItemType);
        /// <summary>
        /// delete item material
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to delete</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int idItemMaterial, int idItemType);
        /// <summary>
        /// get details for the item material selected in the type of item
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to get details</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<ItemMaterialDetailsModel?> DetailsAsync(int idItemMaterial, int idItemType);
        /// <summary>
        /// verify by name if exists an item material in the type of item selected
        /// </summary>
        /// <param name="itemMaterialName">name for the item material to verify</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<int> ExistsByNameInItemTypeAsync(string itemMaterialName, int idItemType);
        /// <summary>
        /// verify by id if exists an item material in the type of item selected
        /// </summary>
        /// <param name="idItemMaterial">id for the item material to verify</param>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<int> ExistsInItemTypeAsync(int idItemMaterial, int idItemType);
        /// <summary>
        /// list item materials by type of item
        /// </summary>
        /// <param name="idItemType">id for type of item</param>
        /// <returns></returns>
        Task<List<ItemMaterialDetailsModel>> ListByItemTypeAsync(int idItemType);
        /// <summary>
        /// update an item material based on the id
        /// </summary>
        /// <param name="itemMaterialName">new name for the item material</param>
        /// <param name="idItemMaterial">if for update</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(string itemMaterialName, int idItemMaterial);
    }
}
