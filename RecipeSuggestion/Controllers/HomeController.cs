﻿using Microsoft.AspNetCore.Mvc;
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

            ResultPageViewModel rpvm = new ResultPageViewModel();
            rpvm.ShortRecipes = shortRecipes;
            rpvm.Recipes = recipes;

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
    }
}
