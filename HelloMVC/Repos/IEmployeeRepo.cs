using HelloMVC.Models;

namespace HelloMVC.Repos
{
    public interface IEmployeeRepo
    {

        public List<Employee> EmployeeMockRepo();
        public Employee CreateEmployee(Employee employee);
        public Employee GetById(int id);
    }
}
