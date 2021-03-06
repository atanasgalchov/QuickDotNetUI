using Microsoft.AspNetCore.Mvc;
using QiuckDotNetUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QiuckDotNetUIDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            EmployeeViewModel model = new EmployeeViewModel()
            {
                Name = "Atanas",
                IsFired = true,
                Department = DepartmentsEnum.IT,
                BirthDate = DateTime.Now,
                CoffeeBreak = new TimeSpan(10, 15, 0),
            };

            return View(model);
        }
    }
}
