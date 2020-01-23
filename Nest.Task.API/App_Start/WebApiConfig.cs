using Nest.Task.API.Models;
using Nest.Task.Domain.Interfaces;
using Nest.Task.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;

namespace Nest.Task.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IAlbumService, AlbumService>();
            container.RegisterType<IUserService, UserService>();
            config.DependencyResolver = new DependencyResolver(container);
            // Web API routes
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
           // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
