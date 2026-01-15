using System.ComponentModel.DataAnnotations;

namespace simiulationraul.Areas.Admin.ViewModels
{
	public class UpdateTrainerVM
	{
		[MaxLength(15, ErrorMessage = "Max 20 symbol")]
		public string Name { get; set; }
		public string Description { get; set; }

		[MaxLength(12, ErrorMessage = "Max 20 symbol")]
		public string Title{ get; set; }

		public string? Image { get; set; }
		public IFormFile? Photo { get; set; }
	}
}