using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeSuggestion.Helpers;
using RecipeSuggestion.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSuggestion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Result(string[] ingredients)
        {
            ingredients = new string[] { "potato", "onion" };
            string JSONString = APIHelper.SearchRecipeByIngredients(ingredients);
            List<Recipe> recipes = APIHelper.ConvertJSONToListOfRecipes(JSONString);

			for (int i = 0; i < recipes.Count; i++)
			{
                recipes[i] = APIHelper.GetRecipeFromId(recipes[i].Id);
			}

            Debug.WriteLine(recipes[0].Cuisines[0].ToString());

            return View(recipes);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public void Test()
		{
            APIHelper.Test();
		}
    }
}
