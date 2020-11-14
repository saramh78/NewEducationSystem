using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository.ModelBuilders
{
    public static class CoursePartArticleModelBuilder
    {
        public static void CoursePartArticleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoursePartArticle>().HasData(
                new CoursePartArticle
                {
                    Id=1,
                    CoursePartId=1,
                    ArticleId=1,
                    Order=1,
                },
                new CoursePartArticle
                {
                    Id=2,
                    CoursePartId=2,
                    ArticleId=2,
                    Order=2
                },
                new CoursePartArticle
                {
                    Id = 3,
                    CoursePartId = 3,
                    ArticleId = 3,
                    Order = 3
                }
                );
        }
    }
}
