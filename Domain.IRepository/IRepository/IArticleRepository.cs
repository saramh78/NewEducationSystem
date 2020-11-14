using Domain.Models.Entities;


namespace Domain.Repository.IRepository
{
    public interface IArticleRepository : IBaseRepository<Article, int>
    {
    }
}
