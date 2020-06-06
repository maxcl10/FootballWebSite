using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interfaces
{
    public interface IClubEventsRepository : IDisposable
    {
        JClubEvent CreateClubEvent(Guid ownerId, JClubEvent jClubEvent);
        Task DeleteClubEvent(Guid ownerId, Guid clubEventId);
        Task<JClubEvent> GetClubEvent(Guid ownerId, Guid clubEventId);
        Task<IEnumerable<JClubEvent>> GetClubEvents(Guid ownerId);
        Task<JClubEvent> UpdateClubEvent(Guid ownerId, Guid clubEventId, JClubEvent jClubEvent);
    }
}
