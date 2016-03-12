

namespace Sample.WebApi
{
    using System.Net.Http.Headers;
    using System.Web.Http;
    using System.Web.Http.ExceptionHandling;
    using Elmah.Contrib.WebApi;
    using Castle.Windsor;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

          //  RegisterControllerActivator(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.EnableCors();

            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;


        }

      
    }
}
