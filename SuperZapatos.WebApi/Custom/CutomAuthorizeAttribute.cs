using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using SuperZapatos.Models;

namespace SuperZapatos.WebApi.Custom
{
    public class CutomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var response = actionContext.Request.CreateResponse<ErrorResponse>
                               (new ErrorResponse(Models.Enums.ErrorType.NotAuthorized));
            response.StatusCode = System.Net.HttpStatusCode.Unauthorized;

            actionContext.Response = response;
        }
    }
}