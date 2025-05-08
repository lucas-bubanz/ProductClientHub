namespace ProductClienteHub.Execptions.ExceptionsBase
{
    public class ErrorOnValidationException : ProductClientHubExceptions
    {
        private readonly List<string> _erros;
        public ErrorOnValidationException(List<string> errorListMessages) : base(string.Empty)
        {
            _erros = errorListMessages;
        }

        public override List<string> GetErrors() => _erros;
    }
}