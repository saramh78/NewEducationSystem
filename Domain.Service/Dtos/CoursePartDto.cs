using System.Collections.Generic;

namespace Domain.Service.Dtos
{
    public class CoursePartDto
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public List<ArticleInsertApiModel> Articles { get; set; }
    }
}

