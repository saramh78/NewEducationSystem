using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository.ModelBuilders
{
    public static class ArticleModelBuilder
    {
        public static void ArticleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id=1,
                    Text= "C# syntax is highly expressive, yet it's also simple and easy to learn. The curly brace syntax of C# will be instantly recognizable to anyone familiar with C, C++, Java or JavaScript. Developers who know any of these languages are typically able to work productively in C# within a short time. C# provides powerful features such as nullable types, delegates, lambda expressions, pattern matching, and safe direct memory access. C# supports generic methods and types, which provide increased type safety and performance. C# provides iterators, which enable implementers of collection classes to define custom behaviors for client code. Language-Integrated Query (LINQ) expressions make the strongly typed query a first-class language construct."
                },
                new Article
                {
                    Id=2,
                    Text= "C# is a strongly typed language. Every variable and constant has a type, as does every expression that evaluates to a value. Every method signature specifies a type for each input parameter and for the return value. The .NET class library defines a set of built-in numeric types as well as more complex types that represent a wide variety of logical constructs, such as the file system, network connections, collections and arrays of objects, and dates. A typical C# program uses types from the class library as well as user-defined types that model the concepts that are specific to the program's problem domain."
                },
                new Article
                {
                    Id = 3,
                    Text = "A type that is defined as a class is a reference type. hen the object is created, enough memory is allocated on the managed heap for that specific object, and the variable holds only a reference to the location of said object. Types on the managed heap require overhead both when they are allocated and when they are reclaimed by the automatic memory management functionality of the CLR, which is known as garbage collection. However, garbage collection is also highly optimized and in most scenarios, it does not create a performance issue."
                }
                );
        }
    }
}
