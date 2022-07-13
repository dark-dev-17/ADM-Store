using ADM.Store.Models.Models.Compra;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ICompraService _compraService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CompraController(ILogger<CompraController> logger, IServiceProvider serviceProvider)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _logger = logger;
#pragma warning disable CS8601 // Possible null reference assignment.
            _compraService = serviceProvider.GetService<ICompraService>();
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompra(CompraCreateModel compraCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultCreateCompra = await _compraService.CreateCompraAsync(compraCreate).ConfigureAwait(false);

            if (resultCreateCompra == Service.Enums.CreateResultTypes.RelationNotFound)
            {
                return NotFound("please verify your data, some references not exits");
            }

            var idCompraCreated = _compraService.GetIdCompraCreated();

            return Ok(idCompraCreated);
        }

        [HttpGet("{idCompra}")]
        public async Task<IActionResult> DetailsCompra(Guid idCompra)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError("idCompra is required", idCompra);
                return BadRequest("please selected a compra valid");
            }

            _logger.LogInformation($"idCompra received successfylly", idCompra);

            var resultCompra = await _compraService.DetailsCompraAsync(idCompra).ConfigureAwait(false);

            if(resultCompra == null)
            {
                return NotFound();
            }

            return Ok(resultCompra);
        }

        [HttpPut("{idCompra}")]
        public async Task<IActionResult> UpdateCompra(Guid idCompra, CompraUpdateModel compraUpdate)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError("idCompra is required", idCompra);
                return BadRequest("please selected a compra valid");
            }

            _logger.LogInformation($"idCompra received successfylly", idCompra);

            if (idCompra != compraUpdate.Id)
            {
                return BadRequest("the request not match with compra references");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("data invalid, please verify it");
            }

            var resultCompra = await _compraService.UpdateCompraAsync(idCompra, compraUpdate).ConfigureAwait(false);

            switch (resultCompra)
            {
                case Service.Enums.ProcessActionResultTypes.Updated:
                    return Ok("Deleted completed!");
                case Service.Enums.ProcessActionResultTypes.NotFound:
                    return NotFound("the item was not found in the compra!");
                default:
                    return BadRequest("invalid information");
            }
        }

        [HttpPost("{idCompra}/Items")]
        public async Task<IActionResult> AddItemInCompra(Guid idCompra, CompraLineaCreateModel compraLineaCreate)
        {
            if(idCompra != compraLineaCreate.IdCompra)
            {
                return BadRequest("the request not match with compra references");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("data invalid, please verify it");
            }

            var resultAddItemToCompra = await _compraService.AddItemAsync(idCompra,compraLineaCreate).ConfigureAwait(false);

            if (resultAddItemToCompra == Service.Enums.CreateResultTypes.RelationNotFound)
            {
                return NotFound("please verify your data, some references not exits");
            }

            var idItemCreated = _compraService.GetNewIdItemAdded();

            var newItemDetails = await _compraService.DetailsItemInCompra(idCompra, idItemCreated).ConfigureAwait(false); ;

            return Ok(newItemDetails);
        }

        [HttpGet("{idCompra}/Items/{idCompraLinea}")]
        public async Task<IActionResult> DetailsItemInCompra(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError("idCompra is required", idCompra);
                return BadRequest("please selected a compra valid");
            }

            _logger.LogInformation($"idCompra received successfylly", idCompra);

            if(idCompraLinea == Guid.Empty)
            {
                _logger.LogError("idCompraLinea is required", idCompraLinea);
                return BadRequest("please selected a compra item valid");
            }

            _logger.LogInformation($"idCompraLinea received successfylly", idCompraLinea);

            var detailsItem = await _compraService.DetailsItemInCompra(idCompra, idCompraLinea).ConfigureAwait(false);

            if (detailsItem == null)
            {
                return NotFound();
            }

            return Ok(detailsItem);
        }

        [HttpDelete("{idCompra}/Items/{idCompraLinea}")]
        public async Task<IActionResult> DeleteItemInCompra(Guid idCompra, Guid idCompraLinea)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError("idCompra is required", idCompra);
                return BadRequest("please selected a compra valid");
            }

            _logger.LogInformation($"idCompra received successfylly", idCompra);

            if (idCompraLinea == Guid.Empty)
            {
                _logger.LogError("idCompraLinea is required", idCompraLinea);
                return BadRequest("please selected a compra item valid");
            }

            _logger.LogInformation($"idCompraLinea received successfylly", idCompraLinea);

            var detailsItem = await _compraService.DeleteItemAsync(idCompra, idCompraLinea).ConfigureAwait(false);

            switch (detailsItem)
            {
                case Service.Enums.DeleteResultTypes.Deleted:
                    return Ok("Deleted completed!");
                case Service.Enums.DeleteResultTypes.NotFound:
                    return NotFound("the item was not found in the compra!");
                default:
                    return BadRequest("invalid information");
            }
        }

        [HttpPut("{idCompra}/Items/{idCompraLinea}")]
        public async Task<IActionResult> UpdateItemInCompra(Guid idCompra, Guid idCompraLinea, CompraLineaUpdateModel compraLineaUpdate)
        {
            if (idCompra == Guid.Empty)
            {
                _logger.LogError("idCompra is required", idCompra);
                return BadRequest("please selected a compra valid");
            }

            _logger.LogInformation($"idCompra received successfylly", idCompra);

            if (idCompraLinea == Guid.Empty)
            {
                _logger.LogError("idCompraLinea is required", idCompraLinea);
                return BadRequest("please selected a compra item valid");
            }

            _logger.LogInformation($"idCompraLinea received successfylly", idCompraLinea);

            if (!ModelState.IsValid)
            {
                return BadRequest("information bad");
            }

            var detailsItem = await _compraService.UpdateItemAsync(idCompra, idCompraLinea, compraLineaUpdate).ConfigureAwait(false);

            if (detailsItem == null)
            {
                return NotFound();
            }

            return Ok(detailsItem);
           
        }

    }
}
