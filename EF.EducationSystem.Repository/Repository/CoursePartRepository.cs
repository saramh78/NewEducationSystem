using Domain.Models.Entities;
using Domain.Repository.IRepository;

namespace EF.EducationSystem.Repository.Repository
{
    public class CoursePartRepository : BaseRepository<CoursePart, int>, ICoursePartRepository
    {
        public CoursePartRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {

        }
    }
}