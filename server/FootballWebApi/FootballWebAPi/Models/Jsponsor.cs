using System;

namespace FootballWebSiteApi.Models
{
    public class JSponsor
    {
        public Guid SponsorId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string SiteUrl { get; set; }
        public int OrderIndex { get; set; }
    }
}
