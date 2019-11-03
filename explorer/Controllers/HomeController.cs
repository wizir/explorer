using System.Linq;
using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Post> _repository;
        public HomeController(IRepository<Post> repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View(_repository.Items);
        }
    }
}