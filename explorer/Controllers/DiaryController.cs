using explorer.Model;
using Microsoft.AspNetCore.Mvc;

namespace explorer.Controllers
{
    public class DiaryController : Controller
    {
        private IRepository<Page> _repository;

        public DiaryController(IRepository<Page> repository)
        {
            _repository = repository;
        }

        // GET
        public IActionResult Index()
        {
            return View(_repository.Items);
        }
    }
}