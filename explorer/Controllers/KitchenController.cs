using System.Linq;
using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class KitchenController : Controller
    {
        private IRepository<Recipe> _repository;

        public KitchenController(IRepository<Recipe> repository)
        {
            _repository = repository;
            
        }

        public IActionResult Index()
        {
            return View(_repository.Items.ToList());
        }
    }
}