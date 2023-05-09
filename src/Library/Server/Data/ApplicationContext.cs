using Microsoft.EntityFrameworkCore;

namespace Library.Server.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().Property(prop => prop.Prize)
                .HasPrecision(precision: 9, scale: 2);

            ApplicationSeed.Seed(modelBuilder);
        }

    }
}
