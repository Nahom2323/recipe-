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
    }
}
