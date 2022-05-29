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
		// main
		private static string apiKey = "8a0179ea66554ab69e6ba8d5035ff4c4";

		// secondary api keys
		private static string apiKey2 = "b4b3711112c44df7911016052365c1d9";
		private static string apiKey3 = "d7b1d65daf3b4846b069e98155097e21";
		private static string apiKey4 = "d873a6671d264222810681f28296d532";

		// back-up api keys
		private static string apiKey5 = "1a529aa1e8a2499baca2dd35ff77e292";
		private static string apiKey6 = "450731ff225445bd9b2aa59d51f0ed25";
		private static string apiKey7 = "907e33a0256f455f84fb95bfd8d8f096";
		private static string apiKey8 = "1cb947e7ecf14afaab8d75e4723bf0e1";

		// this settings may help prevent error in covertting null to int
		public static JsonSerializerSettings settings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			MissingMemberHandling = MissingMemberHandling.Ignore
		};

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

			return GetJSONStringFromAPI(apiString);
		}

		/// <summary>
		/// Return one random recipe in JSON format
		/// </summary>
		/// <returns></returns>
		public static string GetRandomRecipe()
		{
			string apiString = "https://api.spoonacular.com/recipes/random" + $"?apiKey={apiKey2}" + "&number=1";
			
			string returnJSONString = GetJSONStringFromAPI(apiString);

			if (returnJSONString != "")
			{
				// make string to be JSON format to be converted
				returnJSONString = returnJSONString.Substring(12, returnJSONString.Length - 14);
			}

			return returnJSONString;
		}

		public static List<Recipe> ConvertJSONToListOfRecipes(string JSONString)
		{
			List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(JSONString, settings);
			return recipes;
		}
		public static List<ShortRecipe> ConvertJSONToListOfShortRecipes(string JSONString)
        {
			List<ShortRecipe> recipes = JsonConvert.DeserializeObject<List<ShortRecipe>>(JSONString);
			return recipes;
		}
		public static Recipe ConvertJSONToOneRecipe(string JSONString)
		{
			Recipe recipe = JsonConvert.DeserializeObject<Recipe>(JSONString,settings);
			return recipe;
		}


		/// <summary>
		/// Convert a JSON string to a list of ingredients
		/// </summary>
		/// <param name="JSONString">the JSON string to be converted</param>
		/// <returns></returns>
		public static List<IngredientSuggestion> ConvertJSONToIngredients(string JSONString)
		{
			List<IngredientSuggestion> ingredients = JsonConvert.DeserializeObject<List<IngredientSuggestion>>(JSONString);
			return ingredients;
		}

		/// <summary>
		/// Main method for getting JSON string using api
		/// </summary>
		/// <param name="APIString"></param>
		/// <returns></returns>
		public static string GetJSONStringFromAPI(string APIString)
		{
			// pull api from Spoonacular
			HttpClient client = new HttpClient();
			var responseTask = client.GetAsync(APIString);
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
		/// Get the exact recipe from an id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static Recipe GetRecipeFromId(int id)
		{
			string APIString = "https://api.spoonacular.com/recipes/" + id.ToString() + $"/information?apiKey={apiKey3}";
			string JSONString = GetJSONStringFromAPI(APIString);
			Recipe recipe = ConvertJSONToOneRecipe(JSONString);

			return recipe;
		}

		public static List<Recipe> GetRecipeFromMultipleIds(List<int> ids)
		{
			string APIString = $"https://api.spoonacular.com/recipes/informationBulk?apiKey={apiKey4}&ids=";
			foreach (int id in ids)
			{
				APIString += id.ToString() + ",";
			}
			APIString = APIString.Remove(APIString.Length-1,1);

			string JSONString = GetJSONStringFromAPI(APIString);
			List<Recipe> recipes = ConvertJSONToListOfRecipes(JSONString);
			return recipes;
		}
	}
}
