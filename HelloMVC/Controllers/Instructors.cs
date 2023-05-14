using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class Instructors : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
