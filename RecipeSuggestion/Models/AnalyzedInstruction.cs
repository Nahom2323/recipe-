using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
	public class AnalyzedInstruction
	{
		public string Name { get; set; }

		public List<Steps> Steps { get; set; }
	}
}
