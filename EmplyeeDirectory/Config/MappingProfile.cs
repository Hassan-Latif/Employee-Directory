using AutoMapper;
using EmplyeeDirectory.Models;
using EmplyeeDirectory.ViewModel;

namespace EmplyeeDirectory.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
        }
    }
}
