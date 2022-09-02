using ADM.Store.Models.Models.ItemCategory;
using ADM.Store.Models.Models.ItemSubCategory;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly ILogger<ItemCategoryController> _logger;
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(ILogger<ItemCategoryController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _itemCategoryService = serviceProvider.GetService<IItemCategoryService>();

            if (_itemCategoryService == null)
            {
                throw new ArgumentNullException(nameof(_itemCategoryService));
            }
        }

        [HttpPost("{idItemType}/register-category")]
        [ProducesResponseType(typeof(ItemCategoryDetailsModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateCategoryAsync(int idItemType, [FromBody] ItemCategoryCreateModel itemCategoryCreate)
        {
            try
            {
                var categoryIdCreated = await _itemCategoryService.CreateAsync(idItemType, itemCategoryCreate).ConfigureAwait(false);

                return CreatedAtAction(nameof(DetailsCategoryAsync), new { idItemType = idItemType, idItemCategory = categoryIdCreated });
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

        [HttpGet("{idItemType}/{idItemCategory}")]
        [ProducesResponseType(typeof(ItemCategoryDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsCategoryAsync(int idItemType, int idItemCategory)
        {
            try
            {
                var categoryDetails = await _itemCategoryService.DetailsAsync(idItemType, idItemCategory).ConfigureAwait(false);

                return Ok(categoryDetails);
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

        [HttpGet("{idItemType}/list-categories")]
        [ProducesResponseType(typeof(List<ItemCategoryDetailsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListCategoryAsync(int idItemType)
        {
            try
            {
                var categoryList = await _itemCategoryService.ListByTypeItemAsync(idItemType).ConfigureAwait(false);

                return Ok(categoryList);
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

        [HttpPut("{idItemType}/{idItemCategory}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCategoryAsync(int idItemType, int idItemCategory, [FromBody] ItemCategoryUpdateModel itemCategoryUpdate)
        {
            try
            {
                var categoryList = await _itemCategoryService.UpdateAsync(idItemType, idItemCategory, itemCategoryUpdate).ConfigureAwait(false);

                return Ok(categoryList);
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

        [HttpGet("{idItemType}/{idItemCategory}/list-subCategories")]
        [ProducesResponseType(typeof(List<ItemSubCategoryDetailsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSubCategoryAsync(int idItemType, int idItemCategory)
        {
            try
            {
                var subCategoryList = await _itemCategoryService.ListSubCategoryAsync(idItemType, idItemCategory).ConfigureAwait(false);

                return Ok(subCategoryList);
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

        [HttpGet("{idItemType}/{idItemCategory}/{idSubCategory}")]
        [ProducesResponseType(typeof(ItemSubCategoryDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsSubCategoryAsync(int idItemType, int idItemCategory, int idSubCategory)
        {
            try
            {
                var subCategoryDetails = await _itemCategoryService.DetailsSubCategoryAsync(idItemType, idItemCategory, idSubCategory).ConfigureAwait(false);

                return Ok(subCategoryDetails);
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

        [HttpPost("{idItemType}/{idItemCategory}/register-subCategory")]
        [ProducesResponseType(typeof(ItemSubCategoryDetailsModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddSubCategoryAsync(int idItemType, int idItemCategory, [FromBody] ItemSubCategoryCreateModel itemSubCategoryCreate)
        {
            try
            {
                var subCategoryIdCreated = await _itemCategoryService.AddSubCategoryAsync(idItemType, itemSubCategoryCreate).ConfigureAwait(false);

                return CreatedAtAction(nameof(DetailsSubCategoryAsync), new { idItemType = idItemType, idItemCategory = idItemCategory, idSubCategory = subCategoryIdCreated });
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

        [HttpPut("{idItemType}/{idItemCategory}/{idSubCategory}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSubCategoryAsync(int idItemType, int idItemCategory, int idSubCategory, ItemSubCategoryUpdateModel itemSubCategoryUpdate)
        {
            try
            {
                var subCategoryIdCreated = await _itemCategoryService.UpdateSubCategoryAsync(idItemType, itemSubCategoryUpdate).ConfigureAwait(false);

                return Ok("Sub category updated");
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
