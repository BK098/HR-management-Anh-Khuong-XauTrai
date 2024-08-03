using AutoMapper;
using HR_management.Application.Models.EmployeeTask;
using HR_management.Domain.Entities;

namespace HR_management.Application.MappingProfiles
{
    public class EmployeeTaskProfile : Profile
    {
        public EmployeeTaskProfile()
        {
            CreateMap<CreateEmployeeTaskDto, EmployeeTask>();
            CreateMap<UpdateEmployeeTaskDto, EmployeeTask>();
            CreateMap<EmployeeTask, EmployeeTaskForView>();
        }
    }
}
