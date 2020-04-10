using System.Web.Http;

namespace FootballWebSiteApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Action",
                routeTemplate: "api/ns/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
            name: "Games",
            routeTemplate: "api/games/{gameid}/players/{id}",
            defaults: new { controller = "GamesPlayers", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
           name: "Events",
           routeTemplate: "api/games/{gameid}/events/{id}",
           defaults: new { controller = "Events", id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
       name: "GameArticles",
       routeTemplate: "api/games/{gameid}/articles/{id}",
       defaults: new { controller = "Articles", action = "GetGameArticle", id = RouteParameter.Optional }
       );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
              );

        }
    }
}
