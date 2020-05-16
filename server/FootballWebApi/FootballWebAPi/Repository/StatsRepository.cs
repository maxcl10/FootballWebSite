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

        public List<JStricker> GetStrikers()
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var stats = _entities.PlayerTeams.Where(o => o.seasonId == currentSeasonId &&
                                                        o.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId &&
                                                        o.Player.position != "Entraineur");

            return Mapper.Map(stats);
        }

        public List<JStricker> GetStrikers2()
        {
            List<JStricker> stats = new List<JStricker>();
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var playerGames = _entities.PlayerGames.Include("GameEvents").Where(o => o.Game.SeasonId == currentSeasonId && o.Game.ownerId.ToString() == Properties.Settings.Default.OwnerId);
            foreach (var playerGame in playerGames)
            {
                var playerStat = stats.SingleOrDefault(o => o.PlayerId == playerGame.PlayerId);
                if (playerStat == null)
                {
                    playerStat = new JStricker
                    {
                        PlayerId = playerGame.PlayerId,
                        PlayerFirstName = playerGame.Player.firstName,
                        PlayerLastName = playerGame.Player.lastName,
                        PlayerName = playerGame.Player.firstName + " " + playerGame.Player.lastName,
                        TotalGames = 1,
                        ChampionshipGoals = 0,
                        ChampionshipAssists = 0,
                        NationalCupGoals = 0,
                        NationalCupAssists = 0,
                        RegionalCupGoals = 0,
                        RegionalCupAssists = 0,
                        OtherCupGoals = 0,
                        OtherCupAssists = 0
                    };
                    stats.Add(playerStat);
                }
                else
                {
                    playerStat.TotalGames++;
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
                            playerStat.ChampionshipGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.ChampionshipAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 1)
                        {
                            playerStat.NationalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.NationalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 2)
                        {
                            playerStat.RegionalCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.RegionalCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                        else if (playerGame.Game.Competition.competitionType == 3)
                        {
                            playerStat.OtherCupGoals += eventItem.EventTypeId == 0 ? 1 : 0;
                            playerStat.OtherCupAssists += eventItem.EventTypeId == 1 ? 1 : 0;
                        }
                    }
                }

                playerStat.TotalGoals = playerStat.ChampionshipGoals + playerStat.NationalCupGoals + playerStat.RegionalCupGoals + playerStat.OtherCupGoals;
                playerStat.TotalAssists = playerStat.ChampionshipAssists + playerStat.NationalCupAssists + playerStat.RegionalCupAssists + playerStat.OtherCupAssists;
            }

            return stats;
        }


        public JStricker GetPlayerStats(Guid playerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var stats = _entities.PlayerTeams.Single(o => o.seasonId == currentSeasonId &&
                                                        o.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId &&
                                                        o.Player.id == playerId);

            return Mapper.Map(stats);
        }

        public JStricker SetStricker(JStricker jstricker)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var correspondingData = _entities.PlayerTeams.Single(o => o.Team.ownerId.HasValue
                                                                     && o.Team.ownerId.Value.ToString() == Properties.Settings.Default.OwnerId
                                                                     && o.seasonId == currentSeasonId
                                                                     && o.playerId == jstricker.PlayerId);

            correspondingData.championshipGoals = jstricker.ChampionshipGoals;
            correspondingData.nationalCupGoals = jstricker.NationalCupGoals;
            correspondingData.regionalCupGoals = jstricker.RegionalCupGoals;
            correspondingData.otherCupGoals = jstricker.OtherCupGoals;
            correspondingData.championshipAssists = jstricker.ChampionshipAssists;

            _entities.SaveChanges();
            return jstricker;
        }

        public List<string> GetShape()
        {
            List<string> shapes = new List<string>();
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;
            var games = _entities.Games.Where(o => o.HomeTeamScore != null
            && o.AwayTeamScore != null
            && o.ownerId.ToString() == Properties.Settings.Default.OwnerId
            && o.SeasonId == currentSeasonId).OrderBy(o => o.MatchDate).ToList();

            //Get team Id
            var localTeamId = _entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;


            foreach (var game in games)
            {
                shapes.Add(BusinessLogic.GetResultChar(game, localTeamId));
            }

            return shapes;
        }

        public double ScoredGoalPerGame()
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            //Get team Id
            var firstTeamId = _entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;

            var myTeamGames = _entities.Games.Where(o => o.Owner.ownerId.ToString() == Properties.Settings.Default.OwnerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.id == firstTeamId).Sum(o => o.HomeTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.id == firstTeamId).Sum(o => o.AwayTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);
        }

        public double ConcededGoalPerGame()
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            //Get team Id
            var firstTeamId = _entities.Teams.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.displayOrder).First().id;

            var myTeamGames = _entities.Games.Where(o => o.Owner.ownerId.ToString() == Properties.Settings.Default.OwnerId && o.SeasonId == currentSeasonId);

            var homeScore = myTeamGames.Where(o => o.Team.id == firstTeamId).Sum(o => o.AwayTeamScore);

            var awayScore = myTeamGames.Where(o => o.Team1.id == firstTeamId).Sum(o => o.HomeTeamScore);

            return (homeScore.Value + awayScore.Value) / (double)myTeamGames.Count(o => o.HomeTeamScore != null);

        }

        public object GetRankingHistory()
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason);
            return _entities.LazyRankings.Where(o => o.team == "Uffheim F.C." && o.uploadDate > currentSeasonId.startDate).OrderBy(o => o.uploadDate).Select(o => new
            {
                o.position,
                o.uploadDate
            }).ToList();
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
