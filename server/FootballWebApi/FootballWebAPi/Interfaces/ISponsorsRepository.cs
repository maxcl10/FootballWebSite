using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interface
{
    public interface ISponsorsRepository : IDisposable
    {
        JSponsor CreateSponsor(Guid ownerId, JSponsor jsponsor);
        void DeleteSponsor(Guid ownerId, string id);

        JSponsor GetSponsor(Guid ownerId, string id);
        IEnumerable<JSponsor> GetSponsors(Guid ownerId);
        JSponsor UpdateSponsor(Guid ownerId, string id, JSponsor sponsor);
    }
}
