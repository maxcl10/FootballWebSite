using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ITeamsRepository : IDisposable
    {
        void AddPlayer(string playerId, string teamId);
        void Delete(string id);
        JTeam Get(string id);
        IEnumerable<JTeam> GetHomeTeams();
        IEnumerable<JPlayer> GetPlayers(Guid id);
        IEnumerable<JTeam> GetTeams();
        JTeam Post(JTeam jteam);
        JTeam Put(string id, JTeam team);
        void RemovePlayer(string playerId, string teamId);
    }
}
