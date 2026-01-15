using Microsoft.AspNetCore.Identity;

namespace simiulationraul.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
	}
}