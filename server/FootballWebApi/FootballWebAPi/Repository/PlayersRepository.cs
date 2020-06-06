using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interfaces;
using FootballWebSiteApi.Models;
using JPlayer = FootballWebSiteApi.Models.JPlayer;

namespace FootballWebSiteApi.Repository
{
    public class PlayersRepository : IPlayersRepository
    {
        private FootballWebSiteDbEntities _entities;

        public PlayersRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<JPlayer> GetPlayers(Guid ownerId, bool currentSeason = false)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.CurrentSeason).SeasonId;
            if (currentSeason)
            {
                return Mapper.Map(_entities.Players.Where(o => o.PlayerTeams.Any(s => s.SeasonId == currentSeasonId && s.Team.OwnerId == ownerId))
                    .ToList().OrderBy(p => BusinessLogic.GetPositionOrder(p.Position)).ThenBy(o => o.LastName));
            }
            else
            {
                return Mapper.Map(_entities.Players.ToList().OrderBy(p => BusinessLogic.GetPositionOrder(p.Position)));
            }
        }





        public JPlayer GetPlayer(Guid id)
        {
            return Mapper.Map(_entities.Players.Single(o => o.PlayerId == id));
        }

        public IEnumerable<JGamePlayer> GetGamePlayers(Guid gameId)
        {
            List<JGamePlayer> players = new List<JGamePlayer>();
            var game = _entities.Games.SingleOrDefault(o => o.GameId == gameId);

            foreach (var playerGame in game.PlayerGames)
            {
                players.Add(Mapper.Map(playerGame));
            }

            return players.OrderBy(o => BusinessLogic.GetPositionOrder(o.GlobalPosition)).ThenBy(o => o.PlayerLastName);
        }


        public Player CreatePlayer(Player player)
        {
            player.PlayerId = Guid.NewGuid();
            _entities.Players.Add(player);
            _entities.SaveChanges();
            return player;
        }

        public JGamePlayer AddGamePlayer(Guid id, JGamePlayer player)
        {
            //todo: Make sure it does not already exists

            //Save
            player.Id = Guid.NewGuid();

            if (_entities.PlayerGames.SingleOrDefault(o => o.GameId == id && o.PlayerId == player.Id) != null)
            {
                throw new Exception("User already in the game");
            }

            _entities.PlayerGames.Add(new PlayerGame
            {
                GameId = id,
                PlayerId = player.PlayerId,
                Position = player.Position,
                PlayerGameId = player.Id
            });

            _entities.SaveChanges();

            //get the data
            var playerDB = _entities.Players.Single(o => o.PlayerId == player.PlayerId);
            player.PlayerFirstName = playerDB.FirstName;
            player.PlayerLastName = playerDB.LastName;

            return player;
        }

        public Player UpdatePlayer(Guid id, Player player)
        {
            var correspondingPlayer = _entities.Players.Single(o => o.PlayerId == id);

            correspondingPlayer.FirstName = player.FirstName;
            correspondingPlayer.LastName = player.LastName;
            correspondingPlayer.DateOfBirth = player.DateOfBirth;
            correspondingPlayer.Height = player.Height;
            correspondingPlayer.Weight = player.Weight;
            correspondingPlayer.Nationality = player.Nationality;
            correspondingPlayer.Position = player.Position;
            correspondingPlayer.PreviousClubs = player.PreviousClubs;
            correspondingPlayer.FavoriteNumber = player.FavoriteNumber;
            correspondingPlayer.Nickname = player.Nickname;
            correspondingPlayer.FavoritePlayer = player.FavoritePlayer;
            correspondingPlayer.FavoriteTeam = player.FavoriteTeam;

            _entities.SaveChanges();
            return player;
        }

        public void UpdateGamePlayer(Guid gameId, Guid id, JGamePlayer player)
        {
            var corresponding = _entities.PlayerGames.Single(o => o.GameId == gameId && o.PlayerId == id);
            corresponding.Position = player.Position;

            _entities.SaveChanges();

        }

        public void DeletePlayer(Guid id)
        {
            var playerToDelete = _entities.Players.Single(o => o.PlayerId == id);
            _entities.Players.Remove(playerToDelete);
            _entities.SaveChanges();
        }

        public void DeleteGamePlayer(Guid id, Guid playerId)
        {
            var playerToDelete = _entities.PlayerGames.First(o => o.GameId == id && o.PlayerId == playerId);
            _entities.PlayerGames.Remove(playerToDelete);
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

        ~PlayersRepository()
        {
            Dispose(false);
        }

        #endregion

    }
}
