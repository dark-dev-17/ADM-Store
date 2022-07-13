using ADM.Store.Models.Models.Proveedor;
using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ILogger<ProveedorController> _logger;
        private readonly IProveedorService _proveedorService;

        public ProveedorController(ILogger<ProveedorController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _proveedorService = serviceProvider.GetService<IProveedorService>();
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var resultListProveedores = await _proveedorService.ListAsync().ConfigureAwait(false);

            return Ok(resultListProveedores);
        }

        /// <summary>
        /// obtener detalles de un proveedor por idProveedor
        /// </summary>
        /// <param name="idProveedor">id del proveedor a obtener detalles</param>
        /// <returns></returns>
        [HttpGet("{idProveedor}")]
        public async Task<IActionResult> Details(Guid idProveedor)
        {
            var proveedor = await _proveedorService.GetByIdProveedorAsync(idProveedor).ConfigureAwait(false);

            if (proveedor is null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="proveedorCreate"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProveedorCreateModel proveedorCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please send valid information");
            }

            var resultProveedorCreated = await _proveedorService.CreateProveedorAsync(proveedorCreate).ConfigureAwait(false);

            switch (resultProveedorCreated)
            {
                case Service.Enums.ProcessActionResultTypes.Created:
                    return Ok(_proveedorService.GetIdProveedorCreated());
                default:
                    return BadRequest("invalid information");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProveedor"></param>
        /// <param name="proveedorUpdate"></param>
        /// <returns></returns>
        [HttpPut("{idProveedor}")]
        public async Task<IActionResult> Update(Guid idProveedor, ProveedorUpdateModel proveedorUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please send valid information");
            }

            var resultProveedorUpdate = await _proveedorService.UpdateByIdProveedorAsync(idProveedor, proveedorUpdate).ConfigureAwait(false);

            switch (resultProveedorUpdate)
            {
                case Service.Enums.ProcessActionResultTypes.Updated:
                    return Ok("update completed!");
                default:
                    return BadRequest("invalid information");
            }
        }
    }
}
