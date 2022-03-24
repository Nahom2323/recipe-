using System.Collections.Generic;

namespace RecipeSuggestion.Models.ViewModel
{
	public class ResultPageViewModel
	{
		public List<ShortRecipe> ShortRecipes { get; set; }
		public List<Recipe> Recipes { get; set; }

		/* FILTER */
		public bool isVegan { get; set; }
		public bool isGlutenFree { get; set; }
		public bool isDairyFree { get; set; }
		public bool isHealthy { get; set; }
	}
}
