using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrayaAct.Data;
using OrayaAct.ViewModel;

namespace OrayaAct.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<UserIden> _signInManager;
        private readonly UserManager<UserIden> _userManager;

        public AccountController(SignInManager<UserIden> signInManager, UserManager<UserIden> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel logInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(logInfo.Username, logInfo.password, logInfo.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Instructor");
            }
            else
            {
                ModelState.AddModelError("", "Failed to login");
            }
            return View(logInfo);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Instructor");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userData)
        {
            if (ModelState.IsValid)
            {
                UserIden newUser = new UserIden();
                newUser.UserName = userData.username;
                newUser.FirstName = userData.FirstName;
                newUser.LastName = userData.LastName;
                var result = await _userManager.CreateAsync(newUser, userData.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(userData);
        }
    }
}
