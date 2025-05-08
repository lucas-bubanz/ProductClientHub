using FluentValidation;
using ProductClienteHub.Communication.Requests;

namespace ProductClienteHub.API.UseCases.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome não pode ser vázio");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O e-mail não é válido");            
        }
    }
}