using System;

namespace FootballWebSiteApi.Models
{
    public class JStricker
    {


        public string playerName { get; set; }
        public Guid playerId { get; set; }
        public int? championshipGoals { get; set; }

        public int? championshipAssists { get; set; }

        public int? nationalCupGoals { get; set; }
        public int? nationalCupAssists { get; set; }
        public int? regionalCupGoals { get; set; }
        public int? regionalCupAssists { get; set; }
        public int? otherCupGoals { get; set; }
        public int? otherCupAssists { get; set; }
        public int? totalGoals { get; set; }
        public int? totalAssists { get; set; }

        public int? totalGames { get; set; }

        public int? championshipGames { get; set; }
        public string playerFirstName { get; set; }

        public string playerLastName { get; internal set; }
    }
}
