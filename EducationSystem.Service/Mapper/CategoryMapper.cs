using Domain.Models.Entities;
using Domain.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationSystem.Service.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDto CategoryToCategoryDtoForGet(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                ParentId = category.ParentId,
                Name = category.Name,
            };
        }

        public static CategoryDetailDto CategoryToCategoryDetailDto(this Category category)
        {
            return new CategoryDetailDto()
            {
                Id = category.Id,
                ParentId = category.ParentId,
                Name = category.Name,
                CourseDtos = category.Courses != null ? category.Courses.Select(x => new CourseDto() {Id=x.Id, Name=x.Name }).ToList() : null,
            };
        }

        public static List<CategoryDto> CategoriesToCategoryDtos(this List<Category> categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
            var CategoryDtos = new List<CategoryDto>();
            for (int i = 0; i < categories.Count; i++)
            {
                CategoryDtos.Add(categories[i].CategoryToCategoryDtoForGet());
            }

            return CategoryDtos;
        }

        public static CategoryWithCategoryDto CategoryToCategoryWithCategoryDto(this Category category)
        {
            return new CategoryWithCategoryDto
            {
                Id = category.Id,
                ParentId = category.ParentId,
                Name = category.Name,
                Courses = category.Courses != null ? category.Courses.Select(x => new CourseDto() { Id = x.Id, Name = x.Name }).ToList() : null,
                Children = category.Children != null ? category.Children.Select(x => new CategoryWithCategoryDto { Id = x.Id, Name = x.Name,ParentId=x.ParentId }).ToList() : null,
            };
        }

        public static List<CategoryWithCategoryDto> CategoriesToCategoriesWithCategoryDto(this List<Category> categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }

            var CategoryDtos = new List<CategoryWithCategoryDto>();
            for (int i = 0; i < categories.Count; i++)
            {
                CategoryDtos.Add(categories[i].CategoryToCategoryWithCategoryDto());
            }

            return CategoryDtos;
        }
    }
}
