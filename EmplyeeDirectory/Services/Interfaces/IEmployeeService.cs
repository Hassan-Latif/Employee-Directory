using EmplyeeDirectory.ViewModel;

namespace EmplyeeDirectory.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(int id);
        Task AddAsync(EmployeeViewModel todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(EmployeeViewModel todo);
    }
}
