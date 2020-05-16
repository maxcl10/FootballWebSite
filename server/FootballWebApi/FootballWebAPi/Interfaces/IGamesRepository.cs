using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IGamesRepository : IDisposable
    {
        void DeleteGame(string id);
        IEnumerable<JGame> GetGames();
        JGame GetGame(string id);
        JGame GetNextGame();
        JGame GetPreviousGame();
        JGame CreateGame(JGame jgame);
        JGame SaveGame(string id, JGame jgame);
    }
}
