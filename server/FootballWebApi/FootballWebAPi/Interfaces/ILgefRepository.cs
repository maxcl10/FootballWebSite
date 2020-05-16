using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface ILgefRepository
    {
        List<JGame> GetGames(string url, int clubId);
    }
}
