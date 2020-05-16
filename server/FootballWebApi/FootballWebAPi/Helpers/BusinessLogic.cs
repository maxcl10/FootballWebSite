using System;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Helpers
{
    public static class BusinessLogic
    {

        public static string GetResultChar(JGame game, Guid localTeamId)
        {
            if (game.HomeTeamScore.HasValue && game.AwayTeamScore.HasValue)
            {
                var homeGoals = game.HomeTeamScore.GetValueOrDefault() + game.HomeExtraTimeScore.GetValueOrDefault() + game.HomePenaltyScore.GetValueOrDefault();
                var awayGoals = game.AwayTeamScore.GetValueOrDefault() + game.AwayExtraTimeScore.GetValueOrDefault() + game.AwayPenaltyScore.GetValueOrDefault();

                if (homeGoals > awayGoals)
                {
                    return game.HomeTeamId == localTeamId ? "W" : "L";
                }
                else if (homeGoals < awayGoals)
                {
                    return game.HomeTeamId == localTeamId ? "L" : "W";
                }

                return "D";
            }

            return null;
        }

        public static string GetResultChar(Game game, Guid homeTeamId)
        {
            if (game.HomeTeamScore.HasValue && game.AwayTeamScore.HasValue)
            {
                var homeGoals = game.HomeTeamScore.GetValueOrDefault() + game.ProlongHomeTeamScore.GetValueOrDefault() + game.PenaltyHomeTeamScore.GetValueOrDefault();
                var awayGoals = game.AwayTeamScore.GetValueOrDefault() + game.ProlongAwayTeamScore.GetValueOrDefault() + game.PenaltyAwayTeamScore.GetValueOrDefault();

                if (homeGoals > awayGoals)
                {
                    return game.Team.id == homeTeamId ? "W" : "L";
                }
                else if (homeGoals < awayGoals)
                {
                    return game.Team.id == homeTeamId ? "L" : "W";
                }

                return "D";
            }

            return null;
        }

    }
}