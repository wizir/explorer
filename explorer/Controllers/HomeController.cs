using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}