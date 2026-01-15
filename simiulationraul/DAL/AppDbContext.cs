using Microsoft.EntityFrameworkCore;
using simiulationraul.Models;
using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace simiulationraul.DAL
{
	public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Trainer> Trainers { get; set; }
	}
}
