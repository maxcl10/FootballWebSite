using System;

namespace FootballWebSiteApi.Models
{
    public class JUser
    {
        public Guid userId { get; set; }
        public string alias { get; set; }
        public string email { get; set; }
        public string lastName { get; internal set; }
        public string firstName { get; internal set; }
    }
}
