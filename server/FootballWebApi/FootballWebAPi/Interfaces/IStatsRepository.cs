using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IStatsRepository : IDisposable
    {
        double ConcededGoalPerGame(Guid ownerId);
        JPlayerStats GetPlayerStats(Guid ownerId, Guid playerId);

        List<string> GetShape(Guid ownerId);
        List<JPlayerStats> GetStrikers(Guid ownerId);
        List<JPlayerStats> GetPlayersStats(Guid ownerId);
        double ScoredGoalPerGame(Guid ownerId);
        JPlayerStats SetStricker(Guid ownerId, JPlayerStats jstricker);
    }
}
