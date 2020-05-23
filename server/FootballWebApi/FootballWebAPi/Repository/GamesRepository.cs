using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private FootballWebSiteDbEntities _entities;

        public GamesRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        /// <returns></returns>
        public IEnumerable<JGame> GetGames(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;
            var games = Mapper.Map(_entities.Games.Where(o => o.SeasonId == currentSeasonId && o.ownerId == ownerId)
            .OrderBy(o => o.MatchDate).Include("Team").Include("Team1"));

            var localTeamId = _entities.Teams.Where(o => o.ownerId == ownerId)
            .OrderBy(o => o.displayOrder).First().id;

            foreach (var game in games)
            {
                game.Result = BusinessLogic.GetResultChar(game, localTeamId);
            }

            return games;
        }

        /// <summary>
        /// Gets the next game.
        /// </summary>
        /// <returns></returns>
        public JGame GetNextGame(Guid ownerId)
        {
            var nextGame = _entities.Games
                .Where(o => o.MatchDate > DateTime.Now && o.ownerId == ownerId)
                .OrderBy(o => o.MatchDate)
                .Include("Team").Include("Team1")
                .FirstOrDefault();
            if (nextGame == null)
            {
                return null;
            }

            var localTeamId = _entities.Teams.Where(o => o.ownerId == ownerId)
            .OrderBy(o => o.displayOrder).First().id;

            var game = Mapper.Map(nextGame);
            game.Result = BusinessLogic.GetResultChar(game, localTeamId);
            return game;
        }

        /// <summary>
        /// Gets the previous game.
        /// </summary>
        /// <returns></returns>
        public JGame GetPreviousGame(Guid ownerId)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;

            var previous = _entities.Games
                .Where(o => o.MatchDate < DateTime.Now && o.ownerId == ownerId && o.SeasonId == currentSeasonId)
                .OrderByDescending(o => o.MatchDate)
                .Include("Team")
                .Include("Team1")
                .FirstOrDefault();

            if (previous == null)
            {
                return null;

            }

            var localTeamId = _entities.Teams.Where(o => o.ownerId == ownerId)
            .OrderBy(o => o.displayOrder).First().id;

            var game = Mapper.Map(previous);
            game.Result = BusinessLogic.GetResultChar(game, localTeamId);
            return game;
        }

        /// <summary>
        /// Gets the specified game.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JGame GetGame(Guid ownerId, Guid id)
        {
            var localTeamId = _entities.Teams.Where(o => o.ownerId == ownerId)
            .OrderBy(o => o.displayOrder).First().id;

            JGame game = Mapper.Map(_entities.Games.Single(o => o.Id == id));
            game.Result = BusinessLogic.GetResultChar(game, localTeamId);
            game.OwnerTeam = localTeamId;

            return game;
        }



        /// <summary>
        /// Create a new game.
        /// </summary>
        /// <param name="jgame">The jgame.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public JGame CreateGame(Guid ownerId, JGame jgame)
        {
            var homeTeam = _entities.Teams.Find(jgame.HomeTeamId);
            var awayTeam = _entities.Teams.Find(jgame.AwayTeamId);
            var competition = _entities.Competitions.Find(jgame.CompetitionId);

            var game = new Game
            {
                Id = Guid.NewGuid(),
                MatchDate = jgame.MatchDate,
                Championship = jgame.Championship,
                SeasonId = _entities.Seasons.Single(o => o.currentSeason).id,
                CompetitionId = jgame.CompetitionId,
                Team = homeTeam,
                Team1 = awayTeam,
                ownerId = ownerId,
                Postponed = jgame.Postponed,
            };

            _entities.Games.Add(game);
            _entities.SaveChanges();

            return jgame;
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="jgame">The jgame.</param>
        /// <returns></returns>
        public JGame SaveGame(Guid ownerId, Guid id, JGame jgame)
        {
            var correspondingGame = _entities.Games.Single(o => o.Id == id && o.ownerId == ownerId);

            correspondingGame.Team = _entities.Teams.Find(jgame.HomeTeamId);
            correspondingGame.Team1 = _entities.Teams.Find(jgame.AwayTeamId);
            correspondingGame.Championship = jgame.Championship;
            correspondingGame.MatchDate = jgame.MatchDate;
            correspondingGame.HomeTeamScore = jgame.HomeTeamScore;
            correspondingGame.AwayTeamScore = jgame.AwayTeamScore;
            correspondingGame.Postponed = jgame.Postponed;

            correspondingGame.CompetitionId = jgame.CompetitionId;
            correspondingGame.ProlongHomeTeamScore = jgame.HomeExtraTimeScore;
            correspondingGame.ProlongAwayTeamScore = jgame.AwayExtraTimeScore;

            correspondingGame.PenaltyHomeTeamScore = jgame.HomePenaltyScore;
            correspondingGame.PenaltyAwayTeamScore = jgame.AwayPenaltyScore;

            _entities.SaveChanges();
            return jgame;
        }

        public void DeleteGame(Guid ownerId, Guid id)
        {
            var correspondingGame = _entities.Games.Single(o => o.Id == id && o.ownerId == ownerId);
            _entities.Games.Remove(correspondingGame);
            _entities.SaveChanges();
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



        ~GamesRepository()
        {
            Dispose(false);
        }

        #endregion


    }
}
