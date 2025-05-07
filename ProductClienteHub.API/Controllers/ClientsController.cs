using Microsoft.AspNetCore.Mvc;
using ProductClienteHub.API.Interfaces;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;

namespace ProductClienteHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status201Created)]
        public IActionResult RegisterClientAsync([FromBody] RequestClientJson request)
        {
             return Created();
        }

        [HttpPut]
        public IActionResult UpdatClientAsync()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllClientsAsync()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetClientByIdAsync([FromRoute] Guid Id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult DeleteClientAsync([FromRoute] Guid Id)
        {
            return Ok();
        }
    }
}
