namespace HelloMVC.Models
{
    public class Employee
    {


        public Employee()
        {
            VacationRequests = new List<VacationRequest>();
            
        }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }

        public List<VacationRequest> VacationRequests { get; set; }

    }
}
