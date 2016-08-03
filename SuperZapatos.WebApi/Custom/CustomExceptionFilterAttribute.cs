using SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace SuperZapatos.WebApi.Custom
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);

            if (actionExecutedContext.Exception is InvalidOperationException)
            {
                response.Content = new ObjectContent<ErrorResponse>(new ErrorResponse(Models.Enums.ErrorType.RecordNotFound), new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            }
            else if (actionExecutedContext.Exception is InvalidCastException)
            {
                response.Content = new ObjectContent<ErrorResponse>(new ErrorResponse(Models.Enums.ErrorType.BadRequest), new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            }
            else
            {
                response.Content = new ObjectContent<ErrorResponse>(new ErrorResponse(Models.Enums.ErrorType.ServerError), new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            }

            actionExecutedContext.Response = response;
        }
    }
}