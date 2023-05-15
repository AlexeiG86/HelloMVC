using HelloMVC.Models;
using HelloMVC.Repos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HelloMVC.Controllers
{
    public class EmployeesController : Controller
    {
        public static EmployeeMockRepo employeeRepo = new EmployeeMockRepo();//becouse in asp everything will be lost ,on controller level we create static variable

        public EmployeesController()  //constructor
        {
         //   employeeRepo = new EmployeeMockRepo();
        }

       public IActionResult Index()
        {
            var emplyeeData = employeeRepo.GetEmployees();
           // var data = new EmployeeMockRepo();
            return View(emplyeeData);

        }

        public IActionResult Create()  //creating a new action and a view for this action the view should have the action name
        {
            return View();  //this view is the form that we need to submit
        }

      

        [HttpPost]  // we receive the entire object,, we receive the Employee as the model
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


        public IActionResult ManageVacation(Employee model)
        {
            var vacationList = employeeRepo.GetVacations(model.EmployeeId);
            return View("ManageVacation", vacationList);

        }




        public IActionResult CreateVacation(int employeeId)
        {
            return View(new VacationRequest { EmployeeId = employeeId });
        }

        [HttpPost]
        public IActionResult CreateVacation(VacationRequest vacation)
        {
            var employee = employeeRepo.GetEmployees().FirstOrDefault(e => e.EmployeeId == vacation.EmployeeId);
            if (employee != null)
            {
                employee.VacationRequests.Add(vacation);
                return RedirectToAction("Index", new { id = vacation.EmployeeId });
            }
            return View(vacation);
        }

        public IActionResult DeleteVacation(int employeeId, int vacationRequestId)
        {
            var employee = employeeRepo.GetEmployees().FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                var vacation = employee.VacationRequests.FirstOrDefault(v => v.VacationRequestId == vacationRequestId);
                if (vacation != null)
                {
                    employee.VacationRequests.Remove(vacation);
                }
                return RedirectToAction("Index", new { id = employeeId });
            }
            return RedirectToAction("Index", "Employee");
        }
     
    }
}
