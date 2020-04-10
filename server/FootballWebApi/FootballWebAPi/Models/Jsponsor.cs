using FootballWebSiteApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballWebSiteApi.Models
{
    public class JSponsor
    {
        public Guid sponsorId { get; set; }
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string siteUrl { get; set; }
        public int orderIndex { get; set; }
    }
}