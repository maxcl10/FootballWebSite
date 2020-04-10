using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
	public class JCompetition
	{
        public System.Guid competitionId { get; set; }
        public string name { get; set; }
        public Nullable<int> competitionType { get; set; }
        public string shortName { get; set; }
    }
}