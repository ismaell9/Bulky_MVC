using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "SciFi", DisplayOrder = 3 }

                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Author = "Hamed", Description = "Book About EveryDay's life", ISBN = "857-6-11-123455-5", ListPrice = 5.25, Price = 6.45, Price100 = 8.95, Price50 = 9.4, Title="Life Book"},
                new Product { Id = 2, Author = "Sameh", Description = "Book About Good Partener in life", ISBN = "978-3-16-148410-0", ListPrice = 7.55, Price = 5.41, Price100 = 4.05, Price50 = 8.2, Title = "Partner in Life Book" },
                new Product { Id = 3, Author = "Ahmed", Description = "Book About How to be a SuperHero", ISBN = "957-2-14-122014-2", ListPrice = 2.57, Price = 7.75, Price100 = 4.8, Price50 = 2.99, Title = "SuperHeros mood" }
                );
        }

    }
}
