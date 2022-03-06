using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
	public class Old_Recipe
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string ImageType { get; set; }

        public int UsedIngredientCount { get; set; }

        public int MissedIngredientCount { get; set; }

        public List<Old_Ingredient> MissedIngredients { get; set; }

        public List<Old_Ingredient> UsedIngredients { get; set; }

        public List<Old_Ingredient> UnusedIngredients { get; set; }

        public int Likes { get; set; }
    }
}
