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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace RecipeSuggestion.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private RecipeSuggestionDbContext context { get; set; }

		public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, RecipeSuggestionDbContext recipeSuggestionDbContext)
		{
			_logger = logger;
			_userManager = userManager;
			context = recipeSuggestionDbContext;
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

            /* For recently viewed */
            if (HttpContext.Session.GetString("recentlyViewedRecipe") != null)
            {
                string recentlyViewedRecipeString = HttpContext.Session.GetString("recentlyViewedRecipe");

                // if recipe is already in the string, remove it (to make sure the recipe is in the oldest-newest sequence )
                if (recentlyViewedRecipeString.Contains(recipeId.ToString()))
				{
                    if (!recentlyViewedRecipeString.EndsWith(recipeId.ToString()))
                    {
                        recentlyViewedRecipeString = recentlyViewedRecipeString.Remove(
                        startIndex: recentlyViewedRecipeString.IndexOf(recipeId.ToString()),
                        count: recipeId.ToString().Length + 1);

                        // newest recipe stays at the end of the string
                        recentlyViewedRecipeString += "," + recipeId.ToString();
                    }
                }
				else
				{
                    // newest recipe stays at the end of the string
                    recentlyViewedRecipeString += "," + recipeId.ToString();
                }
                HttpContext.Session.SetString("recentlyViewedRecipe", recentlyViewedRecipeString);
            }
			else
			{
                HttpContext.Session.SetString("recentlyViewedRecipe", recipeId.ToString());
            }

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

        // this method is for adding recipe to save list and redirect back to detail page
        [Authorize]
        public IActionResult SaveRecipe(int recipeId)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            UserInformation userInformation = context.UserInformations.Find(userId);

            // if user already has at least 1 saved recipe
            if (userInformation != null)
            {
                if (userInformation.SavedRecipeIds.Contains(recipeId.ToString()))
				{
                    TempData["Message"] = "This recipe is already in save list!";

                }
				else
				{
                    string newSaveRecipeIds = userInformation.SavedRecipeIds + "," + recipeId.ToString();
                    UserInformation newUserInformation = new UserInformation
                    {
                        UserId = userId,
                        SavedRecipeIds = newSaveRecipeIds
                    };

                    context.Remove(userInformation);
                    context.Add(newUserInformation);
                    context.SaveChanges();
                    TempData["Message"] = "Recipe added to saved list";
                }
            }

            // if user has nothing in saved recipe list
            else
            {
                UserInformation newUserInformation = new UserInformation
                {
                    UserId = userId,
                    SavedRecipeIds = recipeId.ToString()
                };
                context.Add(newUserInformation);
                context.SaveChanges();
                TempData["Message"] = "Recipe added to saved list";
            }
            
            return RedirectToAction("Detail", new { recipeId = recipeId });
        }

        // this method is for SaveRecipe View Page
        [Authorize]
        [HttpGet]
        public IActionResult SavedRecipe()
        {
            List<Recipe> recipes = new List<Recipe>();
            string userID = _userManager.GetUserId(HttpContext.User);
            UserInformation userInformation = context.UserInformations.Find(userID);

            if (userInformation != null)
			{
                string[] savedRecipeIds = userInformation.SavedRecipeIds.Split(',');
                foreach (string savedRecipeId in savedRecipeIds)
				{
                    recipes.Add(APIHelper.GetRecipeFromId(int.Parse(savedRecipeId)));
				}
			}

            // the "reverse" makes newest item in the saved list appears first
            if (recipes.Count > 0)
			{
                recipes.Reverse();
            }

            return View(recipes);
        }

        [Authorize]
        public IActionResult RemoveRecipeFromSaveList(int recipeId)
		{
            string userID = _userManager.GetUserId(HttpContext.User);
            UserInformation userInformation = context.UserInformations.Find(userID);

            if (userInformation != null)
			{
                if (userInformation.SavedRecipeIds.Contains(recipeId.ToString()))
                {
                    string[] savedRecipeIds = userInformation.SavedRecipeIds.Split(',');
                    List<string> saveRecipeIdsList = savedRecipeIds.ToList();
                    if (saveRecipeIdsList.Remove(recipeId.ToString()))
					{
                        TempData["SavedRecipeMessage"] = "Recipe removed from saved list.";
                    }
					else
					{
                        TempData["SavedRecipeMessage"] = "There's an error when the recipe being removed.";
                    }
                }
            }

            return RedirectToAction("SavedRecipe");
        }

        [HttpGet]
        public IActionResult RecentView()
        {
            List<Recipe> recipes = new List<Recipe>();
            if (HttpContext.Session.GetString("recentlyViewedRecipe") != null)
            {
                string recentlyViewedRecipeString = HttpContext.Session.GetString("recentlyViewedRecipe");
                string[] recipeIdStringArray = recentlyViewedRecipeString.Split(',');

                foreach (string recipeId in recipeIdStringArray)
                {
                    recipes.Add(APIHelper.GetRecipeFromId(int.Parse(recipeId)));
                }
            }
            return View(recipes);
        }
    }
}
