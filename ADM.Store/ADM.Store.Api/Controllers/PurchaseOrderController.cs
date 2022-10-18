using ADM.Store.Models.Models.PurchaseOrder;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _purchaseOrderService = serviceProvider.GetService<IPurchaseOrderService>();

            if (_purchaseOrderService == null)
            {
                throw new ArgumentNullException(nameof(_purchaseOrderService));
            }
        }

        [HttpPost("create-purchase-order")]
        [ProducesResponseType(typeof(PurchaseOrderDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePurchaseOrderAsync([FromBody] PurchaseOrderCreateModel orderCreateModel)
        {
            try
            {
                var docNumCreated = await _purchaseOrderService.CreateAsync(orderCreateModel).ConfigureAwait(false);
                return Ok(await _purchaseOrderService.DetailsAsync(docNumCreated).ConfigureAwait(false));
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

        [HttpGet("details-purchase-order/{docNum}")]
        [ProducesResponseType(typeof(PurchaseOrderDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsPurchaseOrderAsync(int docNum)
        {
            try
            {
                return Ok(await _purchaseOrderService.DetailsAsync(docNum).ConfigureAwait(false));
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
        
        [HttpGet("list-purchase-orders")]
        [ProducesResponseType(typeof(List<PurchaseOrderBasicDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListPurchaseOrderAsync()
        {
            return Ok(await _purchaseOrderService.ListAsync().ConfigureAwait(false));
        }

        [HttpPut("update-purchase-order/{docNum}")]
        public async Task<IActionResult> UpdatePurchaseOrder(int docNum, [FromBody] PurchaseOrderUpdateModel orderUpdateModel)
        {
            try
            {
                await _purchaseOrderService.UpdateAsync(docNum,orderUpdateModel).ConfigureAwait(false);
                return Ok("Process complete!");
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
