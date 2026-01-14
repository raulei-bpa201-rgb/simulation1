using Microsoft.AspNetCore.Mvc;

namespace simiulationraul.Models
{
	public class Trainer
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image {  get; set; }
	}
}
