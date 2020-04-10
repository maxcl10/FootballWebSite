using System;

namespace FootballWebSiteApi.Models
{

    public class JArticle
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string publisher { get; set; }
        public bool published { get; set; }
        public DateTime? publishedDate { get; set; }
        public DateTime? modifiedDate { get; set; }
        public DateTime? deletedDate { get; set; }
        public DateTime creationDate { get; set; }
        public Guid userId { get; set; }
        public Guid? gameId { get; set; }
    }

}
