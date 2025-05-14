using System.Net;

namespace ProductClienteHub.Execptions.ExceptionsBase
{
    public class NotFoundException : ProductClientHubExceptions
    {
        public NotFoundException(string errorMessage) : base(errorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}