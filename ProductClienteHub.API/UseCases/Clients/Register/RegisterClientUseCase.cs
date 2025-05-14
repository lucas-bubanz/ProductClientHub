using ProductClienteHub.API.Entities;
using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.API.UseCases.Clients.SharedValidator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseShortClientJson Execute(RequestClientJson request)
        {                      
            Validate(request);

            var context = new ProductClientHubDbContext();
            var entity = new Client
            {            
                Name = request.Name,
                Email = request.Email                
            };

            context.Clients.Add(entity);
            context.SaveChanges();

            return new ResponseShortClientJson();
        }
        private void Validate(RequestClientJson request)
        {
            var validator = new RequestClientValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}