using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;

namespace FootballWebSiteApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Set Camel case contract resolver
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            //Routes
            //     config.Routes.MapHttpRoute(
            //         name: "Action",
            //         routeTemplate: "api/ns/{controller}/{action}/{id}",
            //         defaults: new { id = RouteParameter.Optional }
            //         );

            //     config.Routes.MapHttpRoute(
            //     name: "Games",
            //     routeTemplate: "api/games/{gameid}/players/{id}",
            //     defaults: new { controller = "GamesPlayers", id = RouteParameter.Optional }
            //     );

            //     config.Routes.MapHttpRoute(
            //    name: "Events",
            //    routeTemplate: "api/games/{gameid}/events/{id}",
            //    defaults: new { controller = "Events", id = RouteParameter.Optional }
            //    );

            //     config.Routes.MapHttpRoute(
            //name: "GameArticles",
            //routeTemplate: "api/games/{gameid}/articles/{id}",
            //defaults: new { controller = "Articles", action = "GetGameArticle", id = RouteParameter.Optional }
            //);

            //     config.Routes.MapHttpRoute(
            //         name: "DefaultApi",
            //         routeTemplate: "api/{controller}/{id}",
            //         defaults: new { id = RouteParameter.Optional }
            //       );



        }


    }
}
