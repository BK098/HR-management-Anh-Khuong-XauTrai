using AutoMapper;
using HR_management.Application.Models.Department;
using HR_management.Domain.Entities;

namespace HR_management.Application.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();
            CreateMap<Department,DepartmentForView>();
        }
        
    }
}
