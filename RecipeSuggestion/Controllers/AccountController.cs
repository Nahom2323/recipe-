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
        
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

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
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.EmailAddress, model.Password,
                            isPersistent: model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
		{
            var cpvm = new ChangePasswordViewModel();
            return View(cpvm);
		}

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
            if (ModelState.IsValid)
			{
                var user = await _userManager.GetUserAsync(User);
                var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.CurrentPassword);
                
                if (result.Equals(PasswordVerificationResult.Success))
                {
                    // if the currentpassword is correct
                    
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (changePasswordResult.Succeeded)
					{
                        TempData["changePasswordSuccessMessage"] = "Your password has been changed successfully.";
                        return RedirectToAction("Index", "Home");
					}
					else
					{
                        TempData["changePasswordNotSuccessMessage"] = "There was an error in changing your password. Please try again.";
                    }
                }
				else
				{
                    ModelState.AddModelError("", "Your current password is not correct.");
                    return View(model);
                }
            }
			else
			{
                ModelState.AddModelError("", "Invalid inputs, please try again");
                return View(model);
            }
            return View(model);
        }

    }
}

