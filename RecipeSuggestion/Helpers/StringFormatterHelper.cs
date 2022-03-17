using System.Collections.Generic;

namespace RecipeSuggestion.Helpers
{
	public class StringFormatterHelper
	{
		/// <summary>
		/// [" a","b  c","  d "] -> "a, b c, d"
		/// </summary>
		/// <param name="stringArray"></param>
		/// <returns></returns>
		public static string StringArrayFormatter(List<string> stringArray)
		{
			string returnString = "";

			for (int i = 0; i < stringArray.Count; i++)
			{
				returnString += stringArray[i].Trim();
				if (i < stringArray.Count-1)
				{
					returnString += ", ";
				}
			}
			return returnString;
		}
	}
}
