using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Reinforced.Typings.Attributes;


namespace explorer.Model
{
    [TsClass]
    [Table("Recipes")]
    public class Recipe : DatabaseObject
    {
        public string DishName { get; set; }
        public string Description { get; set; }
        public string CookingProcess { get; set; }

        public IEnumerable<Component> Ingredients { get; set; }
        
        [TsClass]
        public class Component : DatabaseObject
        {
            public Ingredient Ingredient { get; set; }
            public string Amount { get; set; }
        }
        
        [TsClass]
        public class Ingredient : DatabaseObject
        {
            public string Name { get; set; }
        }
    }
}