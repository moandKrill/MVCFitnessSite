using Less2_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Less2_MVC.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
            : base(options)
        {

        }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Здесь можно настроить модель, например:
            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.Property(t => t.name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.telephone).HasMaxLength(100);
                // Другие настройки...
            });
        }


    }
}
