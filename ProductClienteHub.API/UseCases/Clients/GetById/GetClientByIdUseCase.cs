using Microsoft.EntityFrameworkCore;
using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clients.GetById
{
    public class GetClientByIdUseCase
    {
        public ResponseClientJson Execute(Guid Id)
        {
            var context = new ProductClientHubDbContext();
            var entity = context
                        .Clients
                        .Include(client => client.Products)
                        .FirstOrDefault(client => client.Id == Id) ?? throw new NotFoundException("Cliente não encontrado");

            return new ResponseClientJson
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Products = [.. entity.Products.Select(product => new ResponseShortProductJson
                {
                    Id = product.Id,
                    Name = product.Name,
                })]
            };
        }
    }
}
