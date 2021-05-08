using Microsoft.AspNetCore.Mvc;

namespace QiuckDotNetUIDemo.Controllers
{
	public class HomeController : Controller
    {
		public IActionResult Index()
		{
			return View();
		}
    }
}
