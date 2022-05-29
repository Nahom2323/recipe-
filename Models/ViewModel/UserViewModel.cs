using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSuggestion.Models.ViewModel
{
	public class UserViewModel
	{
		public IEnumerable<User> Users { get; set; }
		public IEnumerable<IdentityRole> Roles { get; set; }
	}
}
