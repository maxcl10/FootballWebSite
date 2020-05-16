using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;

namespace FootballWebSiteApi.Interfaces
{
    public interface ISeasonRepository : IDisposable
    {
        IEnumerable<Season> GetSeasons();
    }
}
