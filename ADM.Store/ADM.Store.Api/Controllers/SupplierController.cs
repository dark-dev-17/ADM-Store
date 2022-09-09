using ADM.Store.Models.Models.Supplier;
using ADM.Store.Models.Models.SupplierContact;
using ADM.Store.Models.Models.SupplierLocation;
using ADM.Store.Models.Models.SupplierStatus;
using ADM.Store.Service.Exceptions;
using ADM.Store.Service.Interfaces.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierService _supplierService;
        private readonly ISupplierStatusService _supplierStatusService;
        private readonly ISupplierLocationService _supplierLocationService;
        private readonly ISupplierContactService _supplierContactService;

        public SupplierController(ILogger<SupplierController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _supplierService = serviceProvider.GetService<ISupplierService>();
            _supplierStatusService = serviceProvider.GetService<ISupplierStatusService>();
            _supplierLocationService = serviceProvider.GetService<ISupplierLocationService>();
            _supplierContactService = serviceProvider.GetService<ISupplierContactService>();


            if (_supplierService == null)
            {
                throw new ArgumentNullException(nameof(_supplierService));
            }
            if (_supplierStatusService == null)
            {
                throw new ArgumentNullException(nameof(_supplierService));
            }
            if (_supplierLocationService == null)
            {
                throw new ArgumentNullException(nameof(_supplierService));
            }
            if (_supplierContactService == null)
            {
                throw new ArgumentNullException(nameof(_supplierService));
            }
        }

        //~/list-suppliers
        [HttpGet("list-suppliers")]
        [ProducesResponseType(typeof(List<SupplierDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListSuppliersAsync()
        {
            var itemDetails = await _supplierService.ListAsync().ConfigureAwait(false);

            return Ok(itemDetails);
        }
        
        //~/list-status
        [HttpGet("list-status")]
        [ProducesResponseType(typeof(List<SupplierStatusDetailsModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListStatusAsync()
        {
            var itemDetails = await _supplierStatusService.ListAsync().ConfigureAwait(false);

            return Ok(itemDetails);
        }
        
        //~/register
        [HttpPost("register")]
        [ProducesResponseType(typeof(SupplierDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateSupplierAsync([FromBody] SupplierCreateModel supplierCreate)
        {
            try
            {
                var supplierDetailsCreated = await _supplierService.CreateAsync(supplierCreate).ConfigureAwait(false);

                return Ok(supplierDetailsCreated);
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
        
        //~/{cardCode} details
        [HttpGet("{cardCode}/details")]
        [ProducesResponseType(typeof(SupplierDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsSupplierAsync(string cardCode)
        {
            try
            {
                var supplierDetails = await _supplierService.DetailsAsync(cardCode).ConfigureAwait(false);

                return Ok(supplierDetails);
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

        //~/{cardCode} update
        [HttpPut("{cardCode}/update")]
        [ProducesResponseType(typeof(SupplierDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSupplierAsync(string cardCode, [FromBody] SupplierUpdateModel supplierUpdate)
        {
            try
            {
                await _supplierService.UpdateAsync(cardCode, supplierUpdate).ConfigureAwait(false);

                return Ok("Proveedor actualizado");
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


        //~/{cardCode}/list-locations
        [HttpGet("{cardCode}/list-locations")]
        [ProducesResponseType(typeof(List<SupplierLocationDetailsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListLocationAsync(string cardCode)
        {
            try
            {
                var listLOcations = await _supplierLocationService.ListAsync(cardCode).ConfigureAwait(false);

                return Ok(listLOcations);
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

        //~/{cardCode}/location/{idLocation} details
        [HttpGet("{cardCode}/location/{idLocation}")]
        [ProducesResponseType(typeof(SupplierLocationDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsLocationAsync(string cardCode, int idLocation)
        {
            try
            {
                var supplierDetails = await _supplierLocationService.DetailsAsync(cardCode, idLocation).ConfigureAwait(false);

                return Ok(supplierDetails);
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
        //~/{cardCode}/location/register
        [HttpPost("{cardCode}/location/register")]
        [ProducesResponseType(typeof(SupplierLocationDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateLocationAsync(string cardCode, [FromBody] SupplierLocationCreateModel locationCreate)
        {
            try
            {
                var LocationDetailsCreated = await _supplierLocationService.CreateAsync(locationCreate).ConfigureAwait(false);

                return Ok(LocationDetailsCreated);
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
        //~/{cardCode}/location/{idLocation} update
        [HttpPut("{cardCode}/location/{idLocation}")]
        [ProducesResponseType(typeof(SupplierDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLocationAsync(string cardCode, int idLocation, [FromBody] SupplierLocationUpdateModel locationUpdate)
        {
            try
            {
                await _supplierLocationService.UpdateAsync(locationUpdate).ConfigureAwait(false);

                return Ok("Ubicacion actualizada");
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


        //~/{cardCode}/list-contacts
        [HttpGet("{cardCode}/list-contacts")]
        [ProducesResponseType(typeof(List<SupplierContactDetailsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListContactAsync(string cardCode)
        {
            try
            {
                var listContact = await _supplierContactService.ListAsync(cardCode).ConfigureAwait(false);

                return Ok(listContact);
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
        //~/{cardCode}/contact/{idContact} details
        [HttpGet("{cardCode}/contact/{idContact}")]
        [ProducesResponseType(typeof(SupplierLocationDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DetailsContactAsync(string cardCode, int idContact)
        {
            try
            {
                var supplierDetails = await _supplierContactService.DetailsAsync(cardCode, idContact).ConfigureAwait(false);

                return Ok(supplierDetails);
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
        //~/{cardCode}/contact/register
        [HttpPost("{cardCode}/contact/register")]
        [ProducesResponseType(typeof(SupplierContactDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateContactAsync(string cardCode, [FromBody] SupplierContactCreateModel contactCreate)
        {
            try
            {
                var ContactDetailsCreated = await _supplierContactService.CreateAsync(cardCode, contactCreate).ConfigureAwait(false);

                return Ok(ContactDetailsCreated);
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
        //~/{cardCode}/contact/{idLocation} update
        [HttpPut("{cardCode}/contact/{idContact}")]
        [ProducesResponseType(typeof(SupplierDetailsModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateContactAsync(string cardCode, int idContact, [FromBody] SupplierContactUpdateModel contactUpdate)
        {
            try
            {
                await _supplierContactService.UpdateAsync(cardCode, contactUpdate).ConfigureAwait(false);

                return Ok("Contacto actualizada");
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


    }
}
