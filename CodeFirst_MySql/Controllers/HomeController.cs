using CodeFirst_MySql.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CodeFirst_MySql.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext contxt;

        public HomeController(ILogger<HomeController> logger, DemoContext contxt)
        {
            this.contxt = contxt;

            _logger = logger;
        }

        public IActionResult Index()
        {
            List<User> data = new List<User>();
            for (int i = 0; i < 2; i++)
            {
                var user = new User()
                {
                    FirstName = "First_" + i,
                    LastName = "Last _" + i,
                    UserGroupId = i,
                    CreationDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                  
                };

                data.Add(user);
            }

            contxt.Users.AddRange(data);
            contxt.SaveChanges();

            
            return View(contxt.Users.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}