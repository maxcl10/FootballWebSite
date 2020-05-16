using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IPlayersRepository : IDisposable
    {
        JGamePlayer AddGamePlayer(Guid id, JGamePlayer player);
        Player CreatePlayer(Player player);
        void DeletePlayer(string id);
        IEnumerable<JGamePlayer> GetGamePlayers(Guid gameId);
        JPlayer GetPlayer(string id);
        IEnumerable<JPlayer> GetPlayers(bool current = false);
        void UpdateGamePlayer(Guid gameId, Guid id, JGamePlayer player);
        Player UpdatePlayer(string id, Player player);
        void DeleteGamePlayer(Guid id, Guid playerId);
    }
}
