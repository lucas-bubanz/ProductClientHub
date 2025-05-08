using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductClienteHub.Communication.Requests;
using ProductClienteHub.Communication.Responses;
using ProductClienteHub.Execptions.ExceptionsBase;

namespace ProductClienteHub.API.UseCases.Clients.Register
{
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            var validator = new RegisterClientValidator();
            var result = validator.Validate(request);

            if(result.IsValid == false)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }

            return new ResponseClientJson();
        }
    }
}