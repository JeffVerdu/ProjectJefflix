using Microsoft.AspNetCore.Mvc;

namespace JefflixMVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Hola()
        {
            return View();
        }
    }
}
