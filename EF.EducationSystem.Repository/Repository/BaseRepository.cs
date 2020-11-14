using EF.EducationSystem.Repository;
using Domain.Models.Entities;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF.EducationSystem.Repository.Repository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected readonly EducationSystemContext _context;
        public EducationSystemContext Context { get => _context; }

        public BaseRepository(EducationSystemContext EducationSystemContext)
        {
            _context = EducationSystemContext;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
