using ADM.Store.Models.Models.Item;
using ADM.Store.Models.Models.ItemOption;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemCreate"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(ItemDetailsModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExceptionService ex)
            {
                if (ex.ErrorCode == 404)
                {
                    return NotFound(ex.Message);
                }
                else if (ex.ErrorCode == 409)
                {
                    return Conflict(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{itemCode}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(string itemCode)
        {
            try
            {
                var itemDetails = await _itemService.DeleteAsync(itemCode).ConfigureAwait(false);

                return Ok($"The item [{itemCode}] was deleted successfully");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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
        [ProducesResponseType(typeof(ItemDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsAsync(string itemCode)
        {
            try
            {
                var itemDetails = await _itemService.DetailsAsync(itemCode).ConfigureAwait(false);

                return Ok(itemDetails);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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
        [ProducesResponseType(typeof(List<ItemDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAsync()
        {
            var itemDetails = await _itemService.ListAsync().ConfigureAwait(false);

            return Ok(itemDetails);
        }

        [HttpPut("{itemCode}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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

        [HttpPost("{itemCode}/register")]
        [ProducesResponseType(typeof(ItemOptionDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddOptionAsync(string itemCode, [FromBody] ItemOptionCreateModel optionCreate)
        {
            try
            {
                var itemDetails = await _itemService.AddOptionAsync(itemCode, optionCreate).ConfigureAwait(false);

                return CreatedAtAction(nameof(DetailsOptionAsync), new { itemCode = itemCode, variation = optionCreate.Variation });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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
                }else if(ex.ErrorCode == 409)
                {
                    return Conflict(ex.Message);
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet("{itemCode}/{variation}")]
        [ProducesResponseType(typeof(ItemOptionDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsOptionAsync(string itemCode, string variation)
        {
            try
            {
                var itemDetails = await _itemService.DetailsOptionAsync(itemCode, variation).ConfigureAwait(false);

                return Ok(itemDetails);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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

        [HttpGet("{itemCode}/list-variations")]
        [ProducesResponseType(typeof(List<ItemOptionDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListOptionAsync(string itemCode)
        {
            var itemDetails = await _itemService.ListOptionAsync(itemCode).ConfigureAwait(false);

            return Ok(itemDetails);
        }

        [HttpDelete("{itemCode}/{variation}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOptionAsync(string itemCode, string variation)
        {
            try
            {
                var itemDetails = await _itemService.DeleteOptionAsync(itemCode, variation).ConfigureAwait(false);

                return Ok($"The item [{itemCode}] was deleted successfully");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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

        [HttpPut("{itemCode}/{variation}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOptionAsync(string itemCode, string variation, [FromBody] ItemOptionUpdateModel updateModel)
        {
            try
            {
                var itemDetails = await _itemService.UpdateOptionAsync(itemCode, variation, updateModel).ConfigureAwait(false);
                if (itemDetails)
                {
                    return Ok("variant updated");
                }
                else
                {
                    return BadRequest($"The item: [{itemCode}] was not saved");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
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
