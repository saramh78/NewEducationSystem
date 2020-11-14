using Domain.Service.Dtos;
using Domain.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public CategoryController(ICategoryService categoryService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllAsync()
        {
            var service = await _categoryService.GetAllAsync();
            return service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDetailDto>> GetAsync(int id)
        {
            var service = await _categoryService.GetAsync(id);
            return service;
        }

        [HttpGet("GetWithChildren/{id}/{level}")]
        public async Task<ActionResult<List<CategoryWithCategoryDto>>> GetWithChildrenAsync(int id, int level)
        {
            var service = await _categoryService.GetWithChildrenAsync(id, level);
            return service;
        }
    }
}
