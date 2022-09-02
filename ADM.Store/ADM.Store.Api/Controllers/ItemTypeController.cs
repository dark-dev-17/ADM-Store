using ADM.Store.Models.Models.ItemType;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly ILogger<ItemTypeController> _logger;
        private readonly IItemTypeService _itemTypeService;

        public ItemTypeController(ILogger<ItemTypeController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _itemTypeService = serviceProvider.GetService<IItemTypeService>();

            if (_itemTypeService == null)
            {
                throw new ArgumentNullException(nameof(_itemTypeService));
            }
        }

        [HttpGet("list-itemType")]
        [ProducesResponseType(typeof(List<ItemTypeDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _itemTypeService.ListAsync().ConfigureAwait(false));
        }
    }
}
