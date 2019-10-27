using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class KitchenController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}