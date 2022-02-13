using AutoMapper;
using EmplyeeDirectory.Models;
using EmplyeeDirectory.Repositories.Interfaces;
using EmplyeeDirectory.Services.Interfaces;
using EmplyeeDirectory.ViewModel;

namespace EmplyeeDirectory.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository= departmentRepository;
            _mapper=mapper;
        }
        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            var department = await _departmentRepository.GetAll();
            return _mapper.Map<List<DepartmentViewModel>>(department);
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetById(id);
            if (department == null)
                return null;
            return _mapper.Map<DepartmentViewModel>(department);
        }

        public async Task RemoveAsync(int id)
        {
            var department = await _departmentRepository.GetById(id);
            _departmentRepository.Remove(department);
            await _departmentRepository.SaveChangingAsync();
        }
        public async Task AddAsync(DepartmentViewModel departments)
        {
            var dbDepartment = _mapper.Map<Department>(departments);
            _departmentRepository.Add(dbDepartment);
            await _departmentRepository.SaveChangingAsync();
        }
        public async Task UpdateAsync(DepartmentViewModel departments)
        {
            var dbDepartment = _mapper.Map<Department>(departments);
            _departmentRepository.Update(dbDepartment);
            await _departmentRepository.SaveChangingAsync();
        }

    }
}
