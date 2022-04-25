using ADM.Store.Models.Models;
using ADM.Store.Service.Interfaces;
using ADM.Store.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAccountController : ControllerBase
    {
        private readonly ILogger<BookAccountController> _logger;
        private readonly IBookAccountService _bookAccountService;

        public BookAccountController(ILogger<BookAccountController> logger, IBookAccountService bookAccountService)
        {
            _logger = logger;
            _bookAccountService = bookAccountService;
        }
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] ClientCreateModel client)
        {
            if(client == null || client != null && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _bookAccountService.CreateClient(client).ConfigureAwait(false));
        }

        [HttpGet("{idClient}")]
        public async Task<IActionResult> GetBookAccounts(Guid idClient)
        {
            return Ok(await _bookAccountService.GetBookAccountsClient(idClient).ConfigureAwait(false));
        }

        [HttpGet("{idClient}/{idBookAccount}")]
        public async Task<IActionResult> GetBookAccountDetails(Guid idClient, int idBookAccount)
        {
            var result = await _bookAccountService.GetBookAccountDetails(idClient, idBookAccount).ConfigureAwait(false);

            if(result  == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        
        [HttpPost("{idClient}/abono")]
        public async Task<IActionResult> AddAbono([FromBody] AbonoCreateModel abono)
        {
            if (abono == null || abono != null && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _bookAccountService.AddAbono(abono).ConfigureAwait(false));
        }

        [HttpPost("{idClient}")]
        public async Task<IActionResult> CreateAccount([FromBody] BookAccountCreateModel newBookAccount)
        {
            if (newBookAccount == null || newBookAccount != null && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _bookAccountService.CreateBookAccount(newBookAccount).ConfigureAwait(false));
        }

        [HttpPost("{idClient}/sale")]
        public async Task<IActionResult> AddSale([FromBody] SaleCreateModel sale)
        {
            if (sale == null || sale != null && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(await _bookAccountService.AddSale(sale).ConfigureAwait(false));
        }



        [HttpDelete("{idBookAccount}/sale/{idBookAccountDetails}")]
        public async Task<IActionResult> DeleteSale(int idBookAccount, int idBookAccountDetails)
        {
            return Ok(await _bookAccountService.DeleteSale(idBookAccount, idBookAccountDetails).ConfigureAwait(false));
        }

        [HttpDelete("{idBookAccount}/abono/{idBookAccountDetails}")]
        public async Task<IActionResult> DeleteAbono(int idBookAccount, int idBookAccountDetails)
        {
            return Ok(await _bookAccountService.DeleteAbono(idBookAccount, idBookAccountDetails).ConfigureAwait(false));
        }
    }
}
