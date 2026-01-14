using System.ComponentModel.DataAnnotations;

namespace simiulationraul.Areas.Admin.ViewModels
{
	public class TrainerVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Job { get; set; }
		public string? Image { get; set; }
	}
}