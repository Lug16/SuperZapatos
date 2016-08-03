using SuperZapatos.Models;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SuperZapatos.WebApi.Security.Results
{
    public class CustomAuthenticationFailureResult : IHttpActionResult
    {
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Content = new ObjectContent<ErrorResponse>(new ErrorResponse(Models.Enums.ErrorType.NotAuthorized), new System.Net.Http.Formatting.JsonMediaTypeFormatter());
            return response;
        }
    }
}