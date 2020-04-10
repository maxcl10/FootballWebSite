using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Repository
{
    public class SeasonRepository : IDatabaseRepository<Season>, IDisposable
    {
        private FootballWebSiteDbEntities entities;

        public SeasonRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Season> Get()
        {
            return entities.Seasons;
        }

        public Season Get(string id)
        {
            throw new NotImplementedException();
        }

        public Season Post(Season value)
        {
            throw new NotImplementedException();
        }

        public Season Put(string id, Season value)
        {
            throw new NotImplementedException();
        }
    }
}
