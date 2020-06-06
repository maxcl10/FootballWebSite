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
            var sponsors = Mapper.Map(_entities.Sponsors.Where(o => o.OwnerId == ownerId)
                .OrderBy(o => o.OrderIndex));
            return sponsors;
        }

        public JSponsor GetSponsor(Guid ownerId, string id)
        {
            var sponsors = Mapper.Map(_entities.Sponsors.Single(o => o.OwnerId == ownerId
            && o.SponsorId.ToString() == id));
            return sponsors;
        }

        public JSponsor CreateSponsor(Guid ownerId, JSponsor jsponsor)
        {
            var index = _entities.Sponsors.Where(o => o.OwnerId == ownerId).Max(o => o.OrderIndex);
            var sponsor = new Sponsor
            {
                SponsorId = Guid.NewGuid(),
                LogoUrl = jsponsor.LogoUrl,
                Name = jsponsor.Name,
                OrderIndex = index + 1,
                SiteUrl = jsponsor.SiteUrl,
                OwnerId = ownerId
            };

            _entities.Sponsors.Add(sponsor);
            _entities.SaveChanges();
            return jsponsor;

        }

        public JSponsor UpdateSponsor(Guid ownerId, string id, JSponsor sponsor)
        {
            var corresponding = _entities.Sponsors.Single(o => o.SponsorId.ToString() == id && o.OwnerId == ownerId);
            corresponding.Name = sponsor.Name;
            corresponding.SiteUrl = sponsor.SiteUrl;
            corresponding.LogoUrl = sponsor.LogoUrl;

            _entities.SaveChanges();
            return sponsor;
        }

        public void DeleteSponsor(Guid ownerId, string id)
        {
            var toDelete = _entities.Sponsors.Single(o => o.SponsorId.ToString() == id && o.OwnerId == ownerId);
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
