using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IStatsRepository : IDisposable
    {
        double ConcededGoalPerGame();
        JStricker GetPlayerStats(Guid playerId);
        object GetRankingHistory();
        List<string> GetShape();
        List<JStricker> GetStrikers();
        List<JStricker> GetStrikers2();
        double ScoredGoalPerGame();
        JStricker SetStricker(JStricker jstricker);
    }
}
