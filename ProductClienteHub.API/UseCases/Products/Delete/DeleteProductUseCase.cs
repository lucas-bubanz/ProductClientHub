using ProductClienteHub.API.Infrastructure;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Products.Delete
{
    public class DeleteProductUseCase
    {
        public void Execute(Guid Id)
        {
            var context = new ProductClientHubDbContext();

            var entity = context.Products.FirstOrDefault(product => product.Id == Id) ?? throw new NotFoundException("Produto não encontrado!");

            context.Products.Remove(entity);
            context.SaveChanges();
        }
    }
}
