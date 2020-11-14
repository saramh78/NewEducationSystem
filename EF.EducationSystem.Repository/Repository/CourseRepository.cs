using Domain.Models.Entities;
using Domain.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EF.EducationSystem.Repository.Repository
{
    public class CourseRepository : BaseRepository<Course, int>, ICourseRepository
    {
        public CourseRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {          
        }

        public override async Task<Course> FindAsync(int id)
        {
            return await _context.Set<Course>()
                .Include(c => c.CourseParts)
                .ThenInclude(cp => cp.CoursePartArticles)
                .ThenInclude(cpa => cpa.Article)
                .ThenInclude(cpal=>cpal.Links)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
