using EMS.Models;

namespace EMS.Services
{
    public interface UserService
    {
        public List<Employee> FindAll(); //user = employee and admin 
    }
}
