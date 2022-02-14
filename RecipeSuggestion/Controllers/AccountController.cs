using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeSuggestion.Models;
using RecipeSuggestion.Models.ViewModel;
using System.Threading.Tasks;

namespace RecipeSuggestion.Controllers
{
	public class AccountController : Controller
	{
        public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr)
        {
            _userManager = userMngr;
            _signInManager = signInMngr;
        }
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.EmailAddress };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LogInViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            /*if (ModelState.IsValid)*/
            {
                var result = await _signInManager.PasswordSignInAsync(model.EmailAddress, model.Password,
                            isPersistent: model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return RedirectToAction("Home", "Index");
                    }
                    else
                    {
                        return RedirectToAction("Home", "Index");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
    }
}

