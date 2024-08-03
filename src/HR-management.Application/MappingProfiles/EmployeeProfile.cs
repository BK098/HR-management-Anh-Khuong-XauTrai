using AutoMapper;
using HR_management.Application.Models.Employee;
using HR_management.Domain.Entities;

namespace HR_management.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeForView>();
        }
    }
}
