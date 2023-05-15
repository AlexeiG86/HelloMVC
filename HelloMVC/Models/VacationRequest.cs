namespace HelloMVC.Models
{
    public class VacationRequest
    {
        public int VacationRequestId { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public string Comment { get; set; }

        public int EmployeeId { get; set; }

        public  Employee Employee { get; set; }
    }
}
