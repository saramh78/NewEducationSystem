using System.Collections.Generic;

namespace Domain.Models.Entities
{
    public class Course : BaseEntity<int>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public ICollection<CoursePart> CourseParts { get; set; }
    }
}
