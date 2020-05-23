using System;
using FootballWebSiteApi.Entities;

namespace FootballWebSiteApi.Interfaces
{
    public interface IAuthenticationRepository : IDisposable
    {
        User IsAuthorized(Guid ownerId, string alias, string password);
    }
}
