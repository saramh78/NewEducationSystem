using Domain.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Service.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDetailDto> GetAsync(int categoryId);
        Task<List<CategoryWithCategoryDto>> GetWithChildrenAsync(int categoryId, int level);
    }
}
