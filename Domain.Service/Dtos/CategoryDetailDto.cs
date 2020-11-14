using System.Collections.Generic;

namespace Domain.Service.Dtos
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public List<CourseDto> CourseDtos { get; set; }
    }
}
