using Microsoft.AspNetCore.Mvc;

namespace simiulationraul.Areas.Admin.Conntrollers
{
	public class Trainer : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
