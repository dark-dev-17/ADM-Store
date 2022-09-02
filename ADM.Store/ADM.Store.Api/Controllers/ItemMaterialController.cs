using ADM.Store.Models.Models.ItemMaterial;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemMaterialController : ControllerBase
    {
        private readonly ILogger<ItemMaterialController> _logger;
        private readonly IItemMaterialService _itemMaterialService;

        public ItemMaterialController(ILogger<ItemMaterialController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _itemMaterialService = serviceProvider.GetService<IItemMaterialService>();

            if (_itemMaterialService == null)
            {
                throw new ArgumentNullException(nameof(_itemMaterialService));
            }
        }

        [HttpGet("{idItemType}/list-itemMaterial")]
        [ProducesResponseType(typeof(List<ItemMaterialDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAsync(int idItemType)
        {
            return Ok(await _itemMaterialService.ListAsync(idItemType).ConfigureAwait(false));
        }
    }
}
