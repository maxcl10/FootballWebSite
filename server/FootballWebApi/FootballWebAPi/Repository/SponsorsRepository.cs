using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Interface;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class SponsorsRepository : ISponsorsRepository
    {
        private FootballWebSiteDbEntities _entities;

        public SponsorsRepository()
        {
            _entities = new FootballWebSiteDbEntities();
        }

        public IEnumerable<JSponsor> GetSponsors(Guid ownerId)
        {
            var sponsors = Mapper.Map(_entities.Sponsors.Where(o => o.ownerId == ownerId)
                .OrderBy(o => o.orderIndex));
            return sponsors;
        }

        public JSponsor GetSponsor(Guid ownerId, string id)
        {
            var sponsors = Mapper.Map(_entities.Sponsors.Single(o => o.ownerId == ownerId
            && o.sponsorId.ToString() == id));
            return sponsors;
        }

        public JSponsor CreateSponsor(Guid ownerId, JSponsor jsponsor)
        {
            var index = _entities.Sponsors.Where(o => o.ownerId == ownerId).Max(o => o.orderIndex);
            var sponsor = new Sponsor
            {
                sponsorId = Guid.NewGuid(),
                logoUrl = jsponsor.LogoUrl,
                name = jsponsor.Name,
                orderIndex = index + 1,
                siteUrl = jsponsor.SiteUrl,
                ownerId = ownerId
            };

            _entities.Sponsors.Add(sponsor);
            _entities.SaveChanges();
            return jsponsor;

        }

        public JSponsor UpdateSponsor(Guid ownerId, string id, JSponsor sponsor)
        {
            var corresponding = _entities.Sponsors.Single(o => o.sponsorId.ToString() == id && o.ownerId == ownerId);
            corresponding.name = sponsor.Name;
            corresponding.siteUrl = sponsor.SiteUrl;
            corresponding.logoUrl = sponsor.LogoUrl;

            _entities.SaveChanges();
            return sponsor;
        }

        public void DeleteSponsor(Guid ownerId, string id)
        {
            var toDelete = _entities.Sponsors.Single(o => o.sponsorId.ToString() == id && o.ownerId == ownerId);
            _entities.Sponsors.Remove(toDelete);
            _entities.SaveChanges();
        }


        #region Dispose 

        // Flag: Has Dispose already been called?
        bool disposed = false;

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _entities?.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~SponsorsRepository()
        {
            Dispose(false);
        }

        #endregion
    }
}
