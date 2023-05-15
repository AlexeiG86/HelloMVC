using HelloMVC.Models;

namespace HelloMVC.Repos
{
    public interface IEmployeeRepo
    {

        public List<Employee> EmployeeMockRepo();
        public Employee CreateEmployee(Employee employee);//when we create an employee should take an input of employee
        public Employee GetById(int id);
    }
}
