using Microsoft.EntityFrameworkCore;
using simiulationraul.Models;
namespace simiulationraul.DAL
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

		public DbSet<Trainer> Trainers { get; set; }
	}
}
