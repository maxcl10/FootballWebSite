using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Repository
{
    public class OwnerRepository: IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public OwnerRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public JOwner Get()
        {
            var owner = Mapper.Map(entities.Owners.Single(o => o.ownerId.ToString() == Properties.Settings.Default.OwnerId));
            return owner;
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}