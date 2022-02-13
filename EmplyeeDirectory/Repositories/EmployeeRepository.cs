using EmplyeeDirectory.DbContext;
using EmplyeeDirectory.Models;
using EmplyeeDirectory.Repositories.Interfaces;

namespace EmplyeeDirectory.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
