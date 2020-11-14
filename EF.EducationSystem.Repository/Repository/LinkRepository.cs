using Domain.Models.Entities;
using Domain.Repository.IRepository;

namespace EF.EducationSystem.Repository.Repository
{
    public class LinkRepository : BaseRepository<Link, int>, ILinkRepository
    {
        public LinkRepository(EducationSystemContext EducationSystemContext) : base(EducationSystemContext)
        {

        }
    }
}