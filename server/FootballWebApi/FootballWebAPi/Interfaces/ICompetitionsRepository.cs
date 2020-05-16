using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ICompetitionsRepository : IDisposable
    {
        IEnumerable<JCompetition> GetCompetitions();
    }
}
