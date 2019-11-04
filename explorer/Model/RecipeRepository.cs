using System;
using System.Linq;

namespace explorer.Model
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Recipe> Items => _context.Recipes;
        public void SaveItem(Recipe item)
        {
            if(item.Created == default) item.Created = DateTimeOffset.Now;

            if (item.Id == default)
            {
                _context.Recipes.Add(item);
            }
            else
            {
//                _context.Recipes
            }
        }

        public Recipe DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}