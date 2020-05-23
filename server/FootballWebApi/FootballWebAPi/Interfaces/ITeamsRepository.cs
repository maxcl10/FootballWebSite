using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ITeamsRepository : IDisposable
    {
        void AddPlayer(Guid playerId, Guid teamId);
        void Delete(Guid id);
        JTeam Get(Guid id);
        IEnumerable<JTeam> GetHomeTeams(Guid ownerId);
        IEnumerable<JPlayer> GetPlayers(Guid ownerId, Guid id);
        IEnumerable<JTeam> GetTeams();
        JTeam Post(JTeam jteam);
        JTeam Put(Guid id, JTeam team);
        void RemovePlayer(Guid playerId, Guid teamId);
    }
}
