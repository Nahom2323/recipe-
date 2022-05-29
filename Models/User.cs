using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSuggestion.Models
{
	public class User : IdentityUser
	{
		[NotMapped]
		public IList<string> RoleNames { get; set; }

		public virtual UserInformation UserInformation { get; set; }

	}
}
