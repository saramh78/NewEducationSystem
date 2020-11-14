using Domain.Models.Entities;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.EducationSystem.Repository.Repository
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {
        }

        public override async Task<Category> FindAsync(int id)
        {
            return await _context.Set<Category>()
                .Include(x => x.Courses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> FindWithChildrenAsync(int id, int level)
        {
            List<CategoryParsed> results = new List<CategoryParsed>();
            var find =await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if(find == null)
            {
                return null;
            }

            results.Add(new CategoryParsed { Categ=find, level=0, Parsed=false});

            while(results.Any(x=>!x.Parsed))
            {
                var r = results.FirstOrDefault(x => !x.Parsed);
                if(level !=-1 && r.level>=level)
                {
                    
                }
                else
                {
                    var child = _context.Categories.Where(x => x.ParentId == r.Categ.Id)
                        .Select(x => new CategoryParsed() { Categ = x, Parsed = false, level = r.level + 1 });
                    results.AddRange(child);
                }
                r.Parsed = true;
            }
            return results.Select(x => x.Categ).ToList();
        } 
    }
}

