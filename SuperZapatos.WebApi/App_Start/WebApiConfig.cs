using SuperZapatos.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace SuperZapatos.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new IdentityBasicAuthenticationAttribute());
            config.Filters.Add(new Custom.CustomExceptionFilterAttribute());

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            //config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            //config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/xml");
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "ArticlesApi",
            //    routeTemplate: "services/{controller}/{location}/{id}",
            //    defaults:new { controller = "articles", location="store" }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "services/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //  name: "Api UriPathExtension",
            //  routeTemplate: "services/{controller}.{ext}/{id}",
            //  defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //  name: "Api UriPathExtension ID",
            //  routeTemplate: "services/{controller}/{id}.{ext}",
            //  defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            //); 
        }
    }
}
