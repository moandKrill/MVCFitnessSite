using Less2_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Less2_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Регистрация DbContext с правильными параметрами
            builder.Services.AddDbContext<TrainerContext>(options =>
                options.UseMySql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 25))
                ));

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Работа с базой данных через DI
            using (IServiceScope scope = app.Services.CreateScope())
            {
                TrainerContext db = scope.ServiceProvider.GetRequiredService<TrainerContext>();
                // db.Database.EnsureCreated();

                // Проверяем есть ли уже тренеры
                if (!db.Trainers.Any())
                {
                    // Добавление данных
                    db.Trainers.AddRange(
                        new Trainer
                        {
                            //id_trainer = 100,
                            name = "Tom2",
                            telephone = "9184184222",
                            trainer_info = "Лучший тренер",
                            photo_url = "images/trainer1.jpg"
                        },
                        new Trainer
                        {
                            //id_trainer = 101,
                            name = "Джерри2",
                            telephone = "9884184333",
                            trainer_info = "Самый Лучший тренер",
                            photo_url = "images/trainer2.jpg"
                        }
                    );
                    db.SaveChanges();
                    Console.WriteLine("Данные успешно добавлены!");
                }
                else
                {
                    Console.WriteLine("Данные уже существуют в БД");
                }

                db.Database.EnsureCreated();

                // Получение данных
                Console.WriteLine("Список объектов:");
                foreach (Trainer? u in db.Trainers.ToList())
                {
                    Console.WriteLine($"{u.id_trainer}.{u.name}.{u.telephone}.{u.trainer_info}.{u.photo_url}");
                }
            }
            using (IServiceScope scope = app.Services.CreateScope())
            {
                TrainerContext db = scope.ServiceProvider.GetRequiredService<TrainerContext>();

            }

            app.Run();
        }
    }
}
