using System.Linq;
using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Page> _repository;
        public HomeController(IRepository<Page> repository)
        {
            _repository = repository;
        }
        
        public IActionResult Index()
        {
            return View(_repository.Items);
        }
    }
}