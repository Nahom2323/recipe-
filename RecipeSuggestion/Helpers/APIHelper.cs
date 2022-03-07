using RecipeSuggestion.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;

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
			// ingredients string array MUST BE PROCESSED BY IngredientStringHelper
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

			// return empty string if no result found
			return "";
		}

		/// <summary>
		/// Get a list of ingredients based on search string
		/// </summary>
		/// <param name="searchString"></param>
		/// <returns>a list of ingredients in JSON format</returns>
		public static string AutoCompleteIngredientSearch(string searchString)
		{
			string apiString = "https://api.spoonacular.com/food/ingredients/autocomplete" + $"?apiKey={apiKey}" + "&number=4" + "&metaInformation=false" + $"&query={searchString}";

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

			// return empty string if no result found
			return "";
		}

		/// <summary>
		/// Return one random recipe in JSON format
		/// </summary>
		/// <returns></returns>
		public static string GetRandomRecipe()
		{
			string apiString = "https://api.spoonacular.com/recipes/random" + $"?apiKey={apiKey}" + "&number=1";
			
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
					string returnJSONString = message.Result;

					// make string to be JSON format to be converted
					returnJSONString = returnJSONString.Substring(12, returnJSONString.Length - 14);
					return returnJSONString;
				}
			}

			// return empty string if no result found
			return "";
		}

		public static List<Recipe> ConvertJSONToListOfRecipes(string JSONString)
		{
			List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(JSONString);
			return recipes;
		}

		public static Recipe ConvertJSONToOneRecipe(string JSONString)
		{
			Recipe recipe = JsonConvert.DeserializeObject<Recipe>(JSONString);
			return recipe;
		}


		/// <summary>
		/// Convert a JSON string to a list of ingredients
		/// </summary>
		/// <param name="JSONString">the JSON string to be converted</param>
		/// <returns></returns>
		public static List<Ingredient> ConvertJSONToIngredients(string JSONString)
		{
			List<Ingredient> ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(JSONString);
			return ingredients;
		}

		
	}
}
