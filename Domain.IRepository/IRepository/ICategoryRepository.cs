using Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.IRepository
{
    public interface ICategoryRepository:IBaseRepository<Category, int>
    {
        Task<List<Category>> FindWithChildrenAsync(int id, int level);
    }
}
