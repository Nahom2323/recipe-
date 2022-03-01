namespace RecipeSuggestion.Helpers
{
	public static class IngredientStringHelper
	{
		/// <summary>
		/// Return a string without whitespaces for api use
		/// </summary>
		/// <param name="ingredient"></param>
		/// <returns></returns>
		public static string FormatIngredientString(string ingredient)
		{
			// remove leading and trailing white space
			ingredient = ingredient.Trim();

			// remove white space between words
			ingredient = ingredient.Replace(" ", "");

			return ingredient;
		}
	}
}
