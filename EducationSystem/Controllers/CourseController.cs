using Domain.Service.Dtos;
using Domain.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<ActionResult<CourseDetailDto>> AddCourseWithRelations(CourseDetailDto courseDetailDto)
        {
            var service = await _courseService.AddCourseWithRelations(courseDetailDto);
            return service;
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAllAsync()
        {
            var service = await _courseService.GetAllAsync();
            return service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDetailDto>> GetAsync(int id)
        {
            var service = await _courseService.GetAsync(id);
            return service;
        }
    }
}
