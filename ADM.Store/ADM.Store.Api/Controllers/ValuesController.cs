using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADM.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            List<string> Saludos =  new List<string>();
            for (int perro = 1; perro <= 10; perro++)
            {
                Saludos.Add($"Hola perro no.{perro}");
            }
            return Ok(Saludos);
        }
    } 
}
