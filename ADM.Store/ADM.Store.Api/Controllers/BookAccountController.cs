using ADM.Store.Models.Models;
using ADM.Store.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAccountController : ControllerBase
    {
        private readonly ILogger<BookAccountController> _logger;

        public BookAccountController(ILogger<BookAccountController> logger)
        {
            _logger = logger;
        }
            }
}
