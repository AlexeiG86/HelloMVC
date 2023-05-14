using HelloMVC.Models;
using HelloMVC.Repos;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class EmployeesController : Controller
    {
        public static EmployeeMockRepo employeeRepo = new EmployeeMockRepo();//becouse in asp everything will be lost 

        public EmployeesController()
        {
         //   employeeRepo = new EmployeeMockRepo();
        }

       public IActionResult Index()
        {
            var emplyeeData = employeeRepo.GetEmployees();
           // var data = new EmployeeMockRepo();
            return View(emplyeeData);

        }

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            employeeRepo.CreateEmployee(model);
            var employeeData = employeeRepo.GetEmployees();
            return RedirectToAction("Index");
        }


        public IActionResult Edit (int id)
        {
            if(id == 0)
            {
                return RedirectToAction("Index");
            }
            var employee = employeeRepo.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            employeeRepo.Update(model);
            return RedirectToAction("Index");

        }


    }
}
