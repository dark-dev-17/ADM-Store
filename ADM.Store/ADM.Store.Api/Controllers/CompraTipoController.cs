using ADM.Store.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraTipoController : ControllerBase
    {
        private readonly ILogger<CompraTipoController> _logger;
        private readonly ICompraTipoService _compraTipoService;

        public CompraTipoController(ILogger<CompraTipoController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _compraTipoService = serviceProvider.GetService<ICompraTipoService>();
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            var resultListProveedores = await _compraTipoService.List().ConfigureAwait(false);

            return Ok(resultListProveedores);
        }
    }
}
