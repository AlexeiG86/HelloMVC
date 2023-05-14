using HelloMVC.Models;

namespace HelloMVC.Repos
{
    public interface IVacationRepo
    {
        public List<VacationRequest> GetVacationsById(int id);


    }
}
