using Domain.Models.Entities;
using Domain.Service.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Service.Mapper.Mapper
{
    public static class CourseMapper
    {
        public static Course CourseDetailDtoToCourse(this CourseDetailDto courseDetailDto)
        {
            var course = new Course()
            {
                Name = courseDetailDto.Name,
                Description = courseDetailDto.Description,
                CategoryId = courseDetailDto.CategoryId,
                CourseParts = courseDetailDto.CourseParts.Select(cp => new CoursePart
                {
                     Title = cp.Title, 
                     Order = cp.Order,
                     CoursePartArticles = cp.Articles.GetArticleDto()
                }).ToList()
            };
            return course;
        }

        public static CourseDetailDto CourseToCourseDetailDto(this Course course)
        {
            var courseDto = new CourseDetailDto()
            {
                Name = course.Name,
                Description = course.Description,
                CategoryId = course.CategoryId,
                CourseParts = course.CourseParts.Select(x=> x.CoursePartToCoursePartDto()).ToList()
            };
            return courseDto;
        }

        public static List<CourseDto> CoursesToCourseDtos(this List<Course> courses)
        {
            var courseDtos = courses.Select(x => new CourseDto { Id = x.Id, CategoryId = x.CategoryId, Name = x.Name, Descrption = x.Description }).ToList();
            return courseDtos;
        }

    }
}
