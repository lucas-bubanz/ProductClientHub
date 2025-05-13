using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.API.UseCases.Clients.SharedValidator;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clients.Update
{
    public class UpdateClientUseCase
    {
        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validate(request);
            var context = new ProductClientHubDbContext();
            var entity = context.Clients.FirstOrDefault(client => client.Id == clientId) ?? throw new NotFoundException("Cliente não encontrado");

            entity.Name = request.Name;
            entity.Email = request.Email;

            context.Clients.Update(entity);
            context.SaveChanges();  
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
    };
}