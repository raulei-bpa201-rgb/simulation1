using Microsoft.AspNetCore.Mvc;
using simiulationraul.Models.Base;
namespace simiulationraul.Models
{
	public class Trainer:BaseEntity
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string? Image {  get; set; }
	}
}
