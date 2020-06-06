using System;
using System.Web.Http;
using FootballWebSiteApi.Interface;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Repository;
using Unity;
using Unity.WebApi;

namespace FootballWebSiteApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IArticleRepository, ArticlesRepository>();
            container.RegisterType<IAuthenticationRepository, AuthenticationRepository>();
            container.RegisterType<ICompetitionsRepository, CompetitionsRepository>();
            container.RegisterType<IGameEventsRepository, GameEventsRepository>();
            container.RegisterType<IGamesRepository, GamesRepository>();
            container.RegisterType<ILazyRankingRepository, LazyRankingRepository>();
            container.RegisterType<ILgefRepository, LgefRepository>();
            container.RegisterType<IOwnerRepository, OwnerRepository>();
            container.RegisterType<IPlayersRepository, PlayersRepository>();
            container.RegisterType<ISeasonRepository, SeasonRepository>();
            container.RegisterType<ISponsorsRepository, SponsorsRepository>();
            container.RegisterType<IStatsRepository, StatsRepository>();
            container.RegisterType<ITeamsRepository, TeamsRepository>();
            container.RegisterType<IUserRepository, UsersRepository>();
            container.RegisterType<IClubEventsRepository, ClubEventsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
