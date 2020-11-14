using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository.ModelBuilders
{
    public static class CoursePartModelBuilder
    {
        public static void CoursePartSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoursePart>().HasData(
                new CoursePart
                {
                    Id=1,
                    CourseId=1,
                    Title="Get Started",
                    Order=1
                },
                new CoursePart
                {
                    Id=2,
                    CourseId=1,
                    Title="Types",
                    Order=2
                },
                new CoursePart
                {
                    Id=3,
                    CourseId=1,
                    Title="Classes"
                }
                );
        }
    }
}
