using System.Linq;
using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _repository;
        public HomeController(IPostRepository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View(_repository.Posts);
        }
    }
}