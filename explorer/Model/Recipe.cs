using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace explorer.Model
{
    [Table("Recipes")]
    public class Recipe : DatabaseObject
    {
        public string DishName { get; set; }
        public string Description { get; set; }
        public string CookingProcess { get; set; }

        public IEnumerable<Component> Ingredients { get; set; }

        public class Component : DatabaseObject
        {
            public Ingredient Ingredient { get; set; }
            public string Amount { get; set; }
        }
        
        public class Ingredient : DatabaseObject
        {
            public string Name { get; set; }
        }
    }
}