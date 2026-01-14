using Microsoft.AspNetCore.Mvc;

namespace simiulationraul.Areas.Admin.Conntrollers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
