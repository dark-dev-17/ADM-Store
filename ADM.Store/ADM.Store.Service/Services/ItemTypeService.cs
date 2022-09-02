using ADM.Store.Models.Models.ItemType;
using ADM.Store.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using ADM.Store.AccessData.Interfaces;
using Microsoft.Extensions.Logging;
using ADM.Store.Service.Exceptions;

[assembly: InternalsVisibleTo("ADM.Store.Api")]
namespace ADM.Store.Service.Services
{
    internal class ItemTypeService : IItemTypeService
    {
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly ILogger<ItemTypeService> _logger;

        public ItemTypeService(IItemTypeRepository itemTypeRepository, ILogger<ItemTypeService> logger)
        {
            _itemTypeRepository = itemTypeRepository ?? throw new ArgumentNullException(nameof(itemTypeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ItemTypeDetailsModel> DetailsAsync(int idItemType)
        {
            var itemType = await _itemTypeRepository.Details(idItemType).ConfigureAwait(false);

            if(itemType == null)
            {
                throw new ExceptionService(StatusCodeService.Status404NotFound, "Item type not found");
            }

            return itemType;
        }

        public async Task<List<ItemTypeDetailsModel>> ListAsync()
        {
            return await _itemTypeRepository.ListAsync().ConfigureAwait(false);
        }
    }
}
