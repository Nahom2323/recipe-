using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecipeSuggestion.Helpers;
using RecipeSuggestion.Models;
using RecipeSuggestion.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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
        public IActionResult RecentView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SavedRecipe()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            string randomRecipeString = APIHelper.GetRandomRecipe();
            Recipe randomRecipe = APIHelper.ConvertJSONToOneRecipe(randomRecipeString);

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

            // check if the user entered at least 1 ingredient
            if (numberOfIngredientsUserEntered == 0)
            {
                TempData["Error_NoIngredientsEntered"] = "Please enter at least 1 ingredient.";
                return RedirectToAction("Index", "Home");
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

            // check if input strings are all valid
            Regex rg = new Regex(new string("^[A-Za-z ]+$"));
			foreach (string item in ingredients)
			{
                if (!rg.IsMatch(item))
				{
                    TempData["Error_NoNumberNoSpecialCharacter"] = "Numbers and special charater is not allowed";
                    return RedirectToAction("Index", "Home");
                }
			}

            string JSONString = APIHelper.SearchRecipeByIngredients(ingredients);
            List<ShortRecipe> shortRecipes = APIHelper.ConvertJSONToListOfShortRecipes(JSONString);
            List<int> ids= new List<int>();
			foreach (ShortRecipe shortRecipe in shortRecipes)
			{
                ids.Add(shortRecipe.Id);
			}

            List<Recipe> recipes = APIHelper.GetRecipeFromMultipleIds(ids);
            List<bool> isRecipeDisplayed= new List<bool>();
			for (int i = 0; i < recipes.Count; i++)
			{
                isRecipeDisplayed.Add(true);
			}
            ResultPageViewModel rpvm = new ResultPageViewModel{
                ShortRecipes = shortRecipes,
                Recipes = recipes,
                IsRecipeDisplayed = isRecipeDisplayed
            };
            string rpvmJSON = JsonConvert.SerializeObject(rpvm);
            HttpContext.Session.SetString("currentResult", rpvmJSON);

            return View(rpvm);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Detail(int recipeId)
        {
            Recipe recipe = APIHelper.GetRecipeFromId(recipeId);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Filter(ResultPageViewModel rpvm)
		{
            string currentResultJSON = HttpContext.Session.GetString("currentResult");
            ResultPageViewModel oldModel = JsonConvert.DeserializeObject<ResultPageViewModel>(currentResultJSON);
            
            rpvm.ShortRecipes = oldModel.ShortRecipes;
            rpvm.Recipes = oldModel.Recipes;
            rpvm.IsRecipeDisplayed = oldModel.IsRecipeDisplayed;

            for (int i = 0; i < oldModel.ShortRecipes.Count; i++)
            {
                rpvm.IsRecipeDisplayed[i] = true;
            }

            if (rpvm.isVegan)
			{
				for (int i = 0; i < rpvm.Recipes.Count; i++)
				{
                    if (!rpvm.Recipes[i].Vegan)
					{
                        rpvm.IsRecipeDisplayed[i] = false;
					}
				}
			}

            if (rpvm.isGlutenFree)
            {
                for (int i = 0; i < rpvm.Recipes.Count; i++)
                {
                    if (!rpvm.Recipes[i].GlutenFree)
                    {
                        rpvm.IsRecipeDisplayed[i] = false;
                    }
                }
            }

            if (rpvm.isDairyFree)
            {
                for (int i = 0; i < rpvm.Recipes.Count; i++)
                {
                    if (!rpvm.Recipes[i].DairyFree)
                    {
                        rpvm.IsRecipeDisplayed[i] = false;
                    }
                }
            }

            if (rpvm.isHealthy)
            {
                for (int i = 0; i < rpvm.Recipes.Count; i++)
                {
                    if (!rpvm.Recipes[i].VeryHealthy)
                    {
                        rpvm.IsRecipeDisplayed[i] = false;
                    }
                }
            }
            return View("Result", rpvm);
		}
    }
}
