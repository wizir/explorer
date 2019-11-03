using System;

namespace explorer.Model
{
    public class RecipeEntry
    {
        public Recipe Recipe { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}