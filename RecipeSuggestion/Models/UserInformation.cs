using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeSuggestion.Models
{
	// contains user info such as saved recipes
	public class UserInformation
	{
		[Key]
		public string UserId { get; set; }

		public string SavedRecipeIds { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }
	}
}
