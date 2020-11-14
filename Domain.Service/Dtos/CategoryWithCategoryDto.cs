using System.Collections.Generic;

namespace Domain.Service.Dtos
{
    public class CategoryWithCategoryDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<CourseDto> Courses { get; set; }
        public List<CategoryWithCategoryDto> Children { get; set; }
    }
}
