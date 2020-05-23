using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IGamesRepository : IDisposable
    {
        void DeleteGame(Guid ownerId, Guid id);

        JGame GetGame(Guid ownerId, Guid id);

        JGame GetPreviousGame(Guid ownerId);
        JGame CreateGame(Guid ownerId, JGame jgame);
        JGame SaveGame(Guid ownerId, Guid id, JGame jgame);

        IEnumerable<JGame> GetGames(Guid ownerId);
        JGame GetNextGame(Guid ownerId);
    }
}
