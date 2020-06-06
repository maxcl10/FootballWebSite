using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IGameEventsRepository : IDisposable
    {
        JGameEvent CreateEvent(JGameEvent gameEvent);
        void DeleteEvent(Guid eventId);
        List<JGameEvent> GetEventsByGame(Guid gameId);

        IEnumerable<JEventType> GetGameEventTypes();
    }
}
