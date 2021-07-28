using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private FootballWebSiteDbEntities _entities;

        public StatsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public List<JPlayerStats> GetStrikers(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var stats = _entities.PlayerTeams.Where(o => o.SeasonId == currentSeasonId &&
                                                        o.Team.OwnerId == ownerId &&
                                                        o.Player.Position != "Entraineur");

            return Mapper.Map(stats);
        }

        public List<JPlayerStats> GetPlayersStats(Guid ownerId)
        {
            List<JPlayerStats> stats = new List<JPlayerStats>();
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var playerGames = _entities.PlayerGames.Include("GameEvents").Where(o => o.Game.SeasonId == currentSeasonId && o.Game.ownerId == ownerId);
            foreach (var playerGame in playerGames)
            {
                var playerStat = stats.SingleOrDefault(o => o.PlayerId == playerGame.PlayerId);
                if (playerStat == null)
                {
                    playerStat = new JPlayerStats
                    {
                        PlayerId = playerGame.PlayerId,
                        PlayerFirstName = playerGame.Player.FirstName,
                        PlayerLastName = playerGame.Player.LastName,
                        PlayerName = playerGame.Player.FirstName + " " + playerGame.Player.LastName,
                        TotalGames = 1,
                        ChampionshipGoals = 0,
                        ChampionshipAssists = 0,
                        NationalCupGoals = 0,
                        NationalCupAssists = 0,
                        RegionalCupGoals = 0,
                        RegionalCupAssists = 0,
                        OtherCupGoals = 0,
                        OtherCupAssists = 0,
                        ChampionshipGames = 0,
                        NationalCupGames = 0,
                        RegionalCupGames = 0,
                        OtherCupGames = 0
                    };
                    stats.Add(playerStat);
                }
                else
                {
                    playerStat.TotalGames++;
                }

                if (playerGame.Game.Competition != null)
                {
                    if (playerGame.Game.Competition.CompetitionType == 0)
                    {
                        playerStat.ChampionshipGames++;
                    }
                    else if (playerGame.Game.Competition.CompetitionType == 1)
                    {
                        playerStat.NationalCupGames++;
                    }
                    else if (playerGame.Game.Competition.CompetitionType == 2)
                    {
                        playerStat.RegionalCupGames++;
                    }
                    else if (playerGame.Game.Competition.CompetitionType == 3)
                    {
                        playerStat.OtherCupGames++;
                    }
                }

                //var localTeam = entities.Teams.Where(o => o.ownerId == ownerId);       
                //entities.Competitions.Where(o=>o.
                //var competitionSeason= entities.CompetitionSeasons.Where(o=>o.seasonId == currentSeasonId && o.r == localTeam.)

                if (playerGame.GameEvents != null)
                {
                    foreach (var eventItem in playerGame.GameEvents)
                    {

                        if (playerGame.Game.Competition != null)
                        {
                            if (playerGame.Game.Competition.CompetitionType == 0)
                            {
                                playerStat.ChampionshipGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                                playerStat.ChampionshipAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                            }
                            else if (playerGame.Game.Competition.CompetitionType == 1)
                            {
                                playerStat.NationalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                                playerStat.NationalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                            }
                            else if (playerGame.Game.Competition.CompetitionType == 2)
                            {
                                playerStat.RegionalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                                playerStat.RegionalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                            }
                            else if (playerGame.Game.Competition.CompetitionType == 3)
                            {
                                playerStat.OtherCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                                playerStat.OtherCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                            }
                        }
                    }
                }

                playerStat.TotalGoals = playerStat.ChampionshipGoals + playerStat.NationalCupGoals + playerStat.RegionalCupGoals + playerStat.OtherCupGoals;
                playerStat.TotalAssists = playerStat.ChampionshipAssists + playerStat.NationalCupAssists + playerStat.RegionalCupAssists + playerStat.OtherCupAssists;
            }

            return stats;
        }


        public JPlayerStats GetPlayerStats(Guid ownerId, Guid playerId)
        {
            return GetPlayersStats(ownerId).SingleOrDefault(o => o.PlayerId == playerId);
        }

        public JPlayerStats SetStricker(Guid ownerId, JPlayerStats jstricker)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            var correspondingData = _entities.PlayerTeams.Single(o => o.Team.OwnerId.HasValue
                                                                     && o.Team.OwnerId.Value == ownerId
                                                                     && o.SeasonId == currentSeasonId
                                                                     && o.PlayerId == jstricker.PlayerId);

            correspondingData.ChampionshipGoals = jstricker.ChampionshipGoals;
            correspondingData.NationalCupGoals = jstricker.NationalCupGoals;
            correspondingData.RegionalCupGoals = jstricker.RegionalCupGoals;
            correspondingData.OtherCupGoals = jstricker.OtherCupGoals;
            correspondingData.ChampionshipAssists = jstricker.ChampionshipAssists;

            _entities.SaveChanges();
            return jstricker;
        }

        public List<string> GetShape(Guid ownerId)
        {
            List<string> shapes = new List<string>();
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;
            var games = _entities.Games.Where(o => o.HomeTeamScore != null
            && o.AwayTeamScore != null
            && o.ownerId == ownerId
            && o.SeasonId == currentSeasonId).OrderBy(o => o.MatchDate).ToList();

            //Get team Id
            var localTeamId = _entities.Teams.Where(o => o.OwnerId == ownerId)
                .OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0).TeamId;


            foreach (var game in games)
            {
                shapes.Add(BusinessLogic.GetResultChar(game, localTeamId));
            }

            return shapes;
        }

        public double ScoredGoalPerGame(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            //Get team Id
            var firstTeamId = _entities.Teams.Where(o => o.OwnerId == ownerId)
                .OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0).TeamId;

            var myTeamGames = _entities.Games.Where(o => o.Owner.OwnerId == ownerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.TeamId == firstTeamId).Sum(o => o.HomeTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.TeamId == firstTeamId).Sum(o => o.AwayTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);
        }

        public double ConcededGoalPerGame(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;

            //Get team Id
            var firstTeamId = _entities.Teams.Where(o => o.OwnerId == ownerId)
                .OrderBy(o => o.DisplayOrder).First(o => o.DisplayOrder > 0).TeamId;

            var myTeamGames = _entities.Games.Where(o => o.Owner.OwnerId == ownerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.TeamId == firstTeamId).Sum(o => o.AwayTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.TeamId == firstTeamId).Sum(o => o.HomeTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);

        }


        #region Dispose 

        // Flag: Has Dispose already been called?
        bool disposed = false;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _entities?.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~StatsRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
