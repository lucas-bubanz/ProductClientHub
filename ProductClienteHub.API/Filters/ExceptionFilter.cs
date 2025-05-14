using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ProductClientHubExceptions productClientHubExceptions)
            {
                context.HttpContext.Response.StatusCode = (int)productClientHubExceptions.GetHttpStatusCode();
                context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientHubExceptions.GetErrors()));
            }
            else
            {
                ThrowUnKnowError(context);
            }
        }

        private void ThrowUnKnowError(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO!"));
        }
    }
}