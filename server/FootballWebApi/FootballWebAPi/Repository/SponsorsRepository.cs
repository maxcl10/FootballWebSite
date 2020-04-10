using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballWebSiteApi.Repository
{
    public class SponsorsRepository : IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public SponsorsRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JSponsor> Get()
        {
            var sponsors = Mapper.Map(entities.Sponsors.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId)
                .OrderBy(o => o.orderIndex));
            return sponsors;
        }

        public JSponsor Get(string id)
        {
            var sponsors = Mapper.Map(entities.Sponsors.Single(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId
            && o.sponsorId.ToString() == id));
            return sponsors;
        }

        public JSponsor Post(JSponsor jsponsor)
        {
            var index = entities.Sponsors.Where(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId).Max(o => o.orderIndex);
            var sponsor = new Sponsor
            {
                sponsorId = Guid.NewGuid(),
                logoUrl = jsponsor.logoUrl,
                name = jsponsor.name,
                orderIndex = index + 1,
                siteUrl = jsponsor.siteUrl,
                ownerId = new Guid(Properties.Settings.Default.OwnerId)
            };

            entities.Sponsors.Add(sponsor);
            entities.SaveChanges();
            return jsponsor;

        }

        public JSponsor Put(string id, JSponsor sponsor)
        {
            var corresponding = entities.Sponsors.Single(o => o.sponsorId.ToString() == id);
            corresponding.name = sponsor.name;
            corresponding.siteUrl = sponsor.siteUrl;
            corresponding.logoUrl = sponsor.logoUrl;

            entities.SaveChanges();
            return sponsor;
        }

        public void Delete(string id)
        {
            var toDelete = entities.Sponsors.Single(o => o.sponsorId.ToString() == id);
            entities.Sponsors.Remove(toDelete);
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}
