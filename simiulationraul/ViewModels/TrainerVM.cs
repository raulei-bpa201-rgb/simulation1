using Microsoft.AspNetCore.Mvc;
using simiulationraul.Models;
namespace simiulationraul.ViewModels
{
	public class TrainerVM : Controller
	{
		public List<Trainer> Trainers { get; set; }
	}
}
