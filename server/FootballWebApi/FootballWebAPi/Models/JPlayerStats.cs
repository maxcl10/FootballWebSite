using System;

namespace FootballWebSiteApi.Models
{
    public class JPlayerStats
    {
        public string PlayerName { get; set; }

        public Guid PlayerId { get; set; }

        public int? ChampionshipGoals { get; set; }

        public int? ChampionshipAssists { get; set; }

        public int? NationalCupGoals { get; set; }

        public int? NationalCupAssists { get; set; }

        public int? RegionalCupGoals { get; set; }

        public int? RegionalCupAssists { get; set; }

        public int? OtherCupGoals { get; set; }

        public int? OtherCupAssists { get; set; }

        public int? TotalGoals { get; set; }

        public int? TotalAssists { get; set; }

        public int? TotalGames { get; set; }

        public int? ChampionshipGames { get; set; }

        public int? NationalCupGames { get; set; }

        public int? RegionalCupGames { get; set; }

        public int? OtherCupGames { get; set; }


        public string PlayerFirstName { get; set; }

        public string PlayerLastName { get; internal set; }
    }
}
