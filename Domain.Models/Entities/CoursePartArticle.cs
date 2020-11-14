namespace Domain.Models.Entities
{
    public class CoursePartArticle : BaseEntity<int>
    {
        public int CoursePartId { get; set; }
        public int ArticleId { get; set; }
        public int Order { get; set; }
        public CoursePart CoursePart { get; set; }
        public Article Article { get; set; }
    }
}
