using ADM.Store.Models.Models.ItemMaterial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM.Store.AccessData.Interfaces
{
    internal interface IItemMaterialRepository
    {
        Task<List<ItemMaterialDetailsModel>> ListByItemTypeAsync(int idItemType);
        Task<bool> ExistsInItemTypeAsync(int idItemMaterial, int idItemType);
        Task<bool> ExistsByNameInItemTypeAsync(string itemMaterialName, int idItemType);
    }
}
