using Domain.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service.IService
{
    public interface ICourseService
    {
        public Task<CourseDetailDto> AddCourseWithRelations(CourseDetailDto courseDetailDto);
        public Task<List<CourseDto>> GetAllAsync();
        public Task<CourseDetailDto> GetAsync(int courseId);
    }
}
