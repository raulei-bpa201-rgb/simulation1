using Microsoft.AspNetCore.Mvc;
using simiulationraul.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using simiulationraul.DAL;
using simiulationraul.ViewModels;
namespace simiulationraul.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Trainer> trainers = _context.Trainers.ToList();

            return View(trainers);
        }
    }
}
