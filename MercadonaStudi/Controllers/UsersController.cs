using Microsoft.AspNetCore.Mvc;
using MercadonaStudi.ViewModels;
using MercadonaStudi.Services;
using MercadonaStudi.Context;
using MercadonaStudi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MercadonaStudi.Controllers
{
    public class UsersController : Controller
    {
        //private IUsersService authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            //this.authService = authService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        // Création du compte admin
        //public async Task<IActionResult> Register()
        //{
        //    var model = new RegistrationModel
        //    {
        //        Email = "admin@gmail.com",
        //        Username = "admin",
        //        Name = "Admin",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "Admin"
        //    };

        //    var result = await authService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}

        //public IActionResult Register() => View(new RegistrationViewModel());
        //https://localhost:7000/Users/Register
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        //public IActionResult Register()
        //{
        //    return View(new RegistrationViewModel());
        //}
        //[HttpPost]
        //public async Task<IActionResult> Register(RegistrationViewModel registrationViewModel)
        //{
        //    var model = new RegistrationViewModel
        //    {
        //        Email = "admin@gmail.com",
        //        Username = "admin",
        //        Name = "Admin",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",
        //        Role = "Admin"
        //    };
        //    var userExists = await _userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //    {
        //        TempData["Error"] = "Cet utilisateur existe déjà";
        //        return View(model);
        //    }
        //    ApplicationUser user = new ApplicationUser()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username,
        //        Name = model.Name,
        //        EmailConfirmed = true,
        //        PhoneNumberConfirmed = true,
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //    {
        //        TempData["Error"] = "Echec lors de la création du compte utilisateur";
        //        return View(model);
        //    }

        //    if (!await _roleManager.RoleExistsAsync(model.Role))
        //        await _roleManager.CreateAsync(new IdentityRole(model.Role));


        //    if (await _roleManager.RoleExistsAsync(model.Role))
        //    {
        //        await _userManager.AddToRoleAsync(user, model.Role);
        //    }
            
        //    return View("RegisterCompleted");

        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return View(newAdminUser);
        //    //}

        //    //var user = await _userManager.FindByNameAsync(newAdminUser.Username);
        //    //if (user != null)
        //    //{
        //    //    TempData["Error"] = "Cet utilisateur existe déjà";
        //    //    return View(newAdminUser);
        //    //}

        //    //var newUser = new ApplicationUser()
        //    //{
        //    //    SecurityStamp = Guid.NewGuid().ToString(),
        //    //    Name = newAdminUser.Name,
        //    //    Email = newAdminUser.Email,
        //    //    UserName = newAdminUser.Username,
        //    //    EmailConfirmed = true
                
        //    //    //Email = registrationViewModel.Email,
        //    //    //Name = registrationViewModel.Username
        //    //};
        //    //var result = await _userManager.CreateAsync(newUser, newAdminUser.Password);
        //    //if (!result.Succeeded)
        //    //{
        //    //    TempData["Error"] = "Echec lors de la création du compte utilisateur";
        //    //    return View(newAdminUser);
        //    //}

        //    ////if (result.Succeeded)
        //    ////    await _userManager.AddToRoleAsync(newUser, "Admin");
        //    //if (!await _roleManager.RoleExistsAsync(newAdminUser.Role))
        //    //    await _roleManager.CreateAsync(new IdentityRole(newAdminUser.Role));


        //    //if (await _roleManager.RoleExistsAsync(newAdminUser.Role))
        //    //{
        //    //    await _userManager.AddToRoleAsync(newUser, newAdminUser.Role);
        //    //}
        //    //return View("RegisterCompleted");
        //}

        //public async Task<IActionResult> Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    var result = await authService.LoginAsync(model);

        //    if (result.StatusCode == 1)
        //        return RedirectToAction("Index", "Home");
        //    else
        //    {
        //        TempData["msg"] = "Identifiant / mot de passe invalide";
        //        return RedirectToAction(nameof(Login));
        //    }
        //}

        //public IActionResult Login()
        //{
        //    return View(new LoginViewModel());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(loginViewModel);
        //    }

        //    var user = await _userManager.FindByNameAsync(loginViewModel.Username);
        //    if (user != null)
        //    {
        //        var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
        //        if (passwordCheck)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        TempData["Error"] = "Identifiant / mot de passe invalide";
        //        return View(loginViewModel);
        //    }

        //    TempData["Error"] = "Wrong credentials. Please, try again!";
        //    return View(loginViewModel);
        //}

        public IActionResult Login() => View(new LoginViewModel());

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }
        //public async Task<IActionResult> Logout()
        //{
        //   await authService.LogoutAsync();
        //    return RedirectToAction(nameof(Login));
        //}

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
