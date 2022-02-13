using Microsoft.AspNetCore.Mvc;
using Mysql.Models;
using Mysql.Models.Repos;
using System.Diagnostics;

namespace Mysql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentRepo departmentRepo;

        public HomeController(ILogger<HomeController> logger, IDepartmentRepo departmentRepo)
        {
            _logger = logger;
            this.departmentRepo = departmentRepo;
        }

        public IActionResult Index()    
        {
            //departmentRepo.Add(new Dept() { Deptno = 2, Dname = "Department 2", Loc = "Test-2" });

            departmentRepo.AddEmp(new Emp()
            {
                Comm = null,
                Deptno = 2,
                Empno = 1,
                Ename = "Usman",
                Hiredate = DateTime.Now,
                Job = "Developer",
                Mgr = 1,
                Sal = 44.3f
            });
            
            var list= departmentRepo.GetDepartments();

            return View();
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