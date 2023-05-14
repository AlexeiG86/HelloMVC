using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //students/details/3
        //[Route("StudentInfo/"{id:int})]



        //public IActionResult Create(string firstName, string lastName)
        //{
        //    var student = new Students() { FirstName = firstName, LastName = lastName };
        //    return View();
        //}

        public IActionResult Create(Students model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
