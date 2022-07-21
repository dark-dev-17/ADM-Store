using ADM.Store.Models.Models.Item;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<ItemController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _itemService = serviceProvider.GetService<IItemService>();


            if (_itemService == null)
            {
                throw new ArgumentNullException(nameof(_itemService));
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ItemCreateModel itemCreate)
        {
            try
            {
                var itemDetails = await _itemService.CreateAsync(itemCreate).ConfigureAwait(false);

                return CreatedAtAction(nameof(DetailsAsync),new { itemCode = itemDetails.ItemCode });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceptionService ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{itemCode}")]
        public async Task<IActionResult> DeleteAsync(string itemCode)
        {
            try
            {
                var itemDetails = await _itemService.DeleteAsync(itemCode).ConfigureAwait(false);

                return Ok($"The item [{itemCode}] was deleted successfully");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceptionService ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("{itemCode}")]
        public async Task<IActionResult> DetailsAsync(string itemCode)
        {
            try
            {
                var itemDetails = await _itemService.DetailsAsync(itemCode).ConfigureAwait(false);

                return Ok(itemDetails);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceptionService ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var itemDetails = await _itemService.ListAsync().ConfigureAwait(false);

            return Ok(itemDetails);
        }

        [HttpPut("{itemCode}")]
        public async Task<IActionResult> UpdateAsync(string itemCode, [FromBody] ItemUpdateModel updateModel)
        {
            try
            {
                var itemDetails = await _itemService.UpdateAsync(itemCode, updateModel).ConfigureAwait(false);
                if (itemDetails)
                {
                    return Ok(itemDetails);
                }
                else
                {
                    return BadRequest($"The item: [{itemCode}] was not saved");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceptionService ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
