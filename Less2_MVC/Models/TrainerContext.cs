using Microsoft.EntityFrameworkCore;

namespace Less2_MVC.Models
{
    public class TrainerContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }

        public TrainerContext(DbContextOptions<TrainerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Явно указываем имя таблицы (как в БД)
            modelBuilder.Entity<Trainer>().ToTable("trainers");

            // Дополнительно можно указать ключ и другие настройки
            modelBuilder.Entity<Trainer>().HasKey(t => t.id_trainer); // Первичный ключ
        }
    }
}
