using System.Collections.Generic;

namespace Domain.Models.Entities
{
    public class Article:BaseEntity<int>
    {
        public string Text { get; set; }
        public ICollection<CoursePartArticle> CoursePartArticles { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
