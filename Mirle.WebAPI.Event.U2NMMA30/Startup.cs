using System;
using System.Net.Http.Headers;
using System.Web.Http;
using Owin;
using Unity;

namespace Mirle.WebAPI.Event 
{ 
    public class Startup
    {
        private readonly UnityContainer _container;

        public Startup(UnityContainer container)
        {
            _container = container;
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new UnityResolver(_container);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }
    }
}