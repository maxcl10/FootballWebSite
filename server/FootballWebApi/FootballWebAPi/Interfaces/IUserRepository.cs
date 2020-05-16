using System;
using System.Collections.Generic;
using FootballWebSiteApi.Entities;

namespace FootballWebSiteApi.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
    }
}
