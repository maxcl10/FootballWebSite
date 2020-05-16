using System;

namespace FootballWebSiteApi.Models
{
    public class JTeam
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string DisplayName { get; set; }

        public string CalendarUrl { get; set; }

        public string RankingUrl { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
