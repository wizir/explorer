using System.Linq;

namespace explorer.Model
{
    public class RecipeRepository : IRepository<RecipeEntry>
    {
        private readonly ApplicationDbContext _contest;

        public RecipeRepository(ApplicationDbContext contest)
        {
            _contest = contest;
        }

        public IQueryable<RecipeEntry> Items => _contest.Recipes;
        public void SaveItem(RecipeEntry post)
        {
            throw new System.NotImplementedException();
        }

        public RecipeEntry DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}