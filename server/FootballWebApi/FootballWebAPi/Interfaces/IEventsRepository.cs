using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IEventsRepository : IDisposable
    {
        JEvent CreateEvent(JEvent gameEvent);
        void DeleteEvent(Guid eventId);
        List<JEvent> GetEventsByGame(Guid gameId);
    }
}
