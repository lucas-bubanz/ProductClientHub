using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clients.Delete
{
    public class DeleteClientUseCase
    {
        public void Execute(Guid Id)
        {
            var context = new ProductClientHubDbContext();

            var entity = context.Clients.FirstOrDefault(client => client.Id == Id) ?? throw new NotFoundException("Cliente não encontrado!");

            context.Clients.Remove(entity);
            context.SaveChanges();
        }
    }
}
