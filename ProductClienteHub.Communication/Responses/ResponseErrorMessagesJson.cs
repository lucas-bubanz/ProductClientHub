namespace ProductClienteHub.Communication.Responses
{
    public class ResponseErrorMessagesJson
    {
        public List<string> Erros { get; private set; }

        public ResponseErrorMessagesJson(string message)
        {
            Erros = [message];
        }
    }
}