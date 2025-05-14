using FluentValidation;
using ProductClienteHub.Communication.Requests;

namespace ProductClienteHub.API.UseCases.Products.SharedValidator
{
    public class RequestProductValidator : AbstractValidator<RequestProductJson>
    {
        public RequestProductValidator() 
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("O Nome do Produto não pode ser Vázio");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("A marca do Produto não pode ser Vázio");
            RuleFor(product => product.Price).GreaterThan(50).WithMessage("O valor do Produto deve ser maior que 50");
        }
    }
}
