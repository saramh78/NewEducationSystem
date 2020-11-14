using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository.IRepository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        //EducationSystemContext Context { get; }

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

    }
}
