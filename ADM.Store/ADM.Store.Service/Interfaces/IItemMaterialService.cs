using ADM.Store.Models.Models.ItemMaterial;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Interfaces
{
    internal interface IItemMaterialService
    {
        public Task<List<ItemMaterialDetailsModel>> ListAsync(int idItemType);
    }
}
