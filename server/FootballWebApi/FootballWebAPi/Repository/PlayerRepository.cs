using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using JPlayer = FootballWebSiteApi.Models.JPlayer;

namespace FootballWebSiteApi.Repository
{
    public class PlayerRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public PlayerRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<JPlayer> Get(bool current = false)
        {
            var currentSeasonId = entities.Seasons.Single(o => o.currentSeason).id;
            if (current)
            {
                return Mapper.Map(entities.Players.Where(o => o.PlayerTeams.Any(s => s.seasonId == currentSeasonId && s.Team.ownerId.ToString() == Properties.Settings.Default.OwnerId))
                    .ToList().OrderBy(p => GetOrder(p.position)).ThenBy(o=>o.lastName));
            }
            else
            {
                return Mapper.Map(entities.Players.ToList().OrderBy(p => GetOrder(p.position)));
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



        public JPlayer Get(string id)
        {
            return Mapper.Map(entities.Players.Single(o => o.id.ToString() == id));
        }

        public IEnumerable<JGamePlayer> GetGamePlayers(Guid gameId)
        {
            List<JGamePlayer> players = new List<JGamePlayer>();
            var game = entities.Games.SingleOrDefault(o => o.Id == gameId);

            foreach (var playerGame in game.PlayerGames)
            {
                players.Add(Mapper.Map(playerGame));
            }

            return players.OrderBy(o=>GetOrder(o.globalPosition)).ThenBy(o=>o.playerLastName);
        }


        public Player Post(Player player)
        {
            player.id = Guid.NewGuid();
            entities.Players.Add(player);
            entities.SaveChanges();
            return player;
        }

        public JGamePlayer AddGamePlayer(Guid id, JGamePlayer player)
        {
            //todo: Make sure it does not already exists

            //Save
            player.id = Guid.NewGuid();

            if (entities.PlayerGames.SingleOrDefault(o => o.GameId == id && o.PlayerId == player.id) != null)
            {
                throw new Exception("User already in the game");
            }

            entities.PlayerGames.Add(new PlayerGame
            {
                GameId = id,
                PlayerId = player.playerId,
                Position = player.position,
                PlayerGameId = player.id
            });

            entities.SaveChanges();

            //get the data
            var playerDB = entities.Players.Single(o => o.id == player.playerId);
            player.playerFirstName = playerDB.firstName;
            player.playerLastName = playerDB.lastName;

            return player;
        }

        public Entities.Player Put(string id, Entities.Player player)
        {
            var correspondingPlayer = entities.Players.Single(o => o.id.ToString() == id);

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

            entities.SaveChanges();
            return player;
        }

        internal void EditGamePlayer(Guid gameId, Guid id, JGamePlayer player)
        {
            var corresponding = entities.PlayerGames.Single(o => o.GameId == gameId && o.PlayerId == id);
            corresponding.Position = player.position;

            entities.SaveChanges();

        }

        public void Delete(string id)
        {
            var playerToDelete = entities.Players.Single(o => o.id.ToString() == id);
            entities.Players.Remove(playerToDelete);
            entities.SaveChanges();
        }

        internal void DeleteGamePlayer(Guid id, Guid playerId)
        {
            var playerToDelete = entities.PlayerGames.First(o => o.GameId == id && o.PlayerId == playerId);
            entities.PlayerGames.Remove(playerToDelete);
            entities.SaveChanges();
        }        

        public void Dispose()
        {
            entities.Dispose();
        }


    }
}
