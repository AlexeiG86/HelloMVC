using HelloMVC.Models;

namespace HelloMVC.Repos
{
    public class VacationMockRepo : IVacationRepo
    {
        List<VacationRequest> IVacationRepo.GetVacationsById(int id)
        {
            throw new NotImplementedException();
        }

        private static List<VacationRequest> _vacation;

        public static EmployeeMockRepo emp;


        public VacationMockRepo()        {            emp = new EmployeeMockRepo();            _vacation = new List<VacationRequest>();        }

        public List<VacationRequest> GetVacationsById(int id)        {
            return (emp.GetVacations(id));

        }        public void DeleteVacationByVacationId(int vacationId)        {            emp.DeleteVacation(vacationId);        }




    }
}
