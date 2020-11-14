using Domain.Models.Entities;
using Domain.Repository.IRepository;

namespace EF.EducationSystem.Repository.Repository
{
    public class CoursePartArticleRepository : BaseRepository<CoursePartArticle, int>, ICoursePartArticleRepository
    {
        public CoursePartArticleRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {

        }
    }
}
