using System;

namespace FootballWebSiteApi.Helpers
{
    public class JCompetitionSeason
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Season { get; set; }
        public string ShortName { get; set; }
        public Guid CompetitionId { get; set; }
    }
}