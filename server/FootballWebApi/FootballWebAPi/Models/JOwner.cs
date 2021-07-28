using System;

namespace FootballWebSiteApi.Models
{
    public class JOwner
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Facebook { get; set; }

        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Stadium { get; set; }
        public string History { get; set; }
        public string GoogleMap { get; set; }
        public string FacebookLikeUrl { get; set; }
        public string LogoUrl { get; set; }

        public string Nickname { get; set; }


    }
}
