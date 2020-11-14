using Domain.Models.Entities;
using Domain.Repository.IRepository;

namespace EF.EducationSystem.Repository.Repository
{
    public class ArticleRepository:BaseRepository<Article,int>,IArticleRepository
    {
        public ArticleRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {
        }
    }
}
