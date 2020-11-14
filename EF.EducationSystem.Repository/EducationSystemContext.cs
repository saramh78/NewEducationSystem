using Domain.Models.Entities;
using Domain.Models.Entities.Identity;
using EF.EducationSystem.Repository.ModelBuilders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EF.EducationSystem.Repository
{
    public class EducationSystemContext : IdentityDbContext<ApplicationUser>
    {
        public EducationSystemContext(DbContextOptions options) : base(options)
        {
        }

        //public EducationSystemContext(DbContextOptions options) : base(options)
        //{


        //}

        //protected EducationSystemContext()
        //{
        //}

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CoursePart> CourseParts { get; set; }
        public virtual DbSet<CoursePartArticle> CoursePartArticles { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Name).HasMaxLength(32).IsRequired();
                d.HasOne(s => s.Parent).WithMany(s => s.Children).HasForeignKey(s => s.ParentId).OnDelete(DeleteBehavior.NoAction);
                d.HasMany(s => s.Courses).WithOne(s => s.Category).HasForeignKey(s => s.CategoryId);
            });

            modelBuilder.Entity<Course>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Name).HasMaxLength(32).IsRequired();
                d.Property(s => s.Description).HasMaxLength(256);
                d.HasMany(s => s.CourseParts).WithOne(s => s.Course).HasForeignKey(s => s.CourseId);
            });

            modelBuilder.Entity<CoursePart>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Title).HasMaxLength(32).IsRequired();
                d.Property(s => s.Order).IsRequired();
                d.HasMany(s => s.CoursePartArticles).WithOne(s => s.CoursePart).HasForeignKey(s => s.CoursePartId);
            });

            modelBuilder.Entity<CoursePartArticle>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Order).IsRequired();
            });

            modelBuilder.Entity<Article>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Text).HasMaxLength(1024).IsRequired();
                d.HasMany(s => s.CoursePartArticles).WithOne(s => s.Article).HasForeignKey(s => s.ArticleId);
            });

            modelBuilder.Entity<Link>(d =>
            {
                d.HasKey(s => s.Id);
                d.Property(s => s.Url).IsRequired();
                d.Property(s => s.LinkType).IsRequired();
            });

            modelBuilder.CategorySeed();
            modelBuilder.CourseSeed();
            // modelBuilder.CoursePartSeed();
            // modelBuilder.CoursePartArticleSeed();
            // modelBuilder.ArticleSeed();
            // modelBuilder.LinkSeed();

            base.OnModelCreating(modelBuilder);
        }

    }
}
