using Microsoft.AspNetCore.Mvc;
using ProductClienteHub.API.UseCases.Products.Register;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;

namespace ProductClienteHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        [Route("{clientId}")]
        [ProducesResponseType(typeof(ResponseShortProductJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult RegisterClientAsync([FromRoute]Guid clientId, [FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();
            var response = useCase.Execute(clientId, request);

            return Created(string.Empty, response);
        }
    }
}
