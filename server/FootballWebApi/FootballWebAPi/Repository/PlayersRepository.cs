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
        public IEnumerable<JPlayer> GetPlayers(bool current = false)
        {
            var currentSeasonId = _entities.Seasons.Single(o => o.currentSeason).id;
            if (current)
            {
                return Mapper.Map(_entities.Players.Where(o => o.PlayerTeams.Any(s => s.seasonId == currentSeasonId && s.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId))
                    .ToList().OrderBy(p => GetOrder(p.position)).ThenBy(o => o.lastName));
            }
            else
            {
                return Mapper.Map(_entities.Players.ToList().OrderBy(p => GetOrder(p.position)));
            }
        }


        private int GetOrder(string position)
        {
            switch (position)
            {
                case "Gardien":
                    return 0;
                case "Defenseur":
                    return 1;
                case "Milieu":
                    return 2;
                case "Attaquant":
                    return 3;
                default:
                    return 4;
            }
        }



        public JPlayer GetPlayer(string id)
        {
            return Mapper.Map(_entities.Players.Single(o => o.id.ToString() == id));
        }

        public IEnumerable<JGamePlayer> GetGamePlayers(Guid gameId)
        {
            List<JGamePlayer> players = new List<JGamePlayer>();
            var game = _entities.Games.SingleOrDefault(o => o.Id == gameId);

            foreach (var playerGame in game.PlayerGames)
            {
                players.Add(Mapper.Map(playerGame));
            }

            return players.OrderBy(o => GetOrder(o.GlobalPosition)).ThenBy(o => o.PlayerLastName);
        }


        public Player CreatePlayer(Player player)
        {
            player.id = Guid.NewGuid();
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
            var playerDB = _entities.Players.Single(o => o.id == player.PlayerId);
            player.PlayerFirstName = playerDB.firstName;
            player.PlayerLastName = playerDB.lastName;

            return player;
        }

        public Player UpdatePlayer(string id, Player player)
        {
            var correspondingPlayer = _entities.Players.Single(o => o.id.ToString() == id);

            correspondingPlayer.firstName = player.firstName;
            correspondingPlayer.lastName = player.lastName;
            correspondingPlayer.dateOfBirth = player.dateOfBirth;
            correspondingPlayer.height = player.height;
            correspondingPlayer.weight = player.weight;
            correspondingPlayer.nationality = player.nationality;
            correspondingPlayer.position = player.position;
            correspondingPlayer.previousClubs = player.previousClubs;
            correspondingPlayer.favoriteNumber = player.favoriteNumber;
            correspondingPlayer.nickname = player.nickname;
            correspondingPlayer.favoritePlayer = player.favoritePlayer;
            correspondingPlayer.favoriteTeam = player.favoriteTeam;

            _entities.SaveChanges();
            return player;
        }

        public void UpdateGamePlayer(Guid gameId, Guid id, JGamePlayer player)
        {
            var corresponding = _entities.PlayerGames.Single(o => o.GameId == gameId && o.PlayerId == id);
            corresponding.Position = player.Position;

            _entities.SaveChanges();

        }

        public void DeletePlayer(string id)
        {
            var playerToDelete = _entities.Players.Single(o => o.id.ToString() == id);
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
