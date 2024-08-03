using AutoMapper;
using HR_management.Application.Models.Timekeeping;
using HR_management.Domain.Entities;

namespace HR_management.Application.MappingProfiles
{
    public class TimekeepingProfile : Profile
    {
        public TimekeepingProfile()
        {
            CreateMap<CreateTimekeepingDto, Timekeeping>();
            CreateMap<UpdateTimekeepingDto, Timekeeping>();
            CreateMap<Timekeeping, TimekeepingForView>();
        }
    }
}
