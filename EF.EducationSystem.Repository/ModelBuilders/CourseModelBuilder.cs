using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository.ModelBuilders
{
    public static class CourseModelBuilder
    {
        public static void CourseSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course 
                { 
                    Id=1, 
                    CategoryId=2, 
                    Name="How to start"
                },
                new Course
                {
                    Id=2,
                    CategoryId=2,
                    Name= "essential information"
                },
                new Course
                {
                    Id=3,
                    CategoryId=2,
                    Name="Steps"
                },
                new Course
                {
                    Id=4,
                    CategoryId=5,
                    Name="Object Orianting"
                },
                new Course
                {
                    Id = 5,
                    CategoryId = 6,
                    Name = "Languages"
                },
                 new Course
                 {
                     Id = 6,
                     CategoryId = 7,
                     Name = "Languages"
                 },
                new Course
                {
                    Id = 7,
                    CategoryId = 11,
                    Name = "C Learning"
                },
                 new Course
                 {
                     Id =8,
                     CategoryId = 13,
                     Name = "C# Learning"
                 },
                  new Course
                  {
                      Id =9,
                      CategoryId = 14,
                      Name = "C++ Learning"
                  }
                );
        }
    }
}
