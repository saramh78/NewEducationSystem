using System.Collections.Generic;

namespace Domain.Models.Entities
{
    public class CoursePart : BaseEntity<int>
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public Course Course { get; set; }
        public ICollection<CoursePartArticle> CoursePartArticles { get; set; }
    }
}
