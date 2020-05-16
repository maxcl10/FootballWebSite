using System;

namespace FootballWebSiteApi.Models
{
    public class JCompetition
    {
        public System.Guid CompetitionId { get; set; }
        public string Name { get; set; }
        public Nullable<int> CompetitionType { get; set; }
        public string ShortName { get; set; }
    }
}