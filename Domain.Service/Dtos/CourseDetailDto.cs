using System.Collections.Generic;

namespace Domain.Service.Dtos
{
    public class CourseDetailDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CoursePartDto> CourseParts { get; set; }
    }
}
