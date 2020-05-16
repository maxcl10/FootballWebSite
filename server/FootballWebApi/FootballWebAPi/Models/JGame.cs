using System;

namespace FootballWebSiteApi.Models
{
    public class JGame
    {
        public System.Guid Id { get; set; }
        public System.Guid HomeTeamId { get; set; }
        public System.Guid AwayTeamId { get; set; }
        public System.DateTime MatchDate { get; set; }
        public System.Guid SeasonId { get; set; }
        public string Championship { get; set; }
        public string Competition { get; set; }

        public string CompetitionShort { get; set; }

        public Guid? CompetitionId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }

        public int? HomeExtraTimeScore { get; set; }
        public int? AwayExtraTimeScore { get; set; }

        public int? HomePenaltyScore { get; set; }
        public int? AwayPenaltyScore { get; set; }

        public string Result { get; set; }


    }
}
