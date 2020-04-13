using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWebSiteApi.Repository
{
    public class StatsRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public StatsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public List<JStricker> GetStrikers()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var stats = entities.PlayerTeams.Where(o => o.seasonId == currentSeasonId &&
                                                        o.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId &&
                                                        o.Player.position != "Entraineur");

            return Mapper.Map(stats);
        }

        public List<JStricker> GetStrikers2()
        {
            List<JStricker> stats = new List<JStricker>();
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var playerGames = entities.PlayerGames.Include("GameEvents").Where(o => o.Game.SeasonId == currentSeasonId && o.Game.ownerId.ToString() == Properties.Settings.Default.OwnerId);
            foreach (var playerGame in playerGames)
            {
                var playerStat = stats.SingleOrDefault(o => o.playerId == playerGame.PlayerId);
                if (playerStat == null)
                {
                    playerStat = new JStricker
                    {
                        playerId = playerGame.PlayerId,
                        playerFirstName = playerGame.Player.firstName,
                        playerLastName = playerGame.Player.lastName,
                        playerName = playerGame.Player.firstName + " " + playerGame.Player.lastName,
                        totalGames = 1,
                        championshipGoals = 0,
                        championshipAssists = 0,
                        nationalCupGoals = 0,
                        nationalCupAssists = 0,
                        regionalCupGoals = 0,
                        regionalCupAssists = 0,
                        otherCupGoals = 0,
                        otherCupAssists = 0
                    };
                    stats.Add(playerStat);
                }
                else
                {
                    playerStat.totalGames++;
                }
                //var localTeam = entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId);       
                //entities.Competitions.Where(o=>o.
                //var competitionSeason= entities.CompetitionSeasons.Where(o=>o.seasonId == currentSeasonId && o.r == localTeam.)

                if (playerGame.GameEvents != null)
                {
                    foreach (var eventItem in playerGame.GameEvents)
                    {
                        if (playerGame.Game.Competition.competitionType == 0)
                        {
                            playerStat.championshipGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.championshipAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 1)
                        {
                            playerStat.nationalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.nationalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 2)
                        {
                            playerStat.regionalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.regionalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 3)
                        {
                            playerStat.otherCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.otherCupAssists+= eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                    }
                }

                playerStat.totalGoals = playerStat.championshipGoals + playerStat.nationalCupGoals + playerStat.regionalCupGoals + playerStat.otherCupGoals;
                playerStat.totalAssists= playerStat.championshipAssists + playerStat.nationalCupAssists + playerStat.regionalCupAssists + playerStat.otherCupAssists;
            }

            return stats;
        }


        public JStricker GetPlayerStats(Guid playerId)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var stats = entities.PlayerTeams.Single(o => o.seasonId == currentSeasonId &&
                                                        o.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId &&
                                                        o.Player.id == playerId);

            return Mapper.Map(stats);
        }

        public JStricker SetStricker(JStricker jstricker)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            var correspondingData = entities.PlayerTeams.Single(o => o.Team.ownerId.HasValue
                                                                     && o.Team.ownerId.Value.ToString() == Properties.Settings.Default.OwnerId
                                                                     && o.seasonId == currentSeasonId
                                                                     && o.playerId == jstricker.playerId);

            correspondingData.championshipGoals = jstricker.championshipGoals;
            correspondingData.nationalCupGoals = jstricker.nationalCupGoals;
            correspondingData.regionalCupGoals = jstricker.regionalCupGoals;
            correspondingData.otherCupGoals = jstricker.otherCupGoals;
            correspondingData.championshipAssists = jstricker.championshipAssists;

            entities.SaveChanges();
            return jstricker;
        }

        public List<string> GetShape()
        {
            List<string> shapes = new List<string>();
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;
            var games = entities.Games.Where(o => o.HomeTeamScore != null
            && o.AwayTeamScore != null
            && o.ownerId.ToString() == Properties.Settings.Default.OwnerId
            && o.SeasonId == currentSeasonId).OrderBy(o => o.MatchDate).ToList();

            //Get team Id
            var localTeamId = entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;


            foreach (var game in games)
            {
                shapes.Add(BusinessLogic.GetResultChar(game, localTeamId));
            }

            return shapes;
        }

        public double ScoredGoalPerGame()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            //Get team Id
            var firstTeamId = entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;

            var myTeamGames = entities.Games.Where(o => o.Owner.ownerId.ToString() == Properties.Settings.Default.OwnerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.id == firstTeamId).Sum(o => o.HomeTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.id == firstTeamId).Sum(o => o.AwayTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);
        }

        public double ConcededGoalPerGame()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;

            //Get team Id
            var firstTeamId = entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;

            var myTeamGames = entities.Games.Where(o => o.Owner.ownerId.ToString() == Properties.Settings.Default.OwnerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.id == firstTeamId).Sum(o => o.AwayTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.id == firstTeamId).Sum(o => o.HomeTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);

        }

        public object GetRankingHistory()
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason);
            return entities.LazyRankings.Where(o => o.team == "Uffheim F.C." && o.uploadDate > currentSeasonId.startDate).OrderBy(o => o.uploadDate).Select(o => new
            {
                o.position,
                o.uploadDate
            }).ToList();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}
