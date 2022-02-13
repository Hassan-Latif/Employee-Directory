using EmplyeeDirectory.DbContext;
using EmplyeeDirectory.Models;
using EmplyeeDirectory.Repositories.Interfaces;

namespace EmplyeeDirectory.Repositories
{
    public class DepartmentRepository: Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

    }
}
