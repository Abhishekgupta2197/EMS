using EMS.Models;
using EMS.Services;

namespace EMS.Services
{
    public class UserServiceImpl : UserService
    {
        private CompanyDbContext db;

        public UserServiceImpl(CompanyDbContext _db)
        {
            db = _db;      
        }

        public List<Employee> FindAll()
        {
            return db.Employees.ToList();
        }
    }
}
