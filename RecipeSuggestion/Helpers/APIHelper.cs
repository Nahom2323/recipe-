using System.Net.Http;

namespace RecipeSuggestion.Helpers
{
	/* HUY'S PART */
	public static class APIHelper
	{
		private static string apiKey = "8a0179ea66554ab69e6ba8d5035ff4c4";
		/// <summary>
		/// Accepts up to 5 ingredients, leave empty string if not applicable
		/// </summary>
		/// <param name="ingredient1"></param>
		/// <param name="ingredient2"></param>
		/// <param name="ingredient3"></param>
		/// <param name="ingredient4"></param>
		/// <param name="ingredient5"></param>
		/// <returns>Recipe suggestion result in json format</returns>
		public static string SearchRecipeByIngredients(string[] ingredients)
		{
			string apiString = "https://api.spoonacular.com/recipes/findByIngredients" + $"?apiKey={apiKey}" + "&ingredients=";
			int n = 5;
			if (ingredients.Length < 5)
			{
				n = ingredients.Length;
			}
			for (int i = 0; i < n; i++)
			{
				if (ingredients[i] != "" && ingredients[i] != null)
				{
					apiString += ingredients[i]+",";
				}
			}

			// remove the last colon
			apiString = apiString.Remove(apiString.Length - 1);

			// pull api from Spoonacular
			HttpClient client = new HttpClient();
			var responseTask = client.GetAsync(apiString);
			responseTask.Wait();
			if (responseTask.IsCompleted)
			{
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var message = result.Content.ReadAsStringAsync();
					message.Wait();
					return message.Result;
				}
			}

			return "";
		}
	}
}
