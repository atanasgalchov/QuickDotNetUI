using Microsoft.AspNetCore.Mvc;
using QiuckDotNetUIDemo.Models;
using System;

namespace QiuckDotNetUIDemo.Controllers
{
	public class FormsController : Controller
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

		[HttpPost]
		public IActionResult Index(EmployeeViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);


			return RedirectToAction("Index");
		}
	}
}
