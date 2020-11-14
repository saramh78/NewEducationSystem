using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository.ModelBuilders
{
    public static class CategoryModelBuilder
    {
        public static void CategorySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category 
                { 
                    Id = 1, 
                    Name = "Computer" 
                },
                     new Category 
                     { 
                         Id = 2, 
                         ParentId = 1, 
                         Name = "Programming" 
                     },
                         new Category 
                         { 
                             Id = 5, 
                             ParentId = 2, 
                             Name = "Concepts" 
                         },
                         new Category 
                         { 
                             Id = 6, 
                             ParentId = 2,
                             Name = "Web" 
                         },
                             new Category
                             {
                                 Id=8,
                                 ParentId=6,
                                 Name="Bootstrap"
                             },
                             new Category
                             {
                                 Id = 9,
                                 ParentId = 6,
                                 Name = "Css"
                             },
                             new Category
                             {
                                 Id = 10,
                                 ParentId = 6,
                                 Name = "Html"
                             },
                         new Category 
                         { 
                             Id = 7, 
                             ParentId = 2, 
                             Name = "Application" 
                         },
                             new Category
                             {
                                 Id = 11,
                                 ParentId = 7,
                                 Name = "C"
                             },
                                 new Category
                                 {
                                     Id = 13,
                                     ParentId = 11,
                                     Name = "C#"
                                 },
                                 new Category
                                 {
                                     Id = 14,
                                     ParentId = 11,
                                     Name = "C++"
                                 },
                             new Category
                             {
                                 Id = 12,
                                 ParentId = 7,
                                 Name = "VB"
                             },
                     new Category 
                     { 
                         Id=3,
                         ParentId = 1, 
                         Name = "DataBase" 
                     },
                         new Category
                         {
                             Id = 15,
                             ParentId =3,
                             Name = "SQL Server"
                         },
                         new Category
                         {
                             Id = 16,
                             ParentId = 3,
                             Name = "Oracle"
                         },
                     new Category 
                     {
                         Id=4,
                         ParentId = 1, 
                         Name = "Network" 
                     }
                );
        }
    }
}
