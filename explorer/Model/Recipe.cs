using System;
using System.Collections.Generic;

namespace explorer.Model
{
    public class Recipe
    {
        public string DishName { get; set; }
        public string Description { get; set; }
        public string CookingProcess { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}