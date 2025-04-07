using Less2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Less2_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }

        public IActionResult Index()
        {
            using (IServiceScope scope = this.HttpContext.RequestServices.CreateScope())
            {
                TrainerContext db = scope.ServiceProvider.GetRequiredService<TrainerContext>();
                List<Trainer> trainers = db.Trainers.ToList();
                return this.View(trainers);
            }
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
