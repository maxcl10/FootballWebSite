using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IPlayersRepository : IDisposable
    {
        JGamePlayer AddGamePlayer(Guid teamId, JGamePlayer player);
        Player CreatePlayer(Player player);
        void DeletePlayer(Guid id);
        IEnumerable<JGamePlayer> GetGamePlayers(Guid gameId);
        JPlayer GetPlayer(Guid id);
        IEnumerable<JPlayer> GetPlayers(Guid ownerId, bool current = false);
        void UpdateGamePlayer(Guid gameId, Guid id, JGamePlayer player);
        Player UpdatePlayer(Guid id, Player player);
        void DeleteGamePlayer(Guid id, Guid playerId);
    }
}
