﻿using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
	public class Ingredient
	{
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Unit { get; set; }

        public string UnitLong { get; set; }

        public string UnitShort { get; set; }

        public string Aisle { get; set; }

        public string Name { get; set; }

        public string Original { get; set; }

        public string OriginalName { get; set; }

        public List<string> Meta { get; set; }

        public string Image { get; set; }

        public string ExtendedName { get; set; }
    }
}
