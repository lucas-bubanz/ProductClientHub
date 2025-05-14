using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.Communication.Responses;

namespace ProductClienteHub.API.UseCases.Clients.GetAll
{
    public class GetAllClientUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var context = new ProductClientHubDbContext();
            var clients = context.Clients.ToList();

            return new ResponseAllClientsJson
            {
                Clients = [.. clients.Select(client => new ResponseShortClientJson
                {
                    Id = client.Id,
                    Name = client.Name
                })]
            };
        }
    }
}