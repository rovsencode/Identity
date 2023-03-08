using FirelloProject.Models;
using FirelloProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FirelloProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            AppUser user = new();
            user.Email= register.Email;
            user.UserName = register.Username;
            user.FullName = register.FullName;
          IdentityResult result= await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            //add in role

            //sign in
            _signInManager.SignInAsync(user, true);

            return RedirectToAction("home","index");

        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
