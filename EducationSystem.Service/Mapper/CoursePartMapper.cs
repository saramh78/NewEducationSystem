using Domain.Models.Entities;
using Domain.Service.Dtos;

namespace EducationSystem.Service.Mapper
{
    public static class CoursePartMapper
    {
        public static CoursePartDto CoursePartToCoursePartDto(this CoursePart coursePart)
        {
            return new CoursePartDto()
            {
                Order = coursePart.Order,
                Title = coursePart.Title,
                Articles = coursePart.CoursePartArticles.GetArticle()
            };
        }
    }
}