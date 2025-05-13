using Microsoft.AspNetCore.Mvc;
using ProductClienteHub.API.UseCases.Clients.GetAll;
using ProductClienteHub.API.UseCases.Clients.Register;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;

namespace ProductClienteHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult RegisterClientAsync([FromBody] RequestClientJson request)
        {
            var useCase = new RegisterClientUseCase();
            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        public IActionResult UpdatClientAsync()
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllClientsAsync()
        {
            var useCase = new GetAllClientUseCase();
            var response = useCase.Execute();

            if (response.Clients.Count == 0)
                return NoContent();
            
            return Ok(response);
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
