using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeSuggestion.Helpers;
using RecipeSuggestion.Models;
using RecipeSuggestion.Models.ViewModel;
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

        [HttpGet]
        public IActionResult Index()
        {
            string randomRecipeString = APIHelper.GetRandomRecipe();
            Recipe randomRecipe=APIHelper.ConvertJSONToOneRecipe(randomRecipeString);

            IndexPageViewModel ipvm = new IndexPageViewModel();
            ipvm.RandomRecipeSuggestion = randomRecipe;

            return View(ipvm);
        }

        [HttpPost]
        public IActionResult Result(string ingredient1, string ingredient2, string ingredient3, string ingredient4, string ingredient5)
        {
            // I tried to convert 5 ingredients to an array
            List<string> temporaryList = new List<string>();
            temporaryList.Add(ingredient1);
            temporaryList.Add(ingredient2);
            temporaryList.Add(ingredient3);
            temporaryList.Add(ingredient4);
            temporaryList.Add(ingredient5);

            int numberOfIngredientsUserEntered = 0;
			foreach (string ingredient in temporaryList)
			{
                if (ingredient != null)
				{
                    if (ingredient.Trim() != "")
                    {
                        numberOfIngredientsUserEntered++;
                    }
                }
			}

            string[] ingredients = new string[numberOfIngredientsUserEntered];
            int n = 0;
            for (int i = 0; i < temporaryList.Count; i++)
			{
                if (temporaryList[i] != null)
                {
                    if (temporaryList[i] != "")
                    {
                        ingredients[n++] = temporaryList[i].Trim();
                    }
                }
			}

            string JSONString = APIHelper.SearchRecipeByIngredients(ingredients);
            List<ShortRecipe> recipes = APIHelper.ConvertJSONToListOfShortRecipes(JSONString);

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

        public IActionResult Detail()
		{
            return View();
		}
    }
}
