using ProductClienteHub.API.Entities;
using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.API.UseCases.Products.SharedValidator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Products.Register
{
    public class RegisterProductUseCase
    {
        public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
        {
            var context = new ProductClientHubDbContext();

            Validate(context, clientId, request);

            var entity = new Product
            {
                Name = request.Name,
                Brand = request.Brand,
                Price = request.Price,
                ClientId = clientId
            };

            context.Products.Add(entity);
            context.SaveChanges();

            return new ResponseShortProductJson
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public void Validate(ProductClientHubDbContext context, Guid clientId, RequestProductJson request)
        {
            var clientExist = context.Clients.Any(client => client.Id == clientId);
            if (clientExist == false)
                throw new NotFoundException("Cliente não existe");

            var validator = new RequestProductValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
