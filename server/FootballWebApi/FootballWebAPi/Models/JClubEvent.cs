using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    public class JClubEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Location { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool Canceled { get; set; }
    }
}
