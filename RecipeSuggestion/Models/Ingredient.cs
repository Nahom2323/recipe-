﻿using System.Collections.Generic;

namespace RecipeSuggestion.Models
{
    public class Ingredient
    {
        public string Aisle { get; set; }
        public double Amount { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public List<string> Meta { get; set; }
        public string Name { get; set; }
        public string Original { get; set; }
        public string OriginalName { get; set; }
        public string Unit { get; set; }
        public string UnitLong { get; set; }
        public string UnitShort { get; set; }
    }
}
