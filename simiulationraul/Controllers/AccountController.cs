using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using simiulationraul.Models;
using simiulationraul.ViewModels.Account;
using System.Threading.Tasks;

namespace Simulation_Ticket_16.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM registerVM)
		{
			if (!ModelState.IsValid)
			{
				return View(registerVM);
			}
			AppUser user = new AppUser()
			{
				FullName = registerVM.FullName,
				UserName = registerVM.UserName,
				Email = registerVM.Email
			};
			IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);

				}
				return View();
			}
			await _signInManager.SignInAsync(user, false);
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if (!ModelState.IsValid)
			{
				return View(loginVM);
			}
			AppUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
			if (user == null)
			{
				user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
			}
			if (user == null)
			{
				ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlisdir");
				return View(loginVM);
			}
			var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			ModelState.AddModelError("", "Istifadeci adi ve ya sifre yanlisdir");
			return View(loginVM);
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}