using System;
using FootballWebSiteApi.Entities;

namespace FootballWebSiteApi.Interfaces
{
    public interface IAuthenticationRepository : IDisposable
    {
        User IsAuthorized(string alias, string password);
    }
}
