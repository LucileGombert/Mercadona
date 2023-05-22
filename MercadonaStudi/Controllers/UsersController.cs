using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MercadonaStudi.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: Users/Login
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: Users/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);

                if (passwordCheck)
                {
                    var loginAttempt = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (loginAttempt.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                TempData["Error"] = "Une erreur s'est produite";

                return View(loginViewModel);
            }

            TempData["Error"] = "Une erreur s'est produite";

            return View(loginViewModel);
        }



        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
