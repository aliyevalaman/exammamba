using leman_exam.Models;
using leman_exam.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace leman_exam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registervm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = new User()
            {
                Name = registervm.Name,
                Surname = registervm.Surname,
                UserName = registervm.Username,
                Email = registervm.Email,
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }





        public async Task<IActionResult> Login(LoginVm loginvm, string? ReturnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user;
            if (!loginvm.EmailorUsername.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(loginvm.EmailorUsername);
            }
            else
            {
                user = await _userManager.FindByNameAsync(loginvm.EmailorUsername);
            }
            if (user == null)
            {
                ModelState.AddModelError("", "Username or Email is false");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginvm.Password, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or Email is false");
                return View();
            }
            if (ReturnUrl != null)
            {
                return RedirectToAction(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

    }


}

