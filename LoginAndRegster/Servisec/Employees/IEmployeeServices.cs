using System.Numerics;

namespace LoginAndRegster.Servisec.Employees
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetAllAdmin();
        Task<IEnumerable<Employee>> GetAllSuperAdmin();
        Task<IEnumerable<Customr>> GetAllCustomer();
        Task<Employee?> checkEmail(string email);
        Task CreateEmploye(CreateEmployeeViewModel model);
         bool Delete(int id);
    }
}
