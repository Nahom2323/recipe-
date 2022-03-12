using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using RecipeSuggestion.Models;
using RecipeSuggestionTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSuggestionTest
{
    [TestFixture]
    public class APITest
    {
        [Test]
        public static void GetRandomRecipeTest_OutputRecipeIsNotNull()
		{
            // Arrange
            string JSONString = APIHelper.GetRandomRecipe();

            // Act
            Recipe recipe = APIHelper.ConvertJSONToOneRecipe(JSONString);

            // Assert
            Assert.IsNotNull(recipe);
		}

        [Test]
        public static void GetJSONStringFromAPITest_InputJSONString_OutputIsNotNull()
		{
            // Arrange
            string APIString = "https://api.spoonacular.com/recipes/findByIngredients?apiKey=8a0179ea66554ab69e6ba8d5035ff4c4&ingredients=bread,lettuce,cheese&number=1";

            // Act
            string JSONString = APIHelper.GetJSONStringFromAPI(APIString);
            JSONString = JSONString.Substring(1, JSONString.Length - 2);
            JObject o = JObject.Parse(JSONString);

            // Assert
            Assert.IsNotNull(o);
		}

        [Test]
        public static void SearchRecipeByIngredientsTestAndConvertJSONToListOfRecipesTest_InputOnionAndChickenAndFlour_OutputCorrectTitles()
		{
            // Arrange & Act
            string JSONString = APIHelper.SearchRecipeByIngredients(new string[] { "onion", "chicken", "flour" });
            List<Recipe> recipes = APIHelper.ConvertJSONToListOfRecipes(JSONString);

            string[] expectedTitles = new String[4]  {"Slow Cooker Rosemary Whole Chicken", "Chicken Suya", "Udon Noodles Chicken Tempura", "Baked Chicken with Cinnamon Apples"};
            // Assert
            Assert.AreEqual(expectedTitles[0], recipes[0].Title);
            Assert.AreEqual(expectedTitles[1], recipes[1].Title);
            Assert.AreEqual(expectedTitles[2], recipes[2].Title);
            Assert.AreEqual(expectedTitles[3], recipes[3].Title);
        }

        [Test]
        public static void AutoCompleteIngredientSearchTest_InputTom_OutputContainsTomato()
		{
            // Act
            string JSONString = APIHelper.AutoCompleteIngredientSearch("tom");
            string expectedString = "tomato";

            // Assert
            Assert.IsTrue(JSONString.Contains(expectedString));
		}

        [Test]
        public static void AutoCompleteIngredientSearchTest_InputChic_OutputContainsChicken()
        {
            // Act
            string JSONString = APIHelper.AutoCompleteIngredientSearch("chic");
            string expectedString = "chicken";

            // Assert
            Assert.IsTrue(JSONString.Contains(expectedString));
        }
    }
}
