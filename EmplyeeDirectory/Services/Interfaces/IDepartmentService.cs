using EmplyeeDirectory.ViewModel;

namespace EmplyeeDirectory.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task AddAsync(DepartmentViewModel todo);
        Task RemoveAsync(int id);
        Task UpdateAsync(DepartmentViewModel todo);
    }
}
