using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using RecipeSuggestion.Models;

namespace RecipeSuggestion.Helpers
{
	public class UserHelper
	{
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;

		public UserHelper(UserManager<User> userMngr, SignInManager<User> signInMngr)
		{
			_userManager = userMngr;
			_signInManager = signInMngr;
		}

		public async Task<string> GetUserEmailAddressAsync(System.Security.Claims.ClaimsPrincipal User)
		{
			var user = await _userManager.GetUserAsync(User);

			return user.Email;
		}
	}
}
