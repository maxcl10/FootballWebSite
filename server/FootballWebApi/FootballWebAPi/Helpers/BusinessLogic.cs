using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Helpers
{
    public class BusinessLogic
    {
        public Season GetCurrentSeason(IEnumerable<Season> seasons)
        {
            return seasons.Single(o => o.startDate > DateTime.Today && o.endDate < DateTime.Today);
        }
    }
}