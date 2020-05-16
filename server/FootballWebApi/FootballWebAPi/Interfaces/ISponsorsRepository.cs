using System;
using System.Collections.Generic;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Interface
{
    public interface ISponsorsRepository : IDisposable
    {
        JSponsor CreateSponsor(JSponsor jsponsor);
        void DeleteSponsor(string id);
        void Dispose();
        JSponsor GetSponsor(string id);
        IEnumerable<JSponsor> GetSponsors();
        JSponsor UpdateSponsor(string id, JSponsor sponsor);
    }
}
