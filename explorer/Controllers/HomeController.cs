using System.Linq;
using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}