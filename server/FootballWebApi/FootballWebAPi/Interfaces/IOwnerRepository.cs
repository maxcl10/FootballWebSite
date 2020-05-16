using System;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IOwnerRepository : IDisposable
    {
        JOwner GetCurrentOwner();
    }
}
