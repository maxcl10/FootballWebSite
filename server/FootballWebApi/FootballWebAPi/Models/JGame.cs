using System;

namespace FootballWebSiteApi.Models
{
    public class JGame
    {
        public Guid Id { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public Guid SeasonId { get; set; }
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

        public bool Postponed { get; set; }

        public Guid OwnerTeam { get; set; }

        public string Result { get; set; }



    }
}
