using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
    public class ShortRecipe
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public int Likes { get; set; }
        public int MissedIngredientCount { get; set; }
        public List<Ingredient> MissedIngredients { get; set; }
        public string Title { get; set; }
        public List<Ingredient> UnusedIngredients { get; set; }
        public int UsedIngredientCount { get; set; }
        public List<Ingredient> UsedIngredients { get; set; }
    }
}
