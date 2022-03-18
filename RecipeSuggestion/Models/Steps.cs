using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
	public class Steps
	{
		public int Number { get; set; }

		// step description
		public string Step { get; set; }

		public List<IngredientSuggestion> Ingredients { get; set; }

		public List<Equipment> Equipment { get; set; }

		// how long does it take
		public Length Length { get; set; }
	}
}
