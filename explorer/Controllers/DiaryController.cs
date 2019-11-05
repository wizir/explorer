using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class DiaryController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}