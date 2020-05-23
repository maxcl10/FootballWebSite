using System;

namespace FootballWebSiteApi.Models
{

    public class JArticle
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Body { get; set; }

        public int? Type { get; set; }

        public string Publisher { get; set; }

        public bool Published { get; set; }

        public DateTime? PublishedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid UserId { get; set; }

        public Guid? GameId { get; set; }

        public string ImageUrl { get; set; }

    }

}
