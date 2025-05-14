using Microsoft.AspNetCore.Mvc;
using ProductClienteHub.API.UseCases.Clients.Delete;
using ProductClienteHub.API.UseCases.Clients.GetAll;
using ProductClienteHub.API.UseCases.Clients.Register;
using ProductClienteHub.API.UseCases.Clients.Update;
using ProductClienteHub.API.UseCases.Products.Delete;
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
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult UpdatClientAsync([FromRoute]Guid id, [FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClientUseCase();
            useCase.Execute(id, request);
            return NoContent();
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult DeleteClientAsync([FromRoute] Guid Id)
        {
            var useCase = new DeleteClientUseCase();
            useCase.Execute(Id);
            return NoContent();
        }
    }
}
