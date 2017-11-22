using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScienceActivityRecorder.Models;
using ScienceActivityRecorder.ViewModels;
using System.Threading.Tasks;

namespace ScienceActivityRecorder.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var login = viewModel.Login;
            var result = await _signInManager.PasswordSignInAsync(login.Name, login.Password, login.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Generic", "Помилка входу у систему");
            return View(viewModel);
        }

        public IActionResult Exit()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
