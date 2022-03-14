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
            ingredients = new string[] { "egg", "noodle", "lettuce" };

            // not accept if list of ingredients contains more than 5 ingredients
            if (ingredients.Length<=0 || ingredients.Length > 5)
			{
                return RedirectToAction("Index");
			}

			// process ingredient string
			for (int i = 0; i < ingredients.Length; i++)
			{
                ingredients[i] = IngredientHelper.FormatIngredientString(ingredients[i]);
            }

            List<Recipe> recipes = new List<Recipe>();
            string JSONString = APIHelper.SearchRecipeByIngredients(ingredients);
            recipes = APIHelper.ConvertJSONToListOfRecipes(JSONString);
            /*
			// get detailed information about recipes
			for (int i = 0; i < recipes.Count; i++)
			{
                recipes[i] = APIHelper.GetRecipeFromId(recipes[i].Id);
            }*/
            
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
