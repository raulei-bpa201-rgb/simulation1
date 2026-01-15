using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simiulationraul.Areas.Admin.ViewModels;
using simiulationraul.DAL;
using simiulationraul.Utilities.Extensions;
using simiulationraul.Utilities.Enums;
using System.Threading.Tasks;
using simiulationraul.Models;
using simiulationraul.DAL;
using simiulationraul.Models;

namespace simiulationraul.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TrainerController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _env;
		public TrainerController(AppDbContext context, IWebHostEnvironment env)
		{
			_context = context;
			_env = env;
		}
		public async Task<IActionResult> Index()
		{
			List<Trainer> trainers = await _context.Trainers.ToListAsync();
			return View(trainers);
		}
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateTrainerVM createTrainerVM)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			if (!createTrainerVM.Photo.ValidateType("image/"))
			{
				ModelState.AddModelError("Photo", "Faylın tipi şəkil olmalıdır!");
				return View();
			}
			if (createTrainerVM.Photo.ValidateSize(10, FileSize.MB))
			{
				ModelState.AddModelError("Photo", "Faylın ölçüsü maksimum 2MB olmalıdır!");
				return View();
			}
			Trainer trainer = new Trainer()
			{
				Name = createTrainerVM.Name,
				Title = createTrainerVM.Title,
				Description = createTrainerVM.Description,
				Image = await createTrainerVM.Photo.CreateFile(_env.WebRootPath, "assets", "images"),
			};
			await _context.Trainers.AddAsync(trainer);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1)
			{
				return BadRequest();
			}
			Trainer trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
			if (trainer == null)
			{
				return NotFound();
			}
			if (!ModelState.IsValid)
			{
				return View(trainer);
			}
			UpdateTrainerVM updateTrainerVM = new UpdateTrainerVM()
			{
				Name = trainer.Name,
				Title = trainer.Title,
				Description = trainer.Description,
				Image = trainer.Image
			};
			return View(updateTrainerVM);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, UpdateTrainerVM updateTrainerVM)
		{
			if (!ModelState.IsValid)
			{
				return View(updateTrainerVM);
			}
			Trainer trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
			if (updateTrainerVM.Photo is not null)
			{
				if (!updateTrainerVM.Photo.ValidateType("image/"))
				{
					ModelState.AddModelError("Photo", "Faylın tipi şəkil olmalıdır!");
					return View();
				}
				if (updateTrainerVM.Photo.ValidateSize(10, FileSize.MB))
				{
					ModelState.AddModelError("Photo", "Faylın ölçüsü maksimum 2MB olmalıdır!");
					return View();
				}
				string fileName = await updateTrainerVM.Photo.CreateFile(_env.WebRootPath,"assets", "images");
				trainer.Image = fileName;
			}
			trainer.Name = updateTrainerVM.Name;
			trainer.Title = updateTrainerVM.Title;
			trainer.Description = updateTrainerVM.Description;
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Detail(int? id)
		{
			if (id == null || id < 1)
			{
				return BadRequest();
			}
			Trainer trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
			if (trainer == null)
			{
				return NotFound();
			}
			return View(trainer);
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id < 1)
			{
				return BadRequest();
			}
			Trainer trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.Id == id);
			if (trainer == null)
			{
				return NotFound();
			}
			trainer.Image.DeleteFile(_env.WebRootPath,"assets", "images");
			_context.Trainers.Remove(trainer);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
	}
}