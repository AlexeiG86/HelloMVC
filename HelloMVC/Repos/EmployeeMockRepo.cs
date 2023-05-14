using HelloMVC.Models;

namespace HelloMVC.Repos
{
    public class EmployeeMockRepo : IEmployeeRepo
    {
       private static List<Employee>_employees;

        public Employee CreateEmployee(Employee employee)
        {
            employee.EmployeeId = _employees.Max(p=>p.EmployeeId)+1;
            _employees.Add(employee);
            return employee;
        }

        public EmployeeMockRepo()
        {
            var eml = new List<Employee>();
            eml.Add(new Employee()
            {
                EmployeeId = 1,
                FirstName = "Bob",
                LastName = "Smith",
                VacationRequests = new List<VacationRequest>()
            {
                new VacationRequest()
                {
                StarDate= new DateTime(2023,12,25),
                EndDate = new DateTime (2023,12,25 ),
                Comment ="Going to visit for Christmas"
                },
                new VacationRequest()
                {
                StarDate= new DateTime(2023,6,6),
                EndDate = new DateTime (2023,6,9 ),
                Comment ="Summer Vacation"
                }
            }
            });
            eml.Add(new Employee() {EmployeeId =2, FirstName = "Victoria", LastName = "Kelley" });
            eml.Add(new Employee() { EmployeeId = 3, FirstName = "Joe", LastName = "Caldwell" });
            _employees = eml;
        }
        public List<Employee> GetEmployees()
        {
            return _employees;  
        }

        public Employee GetById(int employeeId)
        {
            var response = _employees.FirstOrDefault(p => p.EmployeeId == employeeId);
            return response;

        }

        List<Employee> IEmployeeRepo.EmployeeMockRepo()
        {
            throw new NotImplementedException();
        }
        public Employee Update(Employee employee)
        {
            var entity = _employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            entity.FirstName = employee.FirstName;
            entity.LastName = employee.LastName;
            return entity;
        }

        internal List<VacationRequest> GetVacations(int id)
        {
            List<VacationRequest> tempList = new List<VacationRequest>();
            var empName = _employees.FirstOrDefault(p => p.EmployeeId == id);

            if (empName != null)
            {
                tempList = empName.VacationRequests;
            }

            return tempList;
        }

        internal void DeleteVacation(int vacationId)
        {
            List<VacationRequest> tempList = new List<VacationRequest>();
            var empName = _employees.FirstOrDefault(e => e.VacationRequests.Any(p => p.VacationRequestId == vacationId));

            if (empName != null)
            {
                VacationRequest vacationToDelete = empName.VacationRequests.FirstOrDefault(v => v.VacationRequestId == vacationId);

                if (vacationToDelete != null)
                {
                    empName.VacationRequests.Remove(vacationToDelete);
                }
            }
        }
    }
}
