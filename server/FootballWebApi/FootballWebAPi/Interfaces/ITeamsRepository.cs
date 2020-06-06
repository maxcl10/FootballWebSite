using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ITeamsRepository : IDisposable
    {
        void AddPlayer(Guid playerId, Guid teamId);
        void Delete(Guid id);
        JTeam GetTeam(Guid id);
        IEnumerable<JTeam> GetHomeTeams(Guid ownerId);
        IEnumerable<JPlayer> GetPlayers(Guid ownerId, Guid id);
        IEnumerable<JTeam> GetTeams();
        JTeam CreateTeam(JTeam jteam);
        JTeam UpdateTeam(Guid id, JTeam team);
        void RemovePlayer(Guid playerId, Guid teamId);
    }
}
