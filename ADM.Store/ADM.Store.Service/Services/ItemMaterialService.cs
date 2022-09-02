using ADM.Store.AccessData.Interfaces;
using ADM.Store.Models.Models.ItemMaterial;
using ADM.Store.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ItemMaterialService : IItemMaterialService
    {
        private readonly IItemMaterialRepository _itemMaterialRepository;
        private readonly ILogger<ItemMaterialService> _logger;

        public ItemMaterialService(IItemMaterialRepository itemMaterialRepository, ILogger<ItemMaterialService> logger)
        {
            _itemMaterialRepository = itemMaterialRepository ?? throw new ArgumentNullException(nameof(itemMaterialRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<ItemMaterialDetailsModel>> ListAsync(int idItemType)
        {
            return await _itemMaterialRepository.ListByItemTypeAsync(idItemType).ConfigureAwait(false);
        }
    }
}
