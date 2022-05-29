namespace RecipeSuggestion.Helpers
{
	public static class StringHelper
	{
		/// <summary>
		/// Return Yes if boolean b is true and reverse
		/// </summary>
		/// <param name="b"></param>
		/// <returns></returns>
		public static string ConvertBoolToYesOrNo(bool b)
		{
			if (b)
			{
				return "Yes";
			}
			else
			{
				return "No";
			}
		}

	}
}